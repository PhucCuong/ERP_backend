using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ERP_backend.Models
{
	public class ApplicationUser : IdentityUser<Guid>
	{
		[Required, MaxLength(255)]
		public string HoTen { get; set; }
		[MaxLength(10)]
		public string ChucVu { get; set; }

	}
}
