using System;
using System.Collections.Generic;

namespace ERP_backend.DTOs;

public class NguyenVatLieuDto
{
    public Guid MaNguyenVatLieu { get; set; }

    public string TenNguyenVatLieu { get; set; } = null!;

    public string? MaVach { get; set; }

    public string? NhomNguyenVatLieu { get; set; }

    public string? DonViTinh { get; set; }

    public decimal? GiaNhap { get; set; }

    public decimal? TonKhoToiThieu { get; set; }

    public decimal? TonKhoToiDa { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<DinhMucNguyenVatLieuDto> DinhMucNguyenVatLieus { get; set; } = new List<DinhMucNguyenVatLieuDto>();

    public virtual ICollection<YeuCauNguyenVatLieuDto> YeuCauNguyenVatLieus { get; set; } = new List<YeuCauNguyenVatLieuDto>();
}
