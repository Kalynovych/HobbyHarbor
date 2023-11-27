using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Infrastructure.Data.Configuration
{
    public class PublicChatInterestEntityConfiguration : IEntityTypeConfiguration<PublicChatInterest>
    {
        public void Configure(EntityTypeBuilder<PublicChatInterest> builder)
        {
            builder.HasKey(x => new { x.PublicChatId, x.InterestId });

            builder.HasOne(x => x.PublicChat)
                .WithMany(x => x.ChatInterests)
                .HasForeignKey(x => x.PublicChatId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Interest)
                .WithMany(x => x.PublicChatInterests)
                .HasForeignKey(x => x.InterestId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
