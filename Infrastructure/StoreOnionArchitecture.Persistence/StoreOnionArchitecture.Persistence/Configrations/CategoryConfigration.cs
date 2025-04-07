using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreOnionArchitecture.Domain.Entities;

namespace YoutubeApi.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256);

            var category1 = new Category
            {
                Id = 1,
                ParentId = 0,
                Name = "Elektronik",
                Priorty = 1,
                CreatedDate = new DateTime(2023, 1, 1),
                IsDeleted = false
            };

            var category2 = new Category
            {
                Id = 2,
                ParentId = 1,
                Name = "Bilgisayar",
                Priorty = 2,
                CreatedDate = new DateTime(2023, 1, 1),
                IsDeleted = false
            };

            builder.HasData(category1, category2);
        }
    }
}
