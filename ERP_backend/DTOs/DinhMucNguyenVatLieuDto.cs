﻿using System;
using System.Collections.Generic;

namespace ERP_backend.DTOs;

public class DinhMucNguyenVatLieuDto
{
    public Guid MaDinhMuc { get; set; }

    public Guid MaSanPham { get; set; }

    public Guid MaNguyenVatLieu { get; set; }

    public decimal SoLuong { get; set; }

    public string MucDoSuDung { get; set; } = null!;

    public decimal? ThoiGianSanXuat { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayChinhSua { get; set; }

    public virtual NguyenVatLieuDto? MaNguyenVatLieuNavigation { get; set; } = null!;

    public virtual SanPhamDto? MaSanPhamNavigation { get; set; } = null!;
}
