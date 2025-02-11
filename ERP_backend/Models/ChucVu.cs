using System;
using System.Collections.Generic;

namespace ERP_backend.Models;

public partial class ChucVu
{
    public int MaChucVu { get; set; }

    public string TenChucVu { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
