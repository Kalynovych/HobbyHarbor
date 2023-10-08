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
    public class PostInterestEntityConfiguration : IEntityTypeConfiguration<PostInterest>
    {
        public void Configure(EntityTypeBuilder<PostInterest> builder)
        {
            builder.HasKey(x => new {x.PostId, x.InterestId});

            builder.HasOne(x => x.Post)
                .WithMany(x => x.PostInterests)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Interest)
                .WithMany(x => x.PostInterests)
                .HasForeignKey(x => x.InterestId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
