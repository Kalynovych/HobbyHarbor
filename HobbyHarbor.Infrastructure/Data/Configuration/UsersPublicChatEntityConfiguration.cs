﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HobbyHarbor.Core.Entities;

namespace HobbyHarbor.Infrastructure.Data.Configuration
{
    public class UsersPublicChatEntityConfiguration : IEntityTypeConfiguration<UsersPublicChat>
    {
        public void Configure(EntityTypeBuilder<UsersPublicChat> builder)
        {
            builder.HasKey(x => new { x.PublicChatId, x.UserId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.PublicChats)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.PublicChat)
                .WithMany(x => x.Participants)
                .HasForeignKey(x => x.PublicChatId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
