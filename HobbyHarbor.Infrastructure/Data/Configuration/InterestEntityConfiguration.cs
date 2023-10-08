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
    public class InterestEntityConfiguration : IEntityTypeConfiguration<Interest>
    {
        public void Configure(EntityTypeBuilder<Interest> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
