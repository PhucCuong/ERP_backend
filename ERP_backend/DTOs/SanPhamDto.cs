using System;
using System.Collections.Generic;

namespace ERP_backend.DTOs;
public class SanPhamDto
{
    public Guid MaSanPham { get; set; }

    public string TenSanPham { get; set; } = null!;

    public string? MaVach { get; set; }

    public string? DonViTinh { get; set; }

    public string? NhomSanPham { get; set; }

    public decimal? GiaBan { get; set; }

    public string? MoTa { get; set; }


	public virtual ICollection<BaoCaoSanXuatDto> BaoCaoSanXuats { get; set; } = new List<BaoCaoSanXuatDto>();

    public virtual ICollection<DinhMucNguyenVatLieuDto> DinhMucNguyenVatLieus { get; set; } = new List<DinhMucNguyenVatLieuDto>();

    public virtual ICollection<KeHoachSanXuatDto> KeHoachSanXuats { get; set; } = new List<KeHoachSanXuatDto>();

    public virtual ICollection<KiemTraChatLuongDto> KiemTraChatLuongs { get; set; } = new List<KiemTraChatLuongDto>();

    public virtual ICollection<LenhGoBoDto> LenhGoBos { get; set; } = new List<LenhGoBoDto>();


    public virtual ICollection<LenhSanXuatDto> LenhSanXuats { get; set; } = new List<LenhSanXuatDto>();

    public virtual ICollection<NhapKhoDto> NhapKhos { get; set; } = new List<NhapKhoDto>();
}
