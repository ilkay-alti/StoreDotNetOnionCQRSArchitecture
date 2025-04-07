using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StoreOnionArchitecture.Domain.Entities;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasData(
            new Brand
            {
                Id =1,
                Name = "Apple",
                CreatedDate = new DateTime(2023, 1, 1)
            },
            new Brand
            {
                Id = 2,
                Name = "Samsung",
                CreatedDate = new DateTime(2023, 1, 1)
            },
            new Brand
            {
                Id = 3,
                Name = "Sony",
                CreatedDate = new DateTime(2023, 1, 1)
            }
        );
    }
}
