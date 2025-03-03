using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class TonKho
{
    public Guid MaKho { get; set; }

    public Guid MaNguyenVatLieu { get; set; }

    public decimal SoLuongTon { get; set; }

    public decimal MucToiThieu { get; set; }

    public DateTime? NgayCapNhatCuoi { get; set; }

    public virtual Kho MaKhoNavigation { get; set; } = null!;

    public virtual NguyenVatLieu MaNguyenVatLieuNavigation { get; set; } = null!;
}
