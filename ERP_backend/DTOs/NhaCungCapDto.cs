namespace ERP_backend.DTOs
{
	public class NhaCungCapDto
	{
		public Guid MaNhaCungCap { get; set; }

		public string TenNhaCungCap { get; set; } = null!;

		public string? DiaChi { get; set; }

		public string? SoDienThoai { get; set; }

		public string? Email { get; set; }

		public string? GhiChu { get; set; }

		public Guid? MaNguyenVatLieu { get; set; }
	}
}
