using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreOnionArchitecture.Domain.Entities;

namespace YoutubeApi.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(256);
            builder.Property(p => p.Price).HasPrecision(18, 2);
            builder.Property(p => p.Discount).HasPrecision(18, 2);

            var product1 = new Product
            {
                Id = 1,
                Title = "Akıllı Telefon",
                Description = "Yüksek çözünürlüklü kamera ve hızlı işlemci ile donatılmıştır.",
                BrandId = 1,
                Price = 1250.00m,
                Discount = 100.00m,
                CreatedDate = new DateTime(2023, 1, 1),
                IsDeleted = false
            };

            var product2 = new Product
            {
                Id = 2,
                Title = "Kablosuz Kulaklık",
                Description = "Uzun pil ömrü ve yüksek ses kalitesi sunar.",
                BrandId = 2,
                Price = 850.00m,
                Discount = 150.00m,
                CreatedDate = new DateTime(2023, 1, 1),
                IsDeleted = false
            };

            builder.HasData(product1, product2);
        }
    }
}
