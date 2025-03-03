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
	public class KeHoachSanXuatxController : ControllerBase
	{
		private readonly IKeHoachSanXuatService _keHoachSanXuatService;

		public KeHoachSanXuatxController(IKeHoachSanXuatService keHoachSanXuat)
		{
			_keHoachSanXuatService = keHoachSanXuat;
		}

		// GET: api/KeHoachSanXuatx
		[HttpGet]
		public async Task<ActionResult<IEnumerable<KeHoachSanXuatDto>>> GetKeHoachSanXuats()
		{
			var result = await _keHoachSanXuatService.GetAll();
			return Ok(result);
		}

		// GET: api/KeHoachSanXuatx/5
		[HttpGet("{id}")]
		public async Task<ActionResult<KeHoachSanXuatDto>> GetKeHoachSanXuat(Guid id)
		{
			var KeHoachSanXuat = await _keHoachSanXuatService.GetById(id);

			//if (BaoCaoSanXuat == null)
			//{
			//    return NotFound();
			//}

			return KeHoachSanXuat;
		}

		// PUT: api/KeHoachSanXuatx/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutKeHoachSanXuat(Guid id, KeHoachSanXuatDto KeHoachSanXuat)
		{
			if (id != KeHoachSanXuat.MaKeHoach)
			{
				return BadRequest();
			}

			try
			{
				await _keHoachSanXuatService.Update(KeHoachSanXuat);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _keHoachSanXuatService.GetById(id) == null)
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

		// POST: api/KeHoachSanXuatx
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<KeHoachSanXuatDto>> PostKeHoachSanXuat(KeHoachSanXuatDto KeHoachSanXuat)
		{

			var result = await _keHoachSanXuatService.Add(KeHoachSanXuat);

			return CreatedAtAction("GetKeHoachSanXuat", new { id = KeHoachSanXuat.MaKeHoach }, KeHoachSanXuat);
		}

		// DELETE: api/KeHoachSanXuatx/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteKeHoachSanXuat(Guid id)
		{
			var KeHoachSanXuat = await _keHoachSanXuatService.GetById(id);
			if (KeHoachSanXuat == null)
			{
				return NotFound();
			}

			await _keHoachSanXuatService.Delete(KeHoachSanXuat);

			return NoContent();
		}
	}

	//private bool KeHoachSanXuatExists(Guid id)
	//{
	//    return _context.KeHoachSanXuats.Any(e => e.MaDinhMuc == id);
	//}
}

