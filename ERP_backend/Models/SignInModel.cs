using System.ComponentModel.DataAnnotations;

namespace ERP_backend.Models
{
	public class SignInModel
	{
		[Required]
		public string UserName { get; set; } = null!;
		[Required]
		public string Password { get; set; } = null!;
		
	}
}
