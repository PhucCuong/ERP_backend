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
	public class NguyenVatLieuxController : ControllerBase
	{
		private readonly INguyenVatLieuService _NguyenVatLieuService;

		public NguyenVatLieuxController(INguyenVatLieuService NguyenVatLieu)
		{
			_NguyenVatLieuService = NguyenVatLieu;
		}

		// GET: api/NguyenVatLieux
		[HttpGet]
		public async Task<ActionResult<IEnumerable<NguyenVatLieuDto>>> GetNguyenVatLieus()
		{
			var result = await _NguyenVatLieuService.GetAll();
			return Ok(result);
		}

		// GET: api/NguyenVatLieux/5
		[HttpGet("{id}")]
		public async Task<ActionResult<NguyenVatLieuDto>> GetNguyenVatLieu(Guid id)
		{
			var NguyenVatLieu = await _NguyenVatLieuService.GetById(id);

			//if (BaoCaoSanXuat == null)
			//{
			//    return NotFound();
			//}

			return NguyenVatLieu;
		}

		// PUT: api/NguyenVatLieux/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutNguyenVatLieu(Guid id, NguyenVatLieuDto NguyenVatLieu)
		{
			if (id != NguyenVatLieu.MaNguyenVatLieu)
			{
				return BadRequest();
			}

			try
			{
				await _NguyenVatLieuService.Update(NguyenVatLieu);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _NguyenVatLieuService.GetById(id) == null)
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

		// POST: api/NguyenVatLieux
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<NguyenVatLieuDto>> PostNguyenVatLieu(NguyenVatLieuDto NguyenVatLieu)
		{

			var result = await _NguyenVatLieuService.Add(NguyenVatLieu);

			return CreatedAtAction("GetNguyenVatLieu", new { id = NguyenVatLieu.MaNguyenVatLieu }, NguyenVatLieu);
		}

		// DELETE: api/NguyenVatLieux/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteNguyenVatLieu(Guid id)
		{
			var NguyenVatLieu = await _NguyenVatLieuService.GetById(id);
			if (NguyenVatLieu == null)
			{
				return NotFound();
			}

			await _NguyenVatLieuService.Delete(NguyenVatLieu);

			return NoContent();
		}
	}

	//private bool NguyenVatLieuExists(Guid id)
	//{
	//    return _context.NguyenVatLieus.Any(e => e.MaDinhMuc == id);
	//}
}
