using System;
using System.Collections.Generic;
namespace ERP_backend.DTOs;

public class QuyTrinhSanXuatDto
{
    public Guid MaQuyTrinh { get; set; }

    public string TenQuyTrinh { get; set; } = null!;

    public string? MoTa { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<ChiTietHoatDongSanXuatDto> ChiTietHoatDongSanXuats { get; set; } = new List<ChiTietHoatDongSanXuatDto>();

    public virtual ICollection<LenhSanXuatDto> LenhSanXuats { get; set; } = new List<LenhSanXuatDto>();
}
