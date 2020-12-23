using Library.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Concreate.EntityFrameworkCore.Mapping
{
    public class RequestMap : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Description).HasMaxLength(100).IsRequired();

            builder.HasOne(I => I.PosterMember).WithMany(I => I.Requests).HasForeignKey(I => I.PosterMemberId);
            builder.HasOne(I => I.WantedBook).WithMany(I => I.Requests).HasForeignKey(I => I.WantedBookId);



        }
    }
}
