using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
	public class RegisterInputModel
	{
		[Required(ErrorMessage = "E-mail is required")]
		[DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Username is required")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Password is required")]
		[DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Password is shorter than 4 characters")]
        public string Password { get; set; }

		[Required(ErrorMessage = "Password confirmation is required")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Password does not match")]
		public string ConfirmPassword { get; set; }

		public string ReturnUrl { get; set; }
	}
}
