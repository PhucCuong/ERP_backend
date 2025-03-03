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

namespace ERP_backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class KiemTraChatLuongxController : ControllerBase
	{
		private readonly IKiemTraChatLuongService _KiemTraChatLuongService;

		public KiemTraChatLuongxController(IKiemTraChatLuongService KiemTraChatLuong)
		{
			_KiemTraChatLuongService = KiemTraChatLuong;
		}

		// GET: api/KiemTraChatLuongx
		[HttpGet]
		public async Task<ActionResult<IEnumerable<KiemTraChatLuongDto>>> GetKiemTraChatLuongs()
		{
			var result = await _KiemTraChatLuongService.GetAll();
			return Ok(result);
		}

		// GET: api/KiemTraChatLuongx/5
		[HttpGet("{id}")]
		public async Task<ActionResult<KiemTraChatLuongDto>> GetKiemTraChatLuong(Guid id)
		{
			var KiemTraChatLuong = await _KiemTraChatLuongService.GetById(id);

			//if (BaoCaoSanXuat == null)
			//{
			//    return NotFound();
			//}

			return KiemTraChatLuong;
		}

		// PUT: api/KiemTraChatLuongx/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutKiemTraChatLuong(Guid id, KiemTraChatLuongDto KiemTraChatLuong)
		{
			if (id != KiemTraChatLuong.MaKiemTra)
			{
				return BadRequest();
			}

			try
			{
				await _KiemTraChatLuongService.Update(KiemTraChatLuong);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _KiemTraChatLuongService.GetById(id) == null)
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

		// POST: api/KiemTraChatLuongx
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<KiemTraChatLuongDto>> PostKiemTraChatLuong(KiemTraChatLuongDto KiemTraChatLuong)
		{

			var result = await _KiemTraChatLuongService.Add(KiemTraChatLuong);

			return CreatedAtAction("GetKiemTraChatLuong", new { id = KiemTraChatLuong.MaKiemTra }, KiemTraChatLuong);
		}

		// DELETE: api/KiemTraChatLuongx/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteKiemTraChatLuong(Guid id)
		{
			var KiemTraChatLuong = await _KiemTraChatLuongService.GetById(id);
			if (KiemTraChatLuong == null)
			{
				return NotFound();
			}

			await _KiemTraChatLuongService.Delete(KiemTraChatLuong);

			return NoContent();
		}
	}

	//private bool KiemTraChatLuongExists(Guid id)
	//{
	//    return _context.KiemTraChatLuongs.Any(e => e.MaDinhMuc == id);
	//}
}
