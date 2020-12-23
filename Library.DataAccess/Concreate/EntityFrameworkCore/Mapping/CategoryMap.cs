using Library.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Concreate.EntityFrameworkCore.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).HasMaxLength(100).IsRequired();

            builder.HasMany(I => I.SubCategories).WithOne(I => I.Category).HasForeignKey(I => I.CategoryId);
            builder.HasMany(I => I.Books).WithOne(I => I.BaseCategory).HasForeignKey(I => I.BaseCategoryId);

        }
    }
}
