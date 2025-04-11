using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class KetQuaKiemTra
{
    public Guid KetQuaId { get; set; }

    public Guid MaKiemTra { get; set; }

    public string KetQua { get; set; } = null!;

    public string? GhiChu { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual KiemTraChatLuong MaKiemTraNavigation { get; set; } = null!;
}
