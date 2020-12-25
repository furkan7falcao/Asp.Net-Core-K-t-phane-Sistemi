using Library.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Concreate.EntityFrameworkCore.Mapping
{
    public class MemberBookMap : IEntityTypeConfiguration<MemberBook>
    {
        public void Configure(EntityTypeBuilder<MemberBook> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();


            builder.Property(I => I.isRead).IsRequired();

            builder.HasIndex(I => new { I.MemberId, I.BookId }).IsUnique();

        }


    }
}
