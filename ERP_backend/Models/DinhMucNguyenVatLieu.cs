using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class DinhMucNguyenVatLieu
{
    public Guid MaDinhMuc { get; set; }

    public int MaSanPham { get; set; }

    public int MaNguyenVatLieu { get; set; }

    public decimal SoLuong { get; set; }

    public string MucDoSuDung { get; set; } = null!;

    public decimal? ThoiGianSanXuat { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayChinhSua { get; set; }

    public virtual NguyenVatLieu MaNguyenVatLieuNavigation { get; set; } = null!;

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
