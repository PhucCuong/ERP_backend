namespace ERP_backend.DTOs
{
	public class KhoDto
	{
		public Guid MaKho { get; set; }

		public string TenKho { get; set; } = null!;

		public string? DiaChi { get; set; }

		public string TrangThai { get; set; } = null!;
	}
}
