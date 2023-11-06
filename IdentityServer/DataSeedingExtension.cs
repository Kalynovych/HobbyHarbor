using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer
{
	public static class DataSeedingExtension
	{
		public static void AddStorage(this IApplicationBuilder app, IConfiguration config)
		{
			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

				var userContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
				userContext.Database.Migrate();

				var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
				context.Database.Migrate();
				if (!context.Clients.Any())
				{
					foreach (var client in Configuration.GetClients(config))
					{
						context.Clients.Add(client.ToEntity());
					}
					context.SaveChanges();
				}

				if (!context.IdentityResources.Any())
				{
					foreach (var resource in Configuration.GetIdentityResources())
					{
						context.IdentityResources.Add(resource.ToEntity());
					}
					context.SaveChanges();
				}

				if (!context.ApiScopes.Any())
				{
					foreach (var resource in Configuration.GetApis())
					{
						context.ApiScopes.Add(resource.ToEntity());
					}
					context.SaveChanges();
				}
			}
		}
	}
}
