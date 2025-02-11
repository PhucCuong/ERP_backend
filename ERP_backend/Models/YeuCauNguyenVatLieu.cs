using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class YeuCauNguyenVatLieu
{
    public Guid MaYeuCauNvl { get; set; }

    public Guid MaKeHoach { get; set; }

    public int MaNguyenVatLieu { get; set; }

    public decimal SoLuongCanThiet { get; set; }

    public int? MaNhaCungCap { get; set; }

    public DateTime? NgayGiaoHangDuKien { get; set; }

    public string TrangThaiDonHang { get; set; } = null!;

    public DateTime? NgayTao { get; set; }

    public virtual KeHoachSanXuat MaKeHoachNavigation { get; set; } = null!;

    public virtual NguyenVatLieu MaNguyenVatLieuNavigation { get; set; } = null!;
}
