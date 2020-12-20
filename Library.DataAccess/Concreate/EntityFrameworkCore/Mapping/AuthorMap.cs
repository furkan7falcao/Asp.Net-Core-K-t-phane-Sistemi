using Library.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OurProject.LibrarySystem.DataAccess.Concreate.EntityFrameworkCore.Mapping
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.FullName).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Nation).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Description).HasMaxLength(300).IsRequired();
            builder.Property(I => I.BirthDate).HasMaxLength(100);
            builder.Property(I => I.Gender).HasMaxLength(100);

            builder.HasMany(I => I.Books).WithOne(I => I.Author).HasForeignKey(I => I.AuthorId);

        }
    }
}
