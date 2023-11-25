using IdentityModel;
using IdentityServer4.Models;

namespace IdentityServer
{
	public static class Configuration
	{
		public static IEnumerable<IdentityResource> GetIdentityResources() =>
			new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile(),
				new IdentityResources.Email(),
			};

		public static IEnumerable<ApiScope> GetApis() => new List<ApiScope>() { new ApiScope("api_one") };

		public static IEnumerable<Client> GetClients() =>
			new List<Client>() {
				new Client()
				{
					ClientId = "client_mvc",
					ClientSecrets = { new Secret("client_secret".ToSha256()) },
					AllowedGrantTypes = GrantTypes.Code,
					AllowedScopes = { "api_one", "openid", "profile", "email" },
					RequirePkce = true,
					RequireConsent = false,

					RedirectUris = { "https://localhost:7278/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:7278/Home/Index" },
					
					AllowOfflineAccess = true,
				},
			};
	}
}
