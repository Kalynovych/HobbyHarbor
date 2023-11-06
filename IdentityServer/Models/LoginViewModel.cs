using Microsoft.AspNetCore.Authentication;

namespace IdentityServer.Models
{
	public class LoginViewModel : LoginInputModel
	{
		public bool AllowRememberLogin { get; set; } = true;
		public bool EnableLocalLogin { get; set; } = true;

		public IEnumerable<AuthenticationScheme> ExternalProviders { get; set; }
	}
}
