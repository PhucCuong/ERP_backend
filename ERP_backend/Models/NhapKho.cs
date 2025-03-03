using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class NhapKho
{
    public Guid MaNhapKho { get; set; }

    public Guid MaSanPham { get; set; }

    public decimal SoLuong { get; set; }

    public DateTime NgayNhap { get; set; }

    public string? NguoiNhap { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? MoTa { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayChinhSua { get; set; }

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
