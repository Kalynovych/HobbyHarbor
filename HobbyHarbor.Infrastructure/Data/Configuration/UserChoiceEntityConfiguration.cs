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
    public class UserChoiceEntityConfiguration : IEntityTypeConfiguration<UserChoice>
    {
        public void Configure(EntityTypeBuilder<UserChoice> builder)
        {
            builder.HasKey(x => new { x.UserId, x.TargetId });
        }
    }
}
