using System.ComponentModel.DataAnnotations;

namespace ERP_backend.Models
{
	public class SignUpModel
	{

		[Required]
		public string HoTen { get; set; } = null!;
		[Required]
		public string TenDangNhap { get; set; } = null!;
		[Required, EmailAddress]
		public string Email { get; set; } = null!;
		[Required]
		public string Password { get; set; } = null!;
		[Required]
		public string ConfirmPassword { get; set; } = null!;
		[Required]
		public string PhoneNumber { get; set; } = null!;
		[Required]
		public string ChucVu { get; set; } = null!;
	}
}
