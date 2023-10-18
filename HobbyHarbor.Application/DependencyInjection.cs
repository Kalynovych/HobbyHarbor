using HobbyHarbor.Application.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace HobbyHarbor.Application
{
	public static class DependencyInjection
	{
		public static void AddApplication(this IServiceCollection services)
		{
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUserById).Assembly));
		}
	}
}
