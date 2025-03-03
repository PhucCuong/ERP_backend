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
	public class QuyTrinhSanXuatxController : ControllerBase
	{
		private readonly IQuyTrinhSanXuatService _QuyTrinhSanXuatService;

		public QuyTrinhSanXuatxController(IQuyTrinhSanXuatService QuyTrinhSanXuat)
		{
			_QuyTrinhSanXuatService = QuyTrinhSanXuat;
		}

		// GET: api/QuyTrinhSanXuatx
		[HttpGet]
		public async Task<ActionResult<IEnumerable<QuyTrinhSanXuatDto>>> GetQuyTrinhSanXuats()
		{
			var result = await _QuyTrinhSanXuatService.GetAll();
			return Ok(result);
		}

		// GET: api/QuyTrinhSanXuatx/5
		[HttpGet("{id}")]
		public async Task<ActionResult<QuyTrinhSanXuatDto>> GetQuyTrinhSanXuat(Guid id)
		{
			var QuyTrinhSanXuat = await _QuyTrinhSanXuatService.GetById(id);

			//if (BaoCaoSanXuat == null)
			//{
			//    return NotFound();
			//}

			return QuyTrinhSanXuat;
		}

		// PUT: api/QuyTrinhSanXuatx/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutQuyTrinhSanXuat(Guid id, QuyTrinhSanXuatDto QuyTrinhSanXuat)
		{
			if (id != QuyTrinhSanXuat.MaQuyTrinh)
			{
				return BadRequest();
			}

			try
			{
				await _QuyTrinhSanXuatService.Update(QuyTrinhSanXuat);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _QuyTrinhSanXuatService.GetById(id) == null)
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

		// POST: api/QuyTrinhSanXuatx
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<QuyTrinhSanXuatDto>> PostQuyTrinhSanXuat(QuyTrinhSanXuatDto QuyTrinhSanXuat)
		{

			var result = await _QuyTrinhSanXuatService.Add(QuyTrinhSanXuat);

			return CreatedAtAction("GetQuyTrinhSanXuat", new { id = QuyTrinhSanXuat.MaQuyTrinh }, QuyTrinhSanXuat);
		}

		// DELETE: api/QuyTrinhSanXuatx/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteQuyTrinhSanXuat(Guid id)
		{
			var QuyTrinhSanXuat = await _QuyTrinhSanXuatService.GetById(id);
			if (QuyTrinhSanXuat == null)
			{
				return NotFound();
			}

			await _QuyTrinhSanXuatService.Delete(QuyTrinhSanXuat);

			return NoContent();
		}
	}

	//private bool QuyTrinhSanXuatExists(Guid id)
	//{
	//    return _context.QuyTrinhSanXuats.Any(e => e.MaDinhMuc == id);
	//}
}
