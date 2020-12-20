using Library.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OurProject.LibrarySystem.DataAccess.Concreate.EntityFrameworkCore.Mapping
{
    public class MemberMap : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.FullName).HasMaxLength(100).IsRequired();
            builder.Property(I => I.BirthYear).IsRequired();

            builder.HasMany(I => I.Books).WithOne(I => I.Member).HasForeignKey(I => I.MemberId);
            builder.HasMany(I => I.Requests).WithOne(I => I.PosterMember).HasForeignKey(I => I.PosterMemberId);



        }
    }
}
