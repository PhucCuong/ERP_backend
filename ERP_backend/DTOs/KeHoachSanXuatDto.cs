using ERP_backend.Models;
using System;
using System.Collections.Generic;

namespace ERP_backend.DTOs;

public class KeHoachSanXuatDto
{
    public string? MaKeHoach { get; set; }

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

    public virtual ICollection<BaoCaoSanXuatDto> BaoCaoSanXuats { get; set; } = new List<BaoCaoSanXuatDto>();

    public virtual ICollection<LenhGoBoDto> LenhGoBos { get; set; } = new List<LenhGoBoDto>();

    public virtual ICollection<LenhSanXuatDto> LenhSanXuats { get; set; } = new List<LenhSanXuatDto>();

    public virtual NhaMay? MaNhaMayNavigation { get; set; }

    public virtual SanPham? MaSanPhamNavigation { get; set; }

    public virtual ICollection<YeuCauNguyenVatLieuDto> YeuCauNguyenVatLieus { get; set; } = new List<YeuCauNguyenVatLieuDto>();
}
