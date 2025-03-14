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
	public class NhaMayxController : ControllerBase
	{
		private readonly INhaMayService _NhaMayService;

		public NhaMayxController(INhaMayService NhaMay)
		{
			_NhaMayService = NhaMay;
		}

		// GET: api/NhaMayx
		[HttpGet]
		//[Authorize(Roles = "Bộ phận kho,Admin,Bộ phận sản xuất,Bộ phận kế hoạch,Bộ phận kỹ thuật")]
		public async Task<ActionResult<IEnumerable<NhaMayDto>>> GetNhaMays()
		{
			var result = await _NhaMayService.GetAll();
			return Ok(result);
		}

		// GET: api/NhaMayx/5
		[HttpGet("{id}")]
		//[Authorize(Roles = "Bộ phận kho,Admin,Bộ phận sản xuất,Bộ phận kế hoạch,Bộ phận kỹ thuật")]
		public async Task<ActionResult<NhaMayDto>> GetNhaMay(Guid id)
		{
			var NhaMay = await _NhaMayService.GetById(id);

			//if (BaoCaoSanXuat == null)
			//{
			//    return NotFound();
			//}

			return NhaMay;
		}

		// PUT: api/NhaMayx/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		//[Authorize(Roles = "Admin")]
		public async Task<IActionResult> PutNhaMay(Guid id, NhaMayDto NhaMay)
		{
			if (id != NhaMay.MaNhaMay)
			{
				return BadRequest();
			}

			try
			{
				await _NhaMayService.Update(NhaMay);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _NhaMayService.GetById(id) == null)
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

		// POST: api/NhaMayx
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		//[Authorize(Roles = "Admin")]
		public async Task<ActionResult<NhaMayDto>> PostNhaMay(NhaMayDto NhaMay)
		{

			var result = await _NhaMayService.Add(NhaMay);

			return CreatedAtAction("GetNhaMay", new { id = NhaMay.MaNhaMay }, NhaMay);
		}

		// DELETE: api/NhaMayx/5
		[HttpDelete("{id}")]
		//[Authorize(Roles = "Admin")]
		public async Task<IActionResult> DeleteNhaMay(Guid id)
		{
			var NhaMay = await _NhaMayService.GetById(id);
			if (NhaMay == null)
			{
				return NotFound();
			}

			await _NhaMayService.Delete(NhaMay);

			return NoContent();
		}
	}

	//private bool NhaMayExists(Guid id)
	//{
	//    return _context.NhaMays.Any(e => e.MaDinhMuc == id);
	//}
}
