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
using System.Data;

namespace ERP_backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LenhGoBoxController : ControllerBase
	{
		private readonly ILenhGoBoService _LenhGoBoService;

		public LenhGoBoxController(ILenhGoBoService LenhGoBo)
		{
			_LenhGoBoService = LenhGoBo;
		}

		// GET: api/LenhGoBox
		[HttpGet]
		public async Task<ActionResult<IEnumerable<LenhGoBoDto>>> GetLenhGoBos()
		{
			var result = await _LenhGoBoService.GetAll();
			return Ok(result);
		}

		// GET: api/LenhGoBox/5
		[HttpGet("{id}")]
		public async Task<ActionResult<LenhGoBoDto>> GetLenhGoBo(int id)
		{
			var LenhGoBo = await _LenhGoBoService.GetById(id);

			//if (BaoCaoSanXuat == null)
			//{
			//    return NotFound();
			//}

			return LenhGoBo;
		}

		// PUT: api/LenhGoBox/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutLenhGoBo(int id, LenhGoBoDto LenhGoBo)
		{
			if (id != LenhGoBo.MaLenhGoBo)
			{
				return BadRequest();
			}

			try
			{
				await _LenhGoBoService.Update(LenhGoBo);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _LenhGoBoService.GetById(id) == null)
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

		// POST: api/LenhGoBox
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<LenhGoBoDto>> PostLenhGoBo(LenhGoBoDto LenhGoBo)
		{

			var result = await _LenhGoBoService.Add(LenhGoBo);

			return CreatedAtAction("GetLenhGoBo", new { id = LenhGoBo.MaLenhGoBo }, LenhGoBo);
		}

		// DELETE: api/LenhGoBox/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteLenhGoBo(int id)
		{
			var LenhGoBo = await _LenhGoBoService.GetById(id);
			if (LenhGoBo == null)
			{
				return NotFound();
			}

			await _LenhGoBoService.Delete(LenhGoBo);

			return NoContent();
		}

		[HttpGet("get-lenhgobo")]
		public async Task<IActionResult> RenderLenhGoBo()
		{
			var result = await _LenhGoBoService.RenderLenhGoBo();
            return Ok(result);
        }

		[HttpPost("update-status")]
		public async Task<IActionResult> UpdateStatus(UpdateStatusLenhGoBo input)
		{
			var result = await _LenhGoBoService.UpdateStatus(input);
			return Ok(result);
		}

    }

	//private bool LenhGoBoExists(Guid id)
	//{
	//    return _context.LenhGoBos.Any(e => e.MaDinhMuc == id);
	//}
}
