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
    public class InterestCategoryEntityConfiguration : IEntityTypeConfiguration<InterestCategory>
    {
        public void Configure(EntityTypeBuilder<InterestCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Interests)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
