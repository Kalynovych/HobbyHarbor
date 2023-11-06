using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
	public class LoginInputModel
	{
        [Required(ErrorMessage = "E-mail is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

		[Required(ErrorMessage = "Password is required")]
		[MinLength(4, ErrorMessage = "Password is shorter than 4 characters")]
		public string Password { get; set; }

		public string ReturnUrl { get; set; }

		public bool RememberLogin { get; set; }
	}
}
