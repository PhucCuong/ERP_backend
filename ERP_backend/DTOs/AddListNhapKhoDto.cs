namespace ERP_backend.DTOs
{
    public class AddListNhapKhoDto
    {
        public string MaKeHoach { get; set; }
        public Guid MaSanPham { get; set; }

        public int SoLuongNhap { get; set; }

        public DateTime NgayNhap { get; set; }

        public string? NguoiNhap { get; set; }

        public string TrangThai { get; set; } = null!;

        public string? MoTa { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgayChinhSua { get; set; }
    }
}
