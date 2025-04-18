using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class NguyenVatLieu
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

    public decimal? TonKhoHienCo { get; set; }

    public virtual ICollection<DinhMucNguyenVatLieu> DinhMucNguyenVatLieus { get; set; } = new List<DinhMucNguyenVatLieu>();

    public virtual ICollection<NhaCungCap> NhaCungCaps { get; set; } = new List<NhaCungCap>();

    public virtual ICollection<TonKho> TonKhos { get; set; } = new List<TonKho>();

    public virtual ICollection<YeuCauNguyenVatLieu> YeuCauNguyenVatLieus { get; set; } = new List<YeuCauNguyenVatLieu>();
}
