using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class NhaCungCap
{
    public Guid MaNhaCungCap { get; set; }

    public string TenNhaCungCap { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public string? GhiChu { get; set; }

    public Guid? MaNguyenVatLieu { get; set; }

    public virtual NguyenVatLieu? MaNguyenVatLieuNavigation { get; set; }

    public virtual ICollection<TonKho> TonKhos { get; set; } = new List<TonKho>();
}
