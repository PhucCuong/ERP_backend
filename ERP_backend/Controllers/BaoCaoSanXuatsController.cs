using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERP_backend.Models;
using ERP_backend.Repositories;
using ERP_backend.Services;
using ERP_backend.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace ERP_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaoCaoSanXuatsController : ControllerBase
    {
		private readonly IBaoCaoSanXuatService _BaoCaoSanXuatService;

		public BaoCaoSanXuatsController(IBaoCaoSanXuatService BaoCaoSanXuatService)
        {
			_BaoCaoSanXuatService = BaoCaoSanXuatService;
        }


        [HttpGet("tien-do-san-xuat")]
        public async Task<ActionResult<BaoCaoTongHopSanXuat>> GetTienDoSanXuat()
        {
            var result = await _BaoCaoSanXuatService.GetTienDoSanXuat();
            return Ok(result);
        }


        [HttpGet("tong-quan-san-pham")]
        public async Task<ActionResult<BaoCaoSanPhamSanXuat>> GetTongQuanSoLuongSanPham()
        {
            var result = await _BaoCaoSanXuatService.GetTongQuanSoLuongSanPham();
            return Ok(result);
        }
    }
}
