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
	public class NhaCungCapController : ControllerBase
	{
		private readonly INhaCungCapService _NhaCungCapService;

		public NhaCungCapController(INhaCungCapService NhaCungCapService)
		{
			_NhaCungCapService = NhaCungCapService;
		}
		// GET: api/NhaCungCaps
		[HttpGet]
		//[Authorize(Roles = "Bộ phận bảo trì")]
		public async Task<ActionResult<IEnumerable<NhaCungCapDto>>> GetNhaCungCaps()
		{
			var result = await _NhaCungCapService.GetAll();
			return Ok(result);
		}

		// GET: api/NhaCungCaps/5
		[HttpGet("{id}")]
		//[Authorize(Roles = "Bộ phận bảo trì")]
		public async Task<ActionResult<NhaCungCapDto>> GetNhaCungCap(Guid id)
		{
			var NhaCungCap = await _NhaCungCapService.GetById(id);


			return NhaCungCap;
		}

		// PUT: api/NhaCungCaps/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		//[Authorize(Roles = "Bộ phận bảo trì")]
		public async Task<IActionResult> PutNhaCungCap(Guid id, NhaCungCapDto NhaCungCap)
		{
			if (id != NhaCungCap.MaNhaCungCap)
			{
				return BadRequest();
			}

			try
			{
				await _NhaCungCapService.Update(NhaCungCap);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _NhaCungCapService.GetById(id) == null)
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

		// POST: api/NhaCungCaps
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		//[Authorize(Roles = "Bộ phận bảo trì")]
		public async Task<ActionResult<NhaCungCapDto>> PostNhaCungCap(NhaCungCapDto NhaCungCap)
		{
			var result = await _NhaCungCapService.Add(NhaCungCap);

			return CreatedAtAction("GetNhaCungCap", new { id = NhaCungCap.MaNhaCungCap }, NhaCungCap);
		}

		// DELETE: api/NhaCungCaps/5
		[HttpDelete("{id}")]
		//[Authorize(Roles = "Bộ phận bảo trì")]
		public async Task<IActionResult> DeleteNhaCungCap(Guid id)
		{
			var NhaCungCap = await _NhaCungCapService.GetById(id);
			if (NhaCungCap == null)
			{
				return NotFound();
			}

			await _NhaCungCapService.Delete(NhaCungCap);

			return NoContent();
		}

		//private bool NhaCungCapExists(Guid id)
		//{
		//    return _context.NhaCungCaps.Any(e => e.MaNhaCungCap == id);
		//}
	}
}
