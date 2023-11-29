using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Infrastructure.Data.Configuration
{
    public class PrivateMessageEntityConfiguration : IEntityTypeConfiguration<PrivateMessage>
    {
        public void Configure(EntityTypeBuilder<PrivateMessage> builder)
        {
            builder.ToTable("PrivateMessage");

            builder.HasOne(x => x.PrivateChat)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => new { x.CreatorId, x.CompanionId})
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
