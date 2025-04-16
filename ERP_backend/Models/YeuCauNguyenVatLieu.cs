using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class YeuCauNguyenVatLieu
{
    public Guid MaYeuCauNvl { get; set; }

    public int MaKeHoach { get; set; }

    public Guid MaNguyenVatLieu { get; set; }

    public decimal SoLuongCanThiet { get; set; }

    public Guid MaNhaCungCap { get; set; }

    public DateTime? NgayGiaoHangDuKien { get; set; }

    public string TrangThaiDonHang { get; set; } = null!;

    public DateTime? NgayTao { get; set; }

    public decimal? TongTien { get; set; }

    public virtual KeHoachSanXuat MaKeHoachNavigation { get; set; } = null!;

    public virtual NguyenVatLieu MaNguyenVatLieuNavigation { get; set; } = null!;
}
