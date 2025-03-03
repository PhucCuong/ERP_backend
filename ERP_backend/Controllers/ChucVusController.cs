using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERP_backend.Models;
using ERP_backend.Services;
using ERP_backend.Repositories;
using ERP_backend.DTOs;

namespace ERP_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVusController : ControllerBase
    {
		private readonly IChucVuService _chucVuService;

		public ChucVusController(IChucVuService chucVuService)
		{
			_chucVuService = chucVuService;
		}

		// GET: api/ChucVus
		[HttpGet]
        public async Task<ActionResult<IEnumerable<ChucVuDto>>> GetChucVus()
        {
			var result = await _chucVuService.GetAll();
			return Ok(result);
		}

        // GET: api/ChucVus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChucVuDto>> GetChucVu(Guid id)
        {
			var chucVu = await _chucVuService.GetById(id);

			//if (BaoCaoSanXuat == null)
			//{
			//    return NotFound();
			//}

			return chucVu;
		}

        // PUT: api/ChucVus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChucVu(Guid id, ChucVuDto chucVu)
        {
			if (id != chucVu.MaChucVu)
			{
				return BadRequest();
			}

			try
			{
				await _chucVuService.Update(chucVu);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _chucVuService.GetById(id) == null)
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

        // POST: api/ChucVus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChucVuDto>> PostChucVu(ChucVuDto chucVu)
        {
			var result = await _chucVuService.Add(chucVu);

			return CreatedAtAction("GetChucVu", new { id = chucVu.MaChucVu }, chucVu);
		}

        // DELETE: api/ChucVus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChucVu(Guid id)
        {
			var chucVu = await _chucVuService.GetById(id);
			if (chucVu == null)
			{
				return NotFound();
			}

			await _chucVuService.Delete(chucVu);

			return NoContent();
		}

        //private bool ChucVuExists(int id)
        //{
        //    return _context.ChucVus.Any(e => e.MaChucVu == id);
        //}
    }
}
