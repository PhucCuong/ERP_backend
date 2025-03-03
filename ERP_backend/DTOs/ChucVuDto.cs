using System;
using System.Collections.Generic;

namespace ERP_backend.DTOs;

public class ChucVuDto
{
    public Guid MaChucVu { get; set; }
	public string TenChucVu { get; set; } = null!;

    public virtual ICollection<UserDto> Users { get; set; } = new List<UserDto>();
}
