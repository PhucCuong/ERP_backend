using System;
using System.Collections.Generic;

namespace ERP_backend.DTOs;

public class ChiTietHoatDongSanXuatDto
{
	public Guid MaHoatDong { get; set; } = Guid.NewGuid();

	public Guid MaQuyTrinh { get; set; }

	public string TenHoatDong { get; set; } = null!;

	public string? GiaiDoanSanXuat { get; set; }

	public int ThuTu { get; set; }

	public decimal? SoLuongChoXuLy { get; set; }

	public decimal? ThoiGianMacDinh { get; set; }

	public string? DieuKienBatDauGiaiDoanTiepTheo { get; set; } = null!;

	public string? MoTa { get; set; }
	public string? FileData { get; set; }

}
