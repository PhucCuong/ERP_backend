﻿using System;
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
	public class NhapKhoxController : ControllerBase
	{
		private readonly INhapKhoService _NhapKhoService;

		public NhapKhoxController(INhapKhoService NhapKho)
		{
			_NhapKhoService = NhapKho;
		}

		// GET: api/NhapKhox
		[HttpGet]
		public async Task<ActionResult<IEnumerable<NhapKhoDto>>> GetNhapKhos()
		{
			var result = await _NhapKhoService.GetAll();
			return Ok(result);
		}

		// GET: api/NhapKhox/5
		[HttpGet("{id}")]
		public async Task<ActionResult<NhapKhoDto>> GetNhapKho(Guid id)
		{
			var NhapKho = await _NhapKhoService.GetById(id);

			//if (BaoCaoSanXuat == null)
			//{
			//    return NotFound();
			//}

			return NhapKho;
		}

		// PUT: api/NhapKhox/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutNhapKho(Guid id, NhapKhoDto NhapKho)
		{
			if (id != NhapKho.MaNhapKho)
			{
				return BadRequest();
			}

			try
			{
				await _NhapKhoService.Update(NhapKho);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _NhapKhoService.GetById(id) == null)
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

		// POST: api/NhapKhox
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<NhapKhoDto>> PostNhapKho(NhapKhoDto NhapKho)
		{

			var result = await _NhapKhoService.Add(NhapKho);

			return CreatedAtAction("GetNhapKho", new { id = NhapKho.MaNhapKho }, NhapKho);
		}

		// DELETE: api/NhapKhox/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteNhapKho(Guid id)
		{
			var NhapKho = await _NhapKhoService.GetById(id);
			if (NhapKho == null)
			{
				return NotFound();
			}

			await _NhapKhoService.Delete(NhapKho);

			return NoContent();
		}
	}

	//private bool NhapKhoExists(Guid id)
	//{
	//    return _context.NhapKhos.Any(e => e.MaDinhMuc == id);
	//}
}
