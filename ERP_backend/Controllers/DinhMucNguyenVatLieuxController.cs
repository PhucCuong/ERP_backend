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
    public class DinhMucNguyenVatLieuxController : ControllerBase
    {
		private readonly IDinhMucNguyenVatLieuService _dinhMucNguyenVatLieuService;

		public DinhMucNguyenVatLieuxController(IDinhMucNguyenVatLieuService dinhMucNguyenVatLieu)
		{
			_dinhMucNguyenVatLieuService = dinhMucNguyenVatLieu;
		}

		// GET: api/DinhMucNguyenVatLieux
		[HttpGet]
        public async Task<ActionResult<IEnumerable<DinhMucNguyenVatLieuDto>>> GetDinhMucNguyenVatLieus()
        {
			var result = await _dinhMucNguyenVatLieuService.GetAll();
			return Ok(result);
		}

        // GET: api/DinhMucNguyenVatLieux/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DinhMucNguyenVatLieuDto>> GetDinhMucNguyenVatLieu(Guid id)
        {
			var dinhMucNguyenVatLieu = await _dinhMucNguyenVatLieuService.GetById(id);

			//if (BaoCaoSanXuat == null)
			//{
			//    return NotFound();
			//}

			return dinhMucNguyenVatLieu;
		}

        // PUT: api/DinhMucNguyenVatLieux/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDinhMucNguyenVatLieu(Guid id, DinhMucNguyenVatLieuDto dinhMucNguyenVatLieu)
        {
			if (id != dinhMucNguyenVatLieu.MaDinhMuc)
			{
				return BadRequest();
			}

			try
			{
				await _dinhMucNguyenVatLieuService.Update(dinhMucNguyenVatLieu);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _dinhMucNguyenVatLieuService.GetById(id) == null)
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

        // POST: api/DinhMucNguyenVatLieux
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DinhMucNguyenVatLieuDto>> PostDinhMucNguyenVatLieu(DinhMucNguyenVatLieuDto dinhMucNguyenVatLieu)
        {

			var result = await _dinhMucNguyenVatLieuService.Add(dinhMucNguyenVatLieu);

			return CreatedAtAction("GetDinhMucNguyenVatLieu", new { id = dinhMucNguyenVatLieu.MaDinhMuc }, dinhMucNguyenVatLieu);
		}

        // DELETE: api/DinhMucNguyenVatLieux/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDinhMucNguyenVatLieu(Guid id)
        {
			var dinhMucNguyenVatLieu = await _dinhMucNguyenVatLieuService.GetById(id);
			if (dinhMucNguyenVatLieu == null)
			{
				return NotFound();
			}

			await _dinhMucNguyenVatLieuService.Delete(dinhMucNguyenVatLieu);

			return NoContent();
		}
	}

        //private bool DinhMucNguyenVatLieuExists(Guid id)
        //{
        //    return _context.DinhMucNguyenVatLieus.Any(e => e.MaDinhMuc == id);
        //}
    }

