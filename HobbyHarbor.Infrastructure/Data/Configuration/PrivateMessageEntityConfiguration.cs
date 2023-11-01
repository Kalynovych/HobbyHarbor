using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Infrastructure.Data.Configuration
{
    public class PrivateMessageEntityConfiguration : IEntityTypeConfiguration<PrivateMessage>
    {
        public void Configure(EntityTypeBuilder<PrivateMessage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.PrivateChat)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => new { x.CreatorId, x.CompanionId})
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.MessageAuthor)
                .WithMany(x => x.PrivateMessages)
                .HasForeignKey(x => x.MessageAuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ReplyTo)
                .WithMany()
                .HasForeignKey(x => x.ReplyMessageId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
