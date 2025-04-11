using System.ComponentModel.DataAnnotations;

namespace ERP_backend.Models
{
	public class ChangePassword
	{
		[Required]
		public string UserName { get; set; }
		[Required]
		public string CurrentPassword { get; set; }
		[Required]
		public string NewPassword { get; set; }
	}
}
