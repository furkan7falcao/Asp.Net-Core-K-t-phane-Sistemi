using Library.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OurProject.LibrarySystem.DataAccess.Concreate.EntityFrameworkCore.Mapping
{
    public class SubCategoryMap : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).HasMaxLength(100).IsRequired();

            builder.HasOne(I => I.Category).WithMany(I => I.SubCategories).HasForeignKey(I => I.CategoryId);
            builder.HasMany(I => I.Books).WithOne(I => I.SubCategory).HasForeignKey(I => I.SubCategoryId);

        }
    }
}
