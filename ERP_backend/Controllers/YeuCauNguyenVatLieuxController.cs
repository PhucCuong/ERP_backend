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
	public class YeuCauNguyenVatLieuxController : ControllerBase
	{
		private readonly IYeuCauNguyenVatLieuService _YeuCauNguyenVatLieuService;

		public YeuCauNguyenVatLieuxController(IYeuCauNguyenVatLieuService YeuCauNguyenVatLieu)
		{
			_YeuCauNguyenVatLieuService = YeuCauNguyenVatLieu;
		}

		// GET: api/YeuCauNguyenVatLieux
		[HttpGet]
		public async Task<ActionResult<IEnumerable<YeuCauNguyenVatLieuDto>>> GetYeuCauNguyenVatLieus()
		{
			var result = await _YeuCauNguyenVatLieuService.GetAll();
			return Ok(result);
		}

		// GET: api/YeuCauNguyenVatLieux/5
		[HttpGet("{id}")]
		public async Task<ActionResult<YeuCauNguyenVatLieuDto>> GetYeuCauNguyenVatLieu(Guid id)
		{
			var YeuCauNguyenVatLieu = await _YeuCauNguyenVatLieuService.GetById(id);

			//if (BaoCaoSanXuat == null)
			//{
			//    return NotFound();
			//}

			return YeuCauNguyenVatLieu;
		}

		// PUT: api/YeuCauNguyenVatLieux/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutYeuCauNguyenVatLieu(Guid id, YeuCauNguyenVatLieuDto YeuCauNguyenVatLieu)
		{
			if (id != YeuCauNguyenVatLieu.MaYeuCauNvl)
			{
				return BadRequest();
			}

			try
			{
				await _YeuCauNguyenVatLieuService.Update(YeuCauNguyenVatLieu);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _YeuCauNguyenVatLieuService.GetById(id) == null)
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

		// POST: api/YeuCauNguyenVatLieux
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<YeuCauNguyenVatLieuDto>> PostYeuCauNguyenVatLieu(YeuCauNguyenVatLieuDto YeuCauNguyenVatLieu)
		{

			var result = await _YeuCauNguyenVatLieuService.Add(YeuCauNguyenVatLieu);

			return CreatedAtAction("GetYeuCauNguyenVatLieu", new { id = YeuCauNguyenVatLieu.MaYeuCauNvl }, YeuCauNguyenVatLieu);
		}

		// DELETE: api/YeuCauNguyenVatLieux/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteYeuCauNguyenVatLieu(Guid id)
		{
			var YeuCauNguyenVatLieu = await _YeuCauNguyenVatLieuService.GetById(id);
			if (YeuCauNguyenVatLieu == null)
			{
				return NotFound();
			}

			await _YeuCauNguyenVatLieuService.Delete(YeuCauNguyenVatLieu);

			return NoContent();
		}
	}

	//private bool YeuCauNguyenVatLieuExists(Guid id)
	//{
	//    return _context.YeuCauNguyenVatLieus.Any(e => e.MaDinhMuc == id);
	//}
}
