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

namespace ERP_backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TonKhosController : ControllerBase
	{
		private readonly ITonKhoService _TonKhoService;

		public TonKhosController(ITonKhoService TonKhoService)
		{
			_TonKhoService = TonKhoService;
		}
		// GET: api/TonKhos
		[HttpGet]
		public async Task<ActionResult<IEnumerable<TonKhoDto>>> GetTonKhos()
		{
			var result = await _TonKhoService.GetAll();
			return Ok(result);
		}

		// GET: api/TonKhos/5
		[HttpGet("{id}")]
		public async Task<ActionResult<TonKhoDto>> GetTonKho(Guid id)
		{
			var TonKho = await _TonKhoService.GetById(id);


			return TonKho;
		}

		// PUT: api/TonKhos/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutTonKho(Guid id, TonKhoDto TonKho)
		{
			if (id != TonKho.MaKho)
			{
				return BadRequest();
			}

			try
			{
				await _TonKhoService.Update(TonKho);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _TonKhoService.GetById(id) == null)
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

		// POST: api/TonKhos
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<TonKhoDto>> PostTonKho(TonKhoDto TonKho)
		{
			var result = await _TonKhoService.Add(TonKho);

			return CreatedAtAction("GetTonKho", new { id = TonKho.MaKho }, TonKho);
		}

		// DELETE: api/TonKhos/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTonKho(Guid id)
		{
			var TonKho = await _TonKhoService.GetById(id);
			if (TonKho == null)
			{
				return NotFound();
			}

			await _TonKhoService.Delete(TonKho);

			return NoContent();
		}

		//private bool TonKhoExists(Guid id)
		//{
		//    return _context.TonKhos.Any(e => e.MaTonKho == id);
		//}
	}
}
