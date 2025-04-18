using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class YeuCauNguyenVatLieu
{
    public Guid MaYeuCauNvl { get; set; }

    public Guid MaNguyenVatLieu { get; set; }

    public decimal SoLuongCanThiet { get; set; }

    public Guid MaNhaCungCap { get; set; }

    public DateTime? NgayGiaoHangDuKien { get; set; }

    public DateTime? NgayTao { get; set; }

    public decimal? TongTien { get; set; }

    public virtual NguyenVatLieu MaNguyenVatLieuNavigation { get; set; } = null!;
}
