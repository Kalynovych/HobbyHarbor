using HobbyHarbor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HobbyHarbor.Infrastructure.Data.Configuration
{
    public class AttachmentTypeEntityConfiguration : IEntityTypeConfiguration<AttachmentType>
    {
        public void Configure(EntityTypeBuilder<AttachmentType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Posts)
                .WithOne(x => x.AttachmentType)
                .HasForeignKey(x => x.AttachmentTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Messages)
                .WithOne(x => x.AttachmentType)
                .HasForeignKey(x => x.AttachmentTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
