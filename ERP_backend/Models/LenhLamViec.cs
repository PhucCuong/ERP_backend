using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class LenhLamViec
{
    public Guid MaLenhLamViec { get; set; }

    public Guid MaLenhSanXuat { get; set; }

    public string TenLenhLamViec { get; set; } = null!;

    public int MaSanPham { get; set; }

    public decimal? SoLuongSanXuat { get; set; }

    public decimal TongSoLuongYeuCau { get; set; }

    public string? KhuVucLamViec { get; set; }

    public DateTime ThoiGianBatDau { get; set; }

    public decimal? TongThoiGianThucHien { get; set; }

    public string TrangThai { get; set; } = null!;

    public virtual LenhSanXuat MaLenhSanXuatNavigation { get; set; } = null!;

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
