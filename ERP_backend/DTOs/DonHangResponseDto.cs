namespace ERP_backend.DTOs
{
	public class DonHangResponseDto
	{
		public Guid MaDonHang { get; set; }
		public DateTime NgayDatHang { get; set; }
		public decimal TongTien { get; set; }
		public string TrangThai { get; set; }
	}
}
