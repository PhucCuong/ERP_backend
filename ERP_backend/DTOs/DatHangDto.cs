namespace ERP_backend.DTOs
{
	public class DatHangDto
	{
		public Guid MaKhachHang { get; set; }
		public List<SanPhamChiTietDto> SanPhamChiTiets { get; set; }
	}
}
