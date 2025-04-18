namespace ERP_backend.DTOs
{
    public class ThemNhieuLenhSanXuatDto
    {
        public int MaKeHoach { get; set; }

        public Guid KhuVucSanXuat { get; set; }

        public Guid MaQuyTrinh { get; set; }

        public Guid MaSanPham { get; set; }


        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public string NguoiChiuTrachNhiem { get; set; }

        public int SoLuong { get; set; }

        public string TrangThai { get; set; }
    }
}
