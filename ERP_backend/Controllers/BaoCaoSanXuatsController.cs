using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERP_backend.Models;
using ERP_backend.Repositories;
using ERP_backend.Services;
using ERP_backend.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace ERP_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaoCaoSanXuatsController : ControllerBase
    {
		private readonly IBaoCaoSanXuatService _BaoCaoSanXuatService;

		public BaoCaoSanXuatsController(IBaoCaoSanXuatService BaoCaoSanXuatService)
        {
			_BaoCaoSanXuatService = BaoCaoSanXuatService;
        }

        // GET: api/BaoCaoSanXuats
        [HttpGet]
		
		public async Task<ActionResult<IEnumerable<BaoCaoSanXuatDto>>> GetBaoCaoSanXuats()
        {
            var result = await _BaoCaoSanXuatService.GetAll();
            return Ok(result);
        }

        // GET: api/BaoCaoSanXuats/5
        [HttpGet("{id}")]
		
		public async Task<ActionResult<BaoCaoSanXuatDto>> GetBaoCaoSanXuat(int id)
        {
            var BaoCaoSanXuat = await _BaoCaoSanXuatService.GetById(id);

            //if (BaoCaoSanXuat == null)
            //{
            //    return NotFound();
            //}

            return BaoCaoSanXuat;
        }

        // PUT: api/BaoCaoSanXuats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
		[Authorize(Roles = "Bộ phận sản xuất")]
		public async Task<IActionResult> PutBaoCaoSanXuat(int id, BaoCaoSanXuatDto BaoCaoSanXuat)
        {
            if (id != BaoCaoSanXuat.MaBaoCao)
            {
                return BadRequest();
            }

            try
            {
                await _BaoCaoSanXuatService.Update(BaoCaoSanXuat);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _BaoCaoSanXuatService.GetById(id) == null)
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

        // POST: api/BaoCaoSanXuats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

		public async Task<ActionResult<BaoCaoSanXuatDto>> PostBaoCaoSanXuat(BaoCaoSanXuatDto BaoCaoSanXuat)
        {
            var result = await _BaoCaoSanXuatService.Add(BaoCaoSanXuat);

            return CreatedAtAction("GetBaoCaoSanXuat", new { id = BaoCaoSanXuat.MaBaoCao }, BaoCaoSanXuat);
        }

        // DELETE: api/BaoCaoSanXuats/5
        [HttpDelete("{id}")]

		public async Task<IActionResult> DeleteBaoCaoSanXuat(int id)
        {
            var BaoCaoSanXuat = await _BaoCaoSanXuatService.GetById(id);
            if (BaoCaoSanXuat == null)
            {
                return NotFound();
            }

			await _BaoCaoSanXuatService.Delete(BaoCaoSanXuat);

            return NoContent();
        }

        //private bool BaoCaoSanXuatExists(Guid id)
        //{
        //    return _BaoCaoSanXuatService.Any(e => e.MaBaoCao == id);
        //}
    }
}
