using System;
using System.Collections.Generic;

namespace ERP_backend.DTOs;

public class YeuCauNguyenVatLieuDto
{
    public Guid MaYeuCauNvl { get; set; }

    public int MaKeHoach { get; set; }

    public Guid MaNguyenVatLieu { get; set; }

    public decimal SoLuongCanThiet { get; set; }

    public Guid MaNhaCungCap { get; set; }

    public DateTime? NgayGiaoHangDuKien { get; set; }

    public DateTime? NgayTao { get; set; }

}
