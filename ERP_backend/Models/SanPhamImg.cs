using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class SanPhamImg
{
    public Guid ImageId { get; set; }

    public Guid MaSanPham { get; set; }

    public byte[]? ImgUrl { get; set; }

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
