using System;
using System.Collections.Generic;

namespace ERP_backend.DTOs;

public class ChiPhiSanXuatDto
{
    public Guid MaChiPhiSanXuat { get; set; }

    public Guid MaLenhSanXuat { get; set; }

    public string LoaiChiPhi { get; set; } = null!;

    public decimal SoTien { get; set; }

    public string? MoTa { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual LenhSanXuatDto MaLenhSanXuatNavigation { get; set; } = null!;
}
