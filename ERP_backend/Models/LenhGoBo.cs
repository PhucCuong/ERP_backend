using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class LenhGoBo
{
    public Guid MaLenhGoBo { get; set; }

    public Guid MaKeHoach { get; set; }

    public int MaSanPham { get; set; }

    public string LyDoGoBo { get; set; } = null!;

    public DateTime NgayBatDau { get; set; }

    public DateTime NgayKetThuc { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? NguoiChiuTrachNhiem { get; set; }

    public virtual KeHoachSanXuat MaKeHoachNavigation { get; set; } = null!;

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
