using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class SanPham
{
    public Guid MaSanPham { get; set; }

    public string TenSanPham { get; set; } = null!;

    public string? MaVach { get; set; }

    public string? DonViTinh { get; set; }

    public string? NhomSanPham { get; set; }

    public decimal? GiaBan { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<BaoCaoSanXuat> BaoCaoSanXuats { get; set; } = new List<BaoCaoSanXuat>();

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual ICollection<DinhMucNguyenVatLieu> DinhMucNguyenVatLieus { get; set; } = new List<DinhMucNguyenVatLieu>();

    public virtual ICollection<KeHoachSanXuat> KeHoachSanXuats { get; set; } = new List<KeHoachSanXuat>();

    public virtual ICollection<KiemTraChatLuong> KiemTraChatLuongs { get; set; } = new List<KiemTraChatLuong>();

    public virtual ICollection<LenhGoBo> LenhGoBos { get; set; } = new List<LenhGoBo>();

    public virtual ICollection<LenhSanXuat> LenhSanXuats { get; set; } = new List<LenhSanXuat>();

    public virtual ICollection<QuyTrinhSanXuat> QuyTrinhSanXuats { get; set; } = new List<QuyTrinhSanXuat>();

    public virtual ICollection<SanPhamImg> SanPhamImgs { get; set; } = new List<SanPhamImg>();
}
