using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class Kho
{
    public Guid MaKho { get; set; }

    public string TenKho { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string TrangThai { get; set; } = null!;

    public virtual ICollection<TonKho> TonKhos { get; set; } = new List<TonKho>();
}
