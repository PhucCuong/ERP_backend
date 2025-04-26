using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP_backend.DTOs;

public class LenhSanXuatDto
{
	public string? MaLenh { get; set; }

	public int MaKeHoach { get; set; }

	public Guid MaQuyTrinh { get; set; }

	public Guid MaSanPham { get; set; }

	public decimal SoLuong { get; set; }

	public DateTime NgayBatDau { get; set; }

	public DateTime NgayKetThuc { get; set; }
	public string TrangThai { get; set; } = null!;
	public string? NguoiChiuTrachNhiem { get; set; }

	public Guid MaDinhMuc { get; set; }
	public string KhuVucSanXuat { get; set; } = null!;

    public Guid? MaHoatDong { get; set; }

}
