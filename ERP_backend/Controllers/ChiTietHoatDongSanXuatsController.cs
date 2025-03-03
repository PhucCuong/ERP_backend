using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERP_backend.Models;
using ERP_backend.Services;
using ERP_backend.DTOs;

namespace ERP_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietHoatDongSanXuatsController : ControllerBase
    {
		private readonly IChiTietHoatDongSanXuatService _chiTietHoatDongSanXuatService;

		public ChiTietHoatDongSanXuatsController(IChiTietHoatDongSanXuatService chiTietHoatDongSanXuatService)
		{
			_chiTietHoatDongSanXuatService = chiTietHoatDongSanXuatService;
		}

		// GET: api/ChiTietHoatDongSanXuats
		[HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietHoatDongSanXuatDto>>> GetChiTietHoatDongSanXuats()
        {
			var result = await _chiTietHoatDongSanXuatService.GetAll();
			return Ok(result);
		}

        // GET: api/ChiTietHoatDongSanXuats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietHoatDongSanXuatDto>> GetChiTietHoatDongSanXuat(Guid id)
        {
			var baoTri = await _chiTietHoatDongSanXuatService.GetById(id);


			return baoTri;
		}

        // PUT: api/ChiTietHoatDongSanXuats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietHoatDongSanXuat(Guid id, ChiTietHoatDongSanXuatDto chiTietHoatDongSanXuat)
        {
			if (id != chiTietHoatDongSanXuat.MaHoatDong)
			{
				return BadRequest();
			}

			try
			{
				await _chiTietHoatDongSanXuatService.Update(chiTietHoatDongSanXuat);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _chiTietHoatDongSanXuatService.GetById(id) == null)
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

        // POST: api/ChiTietHoatDongSanXuats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietHoatDongSanXuatDto>> PostChiTietHoatDongSanXuat(ChiTietHoatDongSanXuatDto chiTietHoatDongSanXuat)
        {
			var result = await _chiTietHoatDongSanXuatService.Add(chiTietHoatDongSanXuat);

			return CreatedAtAction("GetChiTietHoatDongSanXuat", new { id = chiTietHoatDongSanXuat.MaHoatDong }, chiTietHoatDongSanXuat);
		}

        // DELETE: api/ChiTietHoatDongSanXuats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietHoatDongSanXuat(Guid id)
        {
			var baoTri = await _chiTietHoatDongSanXuatService.GetById(id);
			if (baoTri == null)
			{
				return NotFound();
			}

			await _chiTietHoatDongSanXuatService.Delete(baoTri);

			return NoContent();
		}

        //private bool ChiTietHoatDongSanXuatExists(Guid id)
        //{
        //    return _context.ChiTietHoatDongSanXuats.Any(e => e.MaHoatDong == id);
        //}
    }
}
