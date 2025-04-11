using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class BaoCaoSanXuat
{
    public int MaBaoCao { get; set; }

    public int MaKeHoach { get; set; }

    public Guid MaSanPham { get; set; }

    public string TenSanPham { get; set; } = null!;

    public DateTime NgayBatDau { get; set; }

    public DateTime NgayKetThuc { get; set; }

    public decimal SoLuongSxThucTe { get; set; }

    public decimal SoLuongSxMucTieu { get; set; }

    public decimal ThoiGianSanXuatThucTe { get; set; }

    public decimal ThoiGianSanXuatKeHoach { get; set; }

    public decimal? HieuSuatSanXuat { get; set; }

    public string TrangThai { get; set; } = null!;

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayChinhSua { get; set; }

    public virtual KeHoachSanXuat MaKeHoachNavigation { get; set; } = null!;

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
