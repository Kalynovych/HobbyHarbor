using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Core.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HobbyHarbor.Infrastructure.Data
{
    public static class DataSeedingExtension
    {
        public static async Task CreateDatabase(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<HobbyHarborDbContext>();
                var database = dbContext.Database;

                await database.EnsureDeletedAsync();
                await database.EnsureCreatedAsync();
            }
        }
    }
}
