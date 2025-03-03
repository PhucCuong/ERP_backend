using System;
using System.Collections.Generic;

namespace ERP_backend.DTOs;

public class YeuCauNguyenVatLieuDto
{
    public Guid MaYeuCauNvl { get; set; }

    public Guid MaKeHoach { get; set; }

    public Guid MaNguyenVatLieu { get; set; }

    public decimal SoLuongCanThiet { get; set; }

    public Guid MaNhaCungCap { get; set; }

    public DateTime? NgayGiaoHangDuKien { get; set; }

    public string TrangThaiDonHang { get; set; } = null!;

    public DateTime? NgayTao { get; set; }

    public virtual KeHoachSanXuatDto MaKeHoachNavigation { get; set; } = null!;

    public virtual NguyenVatLieuDto MaNguyenVatLieuNavigation { get; set; } = null!;
}
