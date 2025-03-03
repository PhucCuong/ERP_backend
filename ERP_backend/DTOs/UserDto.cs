using System;
using System.Collections.Generic;

namespace ERP_backend.DTOs;

public class UserDto
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

    public Guid? MaChucVu { get; set; }

    public virtual ChucVuDto? MaChucVuNavigation { get; set; }
}
