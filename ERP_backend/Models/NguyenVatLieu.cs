using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class NguyenVatLieu
{
    public int MaNguyenVatLieu { get; set; }

    public string TenNguyenVatLieu { get; set; } = null!;

    public string? MaVach { get; set; }

    public string? NhomNguyenVatLieu { get; set; }

    public string? DonViTinh { get; set; }

    public decimal? GiaNhap { get; set; }

    public decimal? TonKhoToiThieu { get; set; }

    public decimal? TonKhoToiDa { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<DinhMucNguyenVatLieu> DinhMucNguyenVatLieus { get; set; } = new List<DinhMucNguyenVatLieu>();

    public virtual ICollection<YeuCauNguyenVatLieu> YeuCauNguyenVatLieus { get; set; } = new List<YeuCauNguyenVatLieu>();
}
