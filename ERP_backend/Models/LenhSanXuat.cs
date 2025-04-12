using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class LenhSanXuat
{
    public int? MaLenh { get; set; }

    public int MaKeHoach { get; set; }

    public Guid MaQuyTrinh { get; set; }

    public Guid MaSanPham { get; set; }

    public decimal SoLuong { get; set; }

    public DateTime NgayBatDau { get; set; }

    public DateTime NgayKetThuc { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? NguoiChiuTrachNhiem { get; set; }

    public Guid MaDinhMuc { get; set; }

    public string KhuVucSanXuat { get; set; } = null!;

    public virtual ICollection<ChiPhiSanXuat> ChiPhiSanXuats { get; set; } = new List<ChiPhiSanXuat>();

    public virtual KeHoachSanXuat? MaKeHoachNavigation { get; set; }

    public virtual QuyTrinhSanXuat? MaQuyTrinhNavigation { get; set; }

    public virtual SanPham? MaSanPhamNavigation { get; set; }
}
