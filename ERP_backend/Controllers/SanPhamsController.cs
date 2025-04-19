using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERP_backend.Models;
using ERP_backend.DTOs;
using ERP_backend.Repositories;
using ERP_backend.Services;
using Microsoft.AspNetCore.Authorization;

namespace ERP_backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SanPhamxController : ControllerBase
	{
		private readonly ISanPhamService _SanPhamService;

		public SanPhamxController(ISanPhamService SanPham)
		{
			_SanPhamService = SanPham;
		}

		// GET: api/SanPhamx
		[HttpGet]
		//[Authorize(Roles = "Bộ phận kho,Admin,Bộ phận sản xuất,Bộ phận kế hoạch,Bộ phận kỹ thuật,Bộ phận bán hàng,Bộ phận kho,Bộ phận kế hoạch,Admin")]
		public async Task<ActionResult<IEnumerable<SanPhamDto>>> GetSanPhams()
		{
			var result = await _SanPhamService.GetAll();
			return Ok(result);
		}

		// GET: api/SanPhamx/5
		[HttpGet("{id}")]
		//[Authorize(Roles = "Bộ phận kho,Admin,Bộ phận sản xuất,Bộ phận kế hoạch,Bộ phận kỹ thuật,Bộ phận bán hàng,Bộ phận kho,Bộ phận kế hoạch,Admin")]
		public async Task<ActionResult<SanPhamDto>> GetSanPham(Guid id)
		{
			var SanPham = await _SanPhamService.GetById(id);

			//if (BaoCaoSanXuat == null)
			//{
			//    return NotFound();
			//}

			return SanPham;
		}

		// PUT: api/SanPhamx/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		//[Authorize(Roles = "Bộ phận kỹ thuật")]
		public async Task<IActionResult> PutSanPham(Guid id, SanPhamDto SanPham)
		{
			if (id != SanPham.MaSanPham)
			{
				return BadRequest();
			}

			try
			{
				await _SanPhamService.Update(SanPham);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _SanPhamService.GetById(id) == null)
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/SanPhamx
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		
		[HttpPost]
		//[Authorize(Roles = "Bộ phận kỹ thuật")]
		public async Task<ActionResult<SanPhamDto>> PostSanPham( SanPhamDto sanPham)
		{
			
	
			var result = await _SanPhamService.Add(sanPham);
			//return CreatedAtAction("GetSanPham", new { id = sanPham.MaSanPham },sanPham);
			return Ok(result);
		}
		

		// DELETE: api/SanPhamx/5
		[HttpDelete("{id}")]
		////[Authorize(Roles = "Bộ phận kỹ thuật")]
		public async Task<IActionResult> DeleteSanPham(Guid id)
		{
			var SanPham = await _SanPhamService.GetById(id);
			if (SanPham == null)
			{
				return NotFound();
			}

			await _SanPhamService.Delete(SanPham);

			return NoContent();
		}
	}

	//private bool SanPhamExists(Guid id)
	//{
	//    return _context.SanPhams.Any(e => e.MaDinhMuc == id);
	//}
}
