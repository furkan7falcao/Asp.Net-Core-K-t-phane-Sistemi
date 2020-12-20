using Library.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OurProject.LibrarySystem.DataAccess.Concreate.EntityFrameworkCore.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).HasMaxLength(100).IsRequired();
            builder.Property(I => I.PublishedTime).HasMaxLength(100);
            builder.Property(I => I.ShortDescription).HasMaxLength(500).IsRequired();
            builder.Property(I => I.LongDescription).HasMaxLength(1000).IsRequired();
            builder.Property(I => I.PageNumber).IsRequired();
            builder.Property(I => I.Count).HasMaxLength(100).IsRequired();

            builder.HasOne(I => I.Author).WithMany(I => I.Books).HasForeignKey(I => I.AuthorId);
            builder.HasOne(I => I.Member).WithMany(I => I.Books).HasForeignKey(I => I.MemberId).IsRequired(false);
            builder.HasOne(I => I.BaseCategory).WithMany(I => I.Books).HasForeignKey(I => I.BaseCategoryId);
            builder.HasOne(I => I.SubCategory).WithMany(I => I.Books).HasForeignKey(I => I.SubCategoryId);
            builder.HasMany(I => I.Requests).WithOne(I => I.WantedBook).HasForeignKey(I => I.WantedBookId);










        }
    }
}
