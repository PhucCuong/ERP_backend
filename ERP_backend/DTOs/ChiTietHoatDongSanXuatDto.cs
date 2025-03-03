using System;
using System.Collections.Generic;

namespace ERP_backend.DTOs;

public class ChiTietHoatDongSanXuatDto
{
	public Guid MaHoatDong { get; set; }

	public Guid MaQuyTrinh { get; set; }

	public string TenHoatDong { get; set; } = null!;

	public string? GiaiDoanSanXuat { get; set; }

	public int ThuTu { get; set; }

	public decimal? SoLuongChoXuLy { get; set; }

	public string LoaiTinhThoiGian { get; set; } = null!;

	public decimal? ThoiGianMacDinh { get; set; }

	public string? DieuKienBatDauGiaiDoanTiepTheo { get; set; } = null!;

	public string? MoTa { get; set; }

	public virtual QuyTrinhSanXuatDto MaQuyTrinhNavigation { get; set; } = null!;
}
