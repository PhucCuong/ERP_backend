using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class LenhSanXuat
{
    public Guid MaLenh { get; set; }

    public Guid MaKeHoach { get; set; }

    public Guid MaQuyTrinh { get; set; }

    public int MaSanPham { get; set; }

    public decimal SoLuong { get; set; }

    public DateTime NgayBatDau { get; set; }

    public DateTime NgayKetThuc { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? NguoiChiuTrachNhiem { get; set; }

    public virtual ICollection<ChiPhiSanXuat> ChiPhiSanXuats { get; set; } = new List<ChiPhiSanXuat>();

    public virtual ICollection<LenhLamViec> LenhLamViecs { get; set; } = new List<LenhLamViec>();

    public virtual KeHoachSanXuat MaKeHoachNavigation { get; set; } = null!;

    public virtual QuyTrinhSanXuat MaQuyTrinhNavigation { get; set; } = null!;

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
