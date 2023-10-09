using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Infrastructure.Data.Configuration
{
    public class PublicChatEntityConfiguration : IEntityTypeConfiguration<PublicChat>
    {
        public void Configure(EntityTypeBuilder<PublicChat> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ChatInterests)
                .WithOne(x => x.PublicChat)
                .HasForeignKey(x => new { x.PublicChatId, x.InterestId })
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
