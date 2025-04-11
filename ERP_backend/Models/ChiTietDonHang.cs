using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class ChiTietDonHang
{
    public int MaChiTietDonHang { get; set; }

    public Guid? MaDonHang { get; set; }

    public Guid? MaSanPham { get; set; }

    public int? SoLuong { get; set; }

    public decimal? GiaSanPham { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual DonHang? MaDonHangNavigation { get; set; }

    public virtual SanPham? MaSanPhamNavigation { get; set; }
}
