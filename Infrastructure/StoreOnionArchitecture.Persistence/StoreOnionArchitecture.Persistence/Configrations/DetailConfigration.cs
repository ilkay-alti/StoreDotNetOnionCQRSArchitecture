using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreOnionArchitecture.Domain.Entities;

namespace YoutubeApi.Persistence.Configurations
{
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(256);

            var detail1 = new Detail
            {
                Id = 1,
                Title = "Gelişmiş",
                Description = "Bu ürün, yüksek performans sunar.",
                CategoryId = 2,
                CreatedDate = new DateTime(2023, 1, 1),
                IsDeleted = false
            };

            var detail2 = new Detail
            {
                Id = 2,
                Title = "Hafif",
                Description = "Taşınabilirlik açısından oldukça uygundur.",
                CategoryId = 2,
                CreatedDate = new DateTime(2023, 1, 1),
                IsDeleted = false
            };

            builder.HasData(detail1, detail2);
        }
    }
}
