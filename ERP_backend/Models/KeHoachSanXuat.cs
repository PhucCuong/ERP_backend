using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class KeHoachSanXuat
{
    public Guid MaKeHoach { get; set; }

    public Guid MaSanPham { get; set; }

    public Guid MaNhaMay { get; set; }

    public decimal SoLuong { get; set; }

    public DateTime NgayBatDauDuKien { get; set; }

    public DateTime NgayKetThucDuKien { get; set; }

    public decimal? MucTonKhoAnToan { get; set; }

    public decimal? SoLuongSanXuatToiThieu { get; set; }

    public decimal? SoLuongSanXuatToiDa { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? NguoiTao { get; set; }

    public DateTime? NgayTao { get; set; }

    public string? NguoiChinhSua { get; set; }

    public DateTime? NgayChinhSua { get; set; }

    public virtual ICollection<BaoCaoSanXuat> BaoCaoSanXuats { get; set; } = new List<BaoCaoSanXuat>();

    public virtual ICollection<LenhGoBo> LenhGoBos { get; set; } = new List<LenhGoBo>();

    public virtual ICollection<LenhSanXuat> LenhSanXuats { get; set; } = new List<LenhSanXuat>();

    public virtual NhaMay MaNhaMayNavigation { get; set; } = null!;

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;

    public virtual ICollection<YeuCauNguyenVatLieu> YeuCauNguyenVatLieus { get; set; } = new List<YeuCauNguyenVatLieu>();
}
