using ERP_backend.Models;
using System;
using System.Collections.Generic;

namespace ERP_backend.DTOs;

public class BaoTriDto
{
    public Guid MaBaoTri { get; set; }

    public Guid MaNhaMay { get; set; }

    public string TenBaoTri { get; set; } = null!;

    public string? MoTa { get; set; }

    public DateTime NgayBatDau { get; set; }

    public DateTime NgayKetThuc { get; set; }

    public string TrangThai { get; set; } = null!;

    public virtual NhaMayDto? MaNhaMayNavigation { get; set; } = null!;
}
