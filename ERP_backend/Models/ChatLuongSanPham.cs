namespace ERP_backend.Models
{
    public class ChatLuongSanPham
    {
        public string Soseri { get; set; } = null!;

        public string TenSanPham { get; set; }

        public DateTime NgayNhap { get; set; }

        public string? NguoiNhap { get; set; }

        public string? TrangThai { get; set; }
    }
}
