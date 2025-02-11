using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class User
{
    public Guid MaUser { get; set; }

    public string TenDangNhap { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? SoDienThoai { get; set; }

    public string VaiTro { get; set; } = null!;

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayChinhSua { get; set; }

    public int? MaChucVu { get; set; }

    public virtual ChucVu? MaChucVuNavigation { get; set; }
}
