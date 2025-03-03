using System;
using System.Collections.Generic;

namespace ERP_backend.DTOs;

	public class SanPhamImgDto
	{
		public Guid ImageId { get; set; }

		public Guid MaSanPham { get; set; }

	public string? ImgUrl { get; set; }


	public virtual SanPhamDto? MaSanPhamNavigation { get; set; }
	}

