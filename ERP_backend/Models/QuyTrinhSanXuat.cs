using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class QuyTrinhSanXuat
{
    public Guid MaQuyTrinh { get; set; }

    public string TenQuyTrinh { get; set; } = null!;

    public string? MoTa { get; set; }

    public string? TrangThai { get; set; }

    public Guid MaHoatDong { get; set; }

    public Guid? MaSanPham { get; set; }

    public virtual ICollection<ChiTietHoatDongSanXuat> ChiTietHoatDongSanXuats { get; set; } = new List<ChiTietHoatDongSanXuat>();

    public virtual ICollection<LenhSanXuat> LenhSanXuats { get; set; } = new List<LenhSanXuat>();

    public virtual SanPham? MaSanPhamNavigation { get; set; }
}
