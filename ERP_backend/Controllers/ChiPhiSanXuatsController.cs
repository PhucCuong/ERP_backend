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

namespace erp_backend.controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ChiPhiSanXuatsController : ControllerBase
	{
		private readonly IChiPhiSanXuatService _ChiPhiSanXuatService;

		public ChiPhiSanXuatsController(IChiPhiSanXuatService chiPhiSanXuatService)
		{
			_ChiPhiSanXuatService = chiPhiSanXuatService;
		}

		// GET: api/BaoCaoSanXuats
		[HttpGet]
		//[Authorize(Roles = "Bộ phận kế toán")]
		public async Task<ActionResult<IEnumerable<ChiPhiSanXuatDto>>> GetChiPhiSanXuats()
		{
			var result = await _ChiPhiSanXuatService.GetAll();
			return Ok(result);
		}

		// GET: api/BaoCaoSanXuats/5
		[HttpGet("{id}")]
		//[Authorize(Roles = "Bộ phận kế toán")]
		public async Task<ActionResult<ChiPhiSanXuatDto>> GetChiPhiSanXuat(Guid id)
		{
			var chiPhiSanXuat= await _ChiPhiSanXuatService.GetById(id);

			//if (BaoCaoSanXuat == null)
			//{
			//    return NotFound();
			//}

			return chiPhiSanXuat;
		}

		// PUT: api/BaoCaoSanXuats/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		//[Authorize(Roles = "Bộ phận kế toán")]
		public async Task<IActionResult> PutChiPhiSanXuat(Guid id, ChiPhiSanXuatDto chiPhiSanXuat)
		{
			if (id != chiPhiSanXuat.MaChiPhiSanXuat)
			{
				return BadRequest();
			}

			try
			{
				await _ChiPhiSanXuatService.Update(chiPhiSanXuat);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _ChiPhiSanXuatService.GetById(id) == null)
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

		// POST: api/BaoCaoSanXuats
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		//[Authorize(Roles = "Bộ phận kế toán")]
		public async Task<ActionResult<ChiPhiSanXuatDto>> PostBaoCaoSanXuat(ChiPhiSanXuatDto chiPhiSanXuat)
		{
			var result = await _ChiPhiSanXuatService.Add(chiPhiSanXuat);

			return CreatedAtAction("GetChiPhiSanXuat", new { id = chiPhiSanXuat.MaChiPhiSanXuat }, chiPhiSanXuat);
		}

		// DELETE: api/BaoCaoSanXuats/5
		[HttpDelete("{id}")]
		//[Authorize(Roles = "Bộ phận kế toán")]
		public async Task<IActionResult> DeleteChiPhiSanXuat(Guid id)
		{
			var chiPhiSanXuat = await _ChiPhiSanXuatService.GetById(id);
			if (chiPhiSanXuat == null)
			{
				return NotFound();
			}

			await _ChiPhiSanXuatService.Delete(chiPhiSanXuat);

			return NoContent();
		}

		//private bool BaoCaoSanXuatExists(Guid id)
		//{
		//    return _BaoCaoSanXuatService.Any(e => e.MaBaoCao == id);
		//}
	}
}
