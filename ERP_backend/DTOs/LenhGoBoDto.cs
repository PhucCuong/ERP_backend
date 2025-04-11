using System;
using System.Collections.Generic;

namespace ERP_backend.DTOs;

public class LenhGoBoDto
{
    public int MaLenhGoBo { get; set; }

    public int MaKeHoach { get; set; }

    public Guid MaSanPham { get; set; }

    public string LyDoGoBo { get; set; } = null!;

    public DateTime NgayBatDau { get; set; }

    public DateTime NgayKetThuc { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? NguoiChiuTrachNhiem { get; set; }

    public virtual KeHoachSanXuatDto MaKeHoachNavigation { get; set; } = null!;

    public virtual SanPhamDto MaSanPhamNavigation { get; set; } = null!;
}
