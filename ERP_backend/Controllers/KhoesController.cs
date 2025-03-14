using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERP_backend.Models;
using ERP_backend.DTOs;
using ERP_backend.Services;
using Microsoft.AspNetCore.Authorization;

namespace ERP_backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class KhosController : ControllerBase
	{
		private readonly IKhoService _KhoService;

		public KhosController(IKhoService KhoService)
		{
			_KhoService = KhoService;
		}
		// GET: api/Khos
		[HttpGet]
		//[Authorize(Roles = "Bộ phận kho,Admin,Bộ phận sản xuất,Bộ phận kế hoạch,Bộ phận kỹ thuật")]
		public async Task<ActionResult<IEnumerable<KhoDto>>> GetKhos()
		{
			var result = await _KhoService.GetAll();
			return Ok(result);
		}

		// GET: api/Khos/5
		[HttpGet("{id}")]
		//[Authorize(Roles = "Bộ phận kho,Admin,Bộ phận sản xuất,Bộ phận kế hoạch,Bộ phận kỹ thuật")]
		public async Task<ActionResult<KhoDto>> GetKho(Guid id)
		{
			var Kho = await _KhoService.GetById(id);


			return Kho;
		}

		// PUT: api/Khos/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		//[Authorize(Roles = "Bộ phận kho,Admin")]
		public async Task<IActionResult> PutKho(Guid id, KhoDto Kho)
		{
			if (id != Kho.MaKho)
			{
				return BadRequest();
			}

			try
			{
				await _KhoService.Update(Kho);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _KhoService.GetById(id) == null)
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

		// POST: api/Khos
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		//[Authorize(Roles = "Bộ phận kho,Admin")]
		public async Task<ActionResult<KhoDto>> PostKho(KhoDto Kho)
		{
			var result = await _KhoService.Add(Kho);

			return CreatedAtAction("GetKho", new { id = Kho.MaKho }, Kho);
		}

		// DELETE: api/Khos/5
		[HttpDelete("{id}")]
		//[Authorize(Roles = "Bộ phận kho,Admin")]
		public async Task<IActionResult> DeleteKho(Guid id)
		{
			var Kho = await _KhoService.GetById(id);
			if (Kho == null)
			{
				return NotFound();
			}

			await _KhoService.Delete(Kho);

			return NoContent();
		}

		//private bool KhoExists(Guid id)
		//{
		//    return _context.Khos.Any(e => e.MaKho == id);
		//}
	}
}
