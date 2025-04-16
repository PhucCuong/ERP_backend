using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class DonHang
{
    public Guid MaDonHang { get; set; }

    public Guid MaKhachHang { get; set; }

    public DateTime? NgayDatHang { get; set; }

    public string? TrangThai { get; set; }

    public decimal? TongTien { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual AspNetUser MaKhachHangNavigation { get; set; } = null!;
}
