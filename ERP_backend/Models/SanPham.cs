using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ERP_backend.Models;

public partial class SanPham
{
    //[BindNever] // Không hiển thị trong Swagger khi gửi request
    public int MaSanPham { get; set; }

    public string TenSanPham { get; set; } = null!;

    public string? MaVach { get; set; }

    public string? DonViTinh { get; set; }

    public string? NhomSanPham { get; set; }

    public decimal? GiaBan { get; set; }

    public string? MoTa { get; set; }

    public decimal? ChiPhiSanXuat { get; set; }

    
    public byte[]? Img { get; set; }
    
    [NotMapped] // Chỉ dùng để nhận file, không lưu vào DB
    public IFormFile? ImageFile { get; set; }

    public virtual ICollection<BaoCaoSanXuat> BaoCaoSanXuats { get; set; } = new List<BaoCaoSanXuat>();

    public virtual ICollection<DinhMucNguyenVatLieu> DinhMucNguyenVatLieus { get; set; } = new List<DinhMucNguyenVatLieu>();

    public virtual ICollection<KeHoachSanXuat> KeHoachSanXuats { get; set; } = new List<KeHoachSanXuat>();

    public virtual ICollection<KiemTraChatLuong> KiemTraChatLuongs { get; set; } = new List<KiemTraChatLuong>();

    public virtual ICollection<LenhGoBo> LenhGoBos { get; set; } = new List<LenhGoBo>();

    public virtual ICollection<LenhLamViec> LenhLamViecs { get; set; } = new List<LenhLamViec>();

    public virtual ICollection<LenhSanXuat> LenhSanXuats { get; set; } = new List<LenhSanXuat>();

    public virtual ICollection<NhapKho> NhapKhos { get; set; } = new List<NhapKho>();
}
