using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class NhaMay
{
    public Guid MaNhaMay { get; set; }

    public string TenNhaMay { get; set; } = null!;

    public string? PhanLoai { get; set; }

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public string? NguoiQuanLy { get; set; }

    public int? ChiPhi { get; set; }

    public virtual ICollection<BaoTri> BaoTris { get; set; } = new List<BaoTri>();

    public virtual ICollection<KeHoachSanXuat> KeHoachSanXuats { get; set; } = new List<KeHoachSanXuat>();
}
