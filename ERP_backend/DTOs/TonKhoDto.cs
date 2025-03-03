using ERP_backend.Models;

namespace ERP_backend.DTOs
{
	public class TonKhoDto
	{
		public Guid MaKho { get; set; }

		public Guid MaNguyenVatLieu { get; set; }

		public decimal SoLuongTon { get; set; }

		public decimal MucToiThieu { get; set; }

		public DateTime? NgayCapNhatCuoi { get; set; }

		public virtual Kho MaKhoNavigation { get; set; } = null!;
	}
}
