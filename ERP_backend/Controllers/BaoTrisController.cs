using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERP_backend.Models;
using ERP_backend.DTOs;
using ERP_backend.Services;

namespace ERP_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaoTrisController : ControllerBase
    {
		private readonly IBaoTriService _baoTriService;

		public BaoTrisController(IBaoTriService baoTriService)
		{
			_baoTriService = baoTriService;
		}
		// GET: api/BaoTris
		[HttpGet]
        public async Task<ActionResult<IEnumerable<BaoTriDto>>> GetBaoTris()
        {
			var result = await _baoTriService.GetAll();
			return Ok(result);
		}

        // GET: api/BaoTris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaoTriDto>> GetBaoTri(Guid id)
        {
			var baoTri = await _baoTriService.GetById(id);

			
			return baoTri;
		}

        // PUT: api/BaoTris/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaoTri(Guid id, BaoTriDto baoTri)
        {
            if (id != baoTri.MaBaoTri)
            {
                return BadRequest();
            }       

            try
            {
				await _baoTriService.Update(baoTri);
			}
            catch (DbUpdateConcurrencyException)
            {
                if (await _baoTriService.GetById(id) == null)
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

        // POST: api/BaoTris
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BaoTriDto>> PostBaoTri(BaoTriDto baoTri)
        {
			var result = await _baoTriService.Add(baoTri);

			return CreatedAtAction("GetBaoTri", new { id = baoTri.MaBaoTri }, baoTri);
		}

        // DELETE: api/BaoTris/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaoTri(Guid id)
        {
			var baoTri = await _baoTriService.GetById(id);
			if (baoTri == null)
			{
				return NotFound();
			}

			await _baoTriService.Delete(baoTri);

			return NoContent();
		}

        //private bool BaoTriExists(Guid id)
        //{
        //    return _context.BaoTris.Any(e => e.MaBaoTri == id);
        //}
    }
}
