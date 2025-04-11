using System;
using System.Collections.Generic;

namespace ERP_backend.DTOs;

public class NhaMayDto
{
    public Guid MaNhaMay { get; set; }

    public string TenNhaMay { get; set; } = null!;

    public string? PhanLoai { get; set; }

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public string? NguoiQuanLy { get; set; }

    public decimal ChiPhi { get; set; }


    public virtual ICollection<BaoTriDto> BaoTris { get; set; } = new List<BaoTriDto>();

    public virtual ICollection<KeHoachSanXuatDto> KeHoachSanXuats { get; set; } = new List<KeHoachSanXuatDto>();
}
