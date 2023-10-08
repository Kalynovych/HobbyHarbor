using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Infrastructure.Data.Configuration
{
    public class MessageEntityConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.PrivateChat)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => new { x.AuthorId, x.CompanionId })
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.PublicChat)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.PublicChatId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
