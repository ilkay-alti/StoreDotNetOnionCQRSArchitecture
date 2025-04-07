using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreOnionArchitecture.Domain.Entities;

namespace StoreOnionArchitecture.Persistence.Configrations
{
    public class ProductCategoryConfigration: IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.CategoryId });
            builder.HasOne(x => x.Product).WithMany(x => x.ProductCategories)
                .HasForeignKey(x => x.ProductId).OnDelete(deleteBehavior:DeleteBehavior.Cascade);
            builder.HasOne(x => x.Category).WithMany(x => x.ProductCategories)
                .HasForeignKey(x => x.CategoryId).OnDelete(deleteBehavior:DeleteBehavior.Cascade);
        }

       
        
    }
}
