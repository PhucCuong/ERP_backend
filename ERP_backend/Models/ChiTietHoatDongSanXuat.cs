using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class ChiTietHoatDongSanXuat
{
    public Guid MaHoatDong { get; set; }

    public Guid MaQuyTrinh { get; set; }

    public string TenHoatDong { get; set; } = null!;

    public string? GiaiDoanSanXuat { get; set; }

    public int ThuTu { get; set; }

    public decimal? SoLuongChoXuLy { get; set; }

    public decimal? ThoiGianMacDinh { get; set; }

    public string DieuKienBatDauGiaiDoanTiepTheo { get; set; } = null!;

    public string? MoTa { get; set; }

    public string? FileData { get; set; }

    public virtual QuyTrinhSanXuat MaQuyTrinhNavigation { get; set; } = null!;
}
