# StoreOnionArchitecture

Bu proje, .NET 9 platformu üzerinde **Onion (Soğan) Mimarisi** ve **CQRS (Command Query Responsibility Segregation)** desenlerini kullanarak geliştirilmiş örnek bir Mağaza (Store) backend uygulamasıdır. Amacı, modern .NET teknolojileriyle ölçeklenebilir, sürdürülebilir ve test edilebilir uygulamalar geliştirmek için bir referans ve başlangıç noktası sunmaktır.

## 🚀 Amaç

* Temiz kod ve SOLID prensiplerini uygulamak.
* Onion Mimarisi'nin katmanlı yapısını (Domain, Application, Infrastructure, Presentation) ve bağımlılık tersine çevirme ilkesini göstermek.
* CQRS deseni ile okuma (Queries) ve yazma (Commands) operasyonlarını MediatR kütüphanesi kullanarak ayırmak.
* Modern .NET teknolojilerini (.NET 9, ASP.NET Core, Entity Framework Core, ASP.NET Core Identity, JWT) bir arada kullanmak.
* Repository ve Unit of Work desenlerini uygulamak.
* Redis kullanarak yanıtları önbelleğe alma (Caching) mekanizmasını göstermek (Pipeline Behavior ile).
* Merkezi ve özelleştirilebilir Exception Handling mekanizması sunmak.
* FluentValidation ile istek doğrulama yapmak.
* JWT (JSON Web Token) ile kimlik doğrulama ve Refresh Token mekanizmasını uygulamak.
* Geliştiricilere benzer projeler için bir şablon sunmak.

## 🏗️ Mimari

Proje, aşağıdaki temel prensipler üzerine kurulmuştur:

1.  **Onion Architecture (Soğan Mimarisi):**
    * **Domain Katmanı:** İş mantığının çekirdeği. Entities (Varlıklar), Value Objects (Değer Nesneleri), Enumlar ve temel arayüzler (örn: `IEntityBase`). Dış katmanlara bağımlılığı yoktur.
    * **Application Katmanı:** Uygulama mantığı. Commands, Queries, DTOs (Data Transfer Objects), Validations (FluentValidation), Behaviors (MediatR Pipeline Behaviors), Rules, Exceptions ve dış dünya ile iletişim için arayüzler (Repositories, UnitOfWork, AutoMapper, TokenService, RedisCacheService). Domain katmanına bağımlıdır.
    * **Infrastructure Katmanı:** Dış servisler ve altyapısal konular. Persistence (EF Core, Repositories, UnitOfWork, DbContext, Migrations), Infrastructure (Token Service, Redis Cache Service). Application katmanındaki arayüzleri uygular.
    * **Presentation Katmanı (API):** Kullanıcı arayüzü veya API endpoint'leri (ASP.NET Core Web API). Controllers, Program.cs (DI Container yapılandırması), appsettings.json. Application ve Infrastructure katmanlarına bağımlıdır.
    * **Mapper:** Nesneler arası dönüşüm için özel bir AutoMapper implementasyonu içerir.

2.  **CQRS (Command Query Responsibility Segregation):**
    * `MediatR` kütüphanesi kullanılarak komutlar (Commands) ve sorgular (Queries) ayrıştırılmıştır.
    * Komutlar (örn: `CreateProductCommand`, `RegisterCommand`) sistemin durumunu değiştirir.
    * Sorgular (örn: `GetAllProductsQuery`) sistemden veri okur. Bazı sorgular Redis ile önbelleğe alınabilir (`ICacheableQuery`).
    * FluentValidation ile istekler (Command/Query) doğrulanır (`FluentValidationBehevior`).
    * Redis Cache Behavior (`RedisCacheBehevior`) ile sorgu sonuçları Redis'te önbelleğe alınır.

## 🛠️ Kullanılan Teknolojiler

* **.NET 9**
* **ASP.NET Core:** Web API katmanı için.
* **Entity Framework Core:** Veritabanı işlemleri (ORM) için.
* **SQL Server:** Veritabanı olarak kullanılmıştır (Yerel geliştirme için).
* **ASP.NET Core Identity:** Kullanıcı ve rol yönetimi için (`User`, `Role` entities).
* **JWT Bearer Authentication:** API güvenliği için (Access Token & Refresh Token).
* **MediatR:** CQRS desenini uygulamak ve In-Process mesajlaşma için.
* **FluentValidation:** İstek (Command/Query) validasyonu için.
* **AutoMapper (Custom Implementation):** Nesneler arası haritalama için (`StoreOnionArchitecture.Mapper`).
* **StackExchange.Redis:** Redis Cache işlemleri için.
* **Newtonsoft.Json:** Redis Cache serileştirmesi için.
* **Bogus:** Veritabanı seed işlemleri için örnek veri üretimi.
* **Scalar / OpenAPI (Swagger):** API dokümantasyonu ve testi için.

## ✨ Özellikler

* **Kimlik Doğrulama (Authentication):**
    * Kullanıcı Kaydı (`Register`)
    * Kullanıcı Girişi (`Login`) - JWT Access Token ve Refresh Token döndürür.
    * Token Yenileme (`RefreshToken`)
    * Token İptali (`Revoke`, `RevokeAll`)
* **Ürün Yönetimi (Product Management):**
    * Ürün Listeleme (`GetAllProducts`) - Fiyatlar indirim uygulanarak gösterilir.
    * Ürün Ekleme (`CreateProduct`)
    * Ürün Güncelleme (`UpdateProduct`)
    * Ürün Silme (`DeleteProduct`) - Soft delete (IsDeleted flag'i kullanılır).
* **Marka Yönetimi (Brand Management - Redis Test):**
    * Toplu Marka Ekleme (`CreateBrands` - Bogus ile 1 Milyon kayıt ekler)
    * Marka Listeleme (`GetAllBrands`) - Redis Cache'den döner (`ICacheableQuery`).
* **Yetkilendirme (Authorization):**
    * Rol bazlı yetkilendirme örnekleri (`ProductController` içinde `[Authorize(Roles = "...")]`).
* **Diğer:**
    * Merkezi Hata Yönetimi (Custom Exception Middleware).
    * Redis ile Sorgu Önbelleğe Alma (MediatR Pipeline Behavior).
    * FluentValidation ile İstek Doğrulama (MediatR Pipeline Behavior).
    * Repository ve Unit of Work desenleri.

## 🏁 Başlangıç

Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin:

1.  **Ön Gereksinimler:**
    * .NET 9 SDK ([https://dotnet.microsoft.com/download/dotnet/9.0](https://dotnet.microsoft.com/download/dotnet/9.0))
    * SQL Server (Express, Developer veya başka bir sürüm)
    * Redis (Opsiyonel - Cache mekanizmasını test etmek için [https://redis.io/docs/getting-started/installation/](https://redis.io/docs/getting-started/installation/))
    * Git
    * IDE (Örn: Visual Studio 2022+, VS Code, Rider)

2.  **Projeyi Klonlama:**
    ```bash
    git clone https://github.com/ilkay-alti/StoreDotNetOnionCQRSArchitecture.git
    cd StoreOnionArchitecture
    ```

3.  **Yapılandırma (Configuration):**
    * **Veritabanı:** `Presentation/StoreOnionArchitecture.Api/StoreOnionArchitecture.Api/appsettings.Development.json` dosyasındaki `ConnectionStrings:DefaultConnection` değerini kendi SQL Server bağlantı bilgilerinizle güncelleyin.
    * **Redis:** `Presentation/StoreOnionArchitecture.Api/StoreOnionArchitecture.Api/appsettings.json` dosyasındaki `RedisCacheSettings` bölümünü çalışan Redis sunucunuza göre güncelleyin (varsayılan: `localhost:6379`).

4.  **Veritabanı Kurulumu (EF Core Migrations):**
    * Komut istemcisini (Terminal, PowerShell, CMD) projenin kök dizininde açın.
    * Aşağıdaki komutu çalıştırarak veritabanı tablolarını oluşturun:
        ```bash
        dotnet ef database update --project Infrastructure/StoreOnionArchitecture.Persistence/StoreOnionArchitecture.Persistence --startup-project Presentation/StoreOnionArchitecture.Api/StoreOnionArchitecture.Api
        ```

5.  **Projeyi Çalıştırma:**
    * API projesini başlatın:
        ```bash
        dotnet run --project Presentation/StoreOnionArchitecture.Api/StoreOnionArchitecture.Api --launch-profile http
        ```
        *(Not: `http` profili `launchSettings.json` içinde tanımlıdır ve genellikle geliştirme için daha uygundur)*

6.  **API'ye Erişme:**
    * Uygulama çalıştırıldıktan sonra API dokümantasyonuna ve test arayüzüne erişmek için tarayıcınızdan `http://localhost:5000/scalar/v1` adresine gidin. (`launchSettings.json`'daki `http` profili portu).
    * Alternatif olarak OpenAPI (Swagger) JSON tanımına `http://localhost:5000/openapi/v1` adresinden erişebilirsiniz.
    * Yetkilendirme gerektiren endpoint'leri test etmek için önce `/api/Auth/Register` ile bir kullanıcı kaydedip, `/api/Auth/Login` ile giriş yaparak aldığınız JWT token'ını kullanmanız gerekmektedir. Scalar veya benzeri bir araçta "Authorization" header'ına `Bearer [TOKEN]` şeklinde ekleyebilirsiniz.

## 🤝 Katkıda Bulunma

Katkılarınız projeyi daha iyi hale getirmemize yardımcı olur! Lütfen katkıda bulunmadan önce (varsa) `CONTRIBUTING.md` dosyasını okuyun.

1.  Projeyi Fork'layın.
2.  Yeni bir Feature Branch oluşturun (`git checkout -b feature/HarikaOzellik`).
3.  Değişikliklerinizi Commit'leyin (`git commit -m 'Yeni HarikaOzellik eklendi'`).
4.  Branch'inizi Push'layın (`git push origin feature/HarikaOzellik`).
5.  Bir Pull Request açın.

## 📄 Lisans

Bu proje **MIT Lisansı** altında dağıtılmaktadır. Daha fazla bilgi için `LICENSE.txt` dosyasına bakın.

Copyright (c) 2025 İlkay ALTINIŞIK
