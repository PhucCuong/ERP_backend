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
	public class LenhSanXuatxController : ControllerBase
	{
		private readonly ILenhSanXuatService _LenhSanXuatService;

		public LenhSanXuatxController(ILenhSanXuatService LenhSanXuat)
		{
			_LenhSanXuatService = LenhSanXuat;
		}

		// GET: api/LenhSanXuatx
		[HttpGet]
		public async Task<ActionResult<IEnumerable<LenhSanXuatDto>>> GetLenhSanXuats()
		{
			var result = await _LenhSanXuatService.GetAll();
			return Ok(result);
		}

		// GET: api/LenhSanXuatx/5
		[HttpGet("{id}")]
		public async Task<ActionResult<LenhSanXuatDto>> GetLenhSanXuat(Guid id)
		{
			var LenhSanXuat = await _LenhSanXuatService.GetById(id);

			//if (BaoCaoSanXuat == null)
			//{
			//    return NotFound();
			//}

			return LenhSanXuat;
		}

		// PUT: api/LenhSanXuatx/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutLenhSanXuat(Guid id, LenhSanXuatDto LenhSanXuat)
		{
			if (id != LenhSanXuat.MaLenh)
			{
				return BadRequest();
			}

			try
			{
				await _LenhSanXuatService.Update(LenhSanXuat);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _LenhSanXuatService.GetById(id) == null)
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

		// POST: api/LenhSanXuatx
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<LenhSanXuatDto>> PostLenhSanXuat(LenhSanXuatDto LenhSanXuat)
		{

			var result = await _LenhSanXuatService.Add(LenhSanXuat);

			return CreatedAtAction("GetLenhSanXuat", new { id = LenhSanXuat.MaLenh }, LenhSanXuat);
		}

		// DELETE: api/LenhSanXuatx/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteLenhSanXuat(Guid id)
		{
			var LenhSanXuat = await _LenhSanXuatService.GetById(id);
			if (LenhSanXuat == null)
			{
				return NotFound();
			}

			await _LenhSanXuatService.Delete(LenhSanXuat);

			return NoContent();
		}
    }

    //private bool LenhSanXuatExists(Guid id)
    //{
    //    return _context.LenhSanXuats.Any(e => e.MaDinhMuc == id);
    //}
}
