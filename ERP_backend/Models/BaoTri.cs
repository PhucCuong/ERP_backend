using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class BaoTri
{
    public Guid MaBaoTri { get; set; }

    public Guid MaNhaMay { get; set; }

    public string TenBaoTri { get; set; } = null!;

    public string? MoTa { get; set; }

    public DateTime NgayBatDau { get; set; }

    public DateTime NgayKetThuc { get; set; }

    public string TrangThai { get; set; } = null!;

    public virtual NhaMay MaNhaMayNavigation { get; set; } = null!;
}
