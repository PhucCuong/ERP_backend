using ERP_backend.DTOs;

namespace ERP_backend.Models
{
    public class WorkOrder
    {
        public string? MaLenh { get; set; }

        public int MaKeHoach { get; set; }

        public string TenQuyTrinh { get; set; }

        public string  TenSanPham { get; set; }

        public decimal SoLuong { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public string TrangThai { get; set; } = null!;

        public string? NguoiChiuTrachNhiem { get; set; }

        public string KhuVucSanXuat { get; set; } = null!;

        public string TenHoatDong { get; set; } = null!;

        public int ThuTu { get; set; }
    }

}
