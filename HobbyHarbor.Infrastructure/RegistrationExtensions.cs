using HobbyHarbor.Application.Interfaces;
using HobbyHarbor.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HobbyHarbor.Infrastructure
{
    public static class RegistrationExtensions
    {
        public static void AddStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HobbyHarborDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:LocalSqlDb"]));

            services.AddScoped<IHobbyHarborDbContext, HobbyHarborDbContext>();
        }
    }
}
