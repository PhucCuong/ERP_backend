using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class KiemTraChatLuong
{
    public Guid MaKiemTra { get; set; }

    public Guid MaSanPham { get; set; }

    public DateTime NgayKiemTra { get; set; }

    public string? MoTa { get; set; }

    public string? DoiKiemTra { get; set; }

    public string? NguoiPhuTrach { get; set; }

    public string KetQua { get; set; } = null!;

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayChinhSua { get; set; }

    public virtual ICollection<KetQuaKiemTra> KetQuaKiemTras { get; set; } = new List<KetQuaKiemTra>();

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
