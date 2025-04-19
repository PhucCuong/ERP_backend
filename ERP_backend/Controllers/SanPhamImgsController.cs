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
using Microsoft.IdentityModel.Tokens;


namespace ERP_backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SanPhamImgsController : ControllerBase
	{
		private readonly ISanPhamImgService _sanPhamImgService;
		private readonly IWebHostEnvironment environment;
		public SanPhamImgsController(ISanPhamImgService sanPhamImgService, IWebHostEnvironment environment)
		{
			_sanPhamImgService = sanPhamImgService;
			this.environment = environment;
		}
		// GET: api/BaoTris
		[HttpGet]
		public async Task<ActionResult<IEnumerable<SanPhamImgDto>>> GetSanPhamImgs()
		{
			var result = await _sanPhamImgService.GetAll();
			return Ok(result);
		}

		// GET: api/BaoTris/5
		[HttpGet("{id}")]
		public async Task<ActionResult<SanPhamImgDto>> GetSanPhamImg(Guid id)
		{
			var sanPhamImg = await _sanPhamImgService.GetById(id);


			return sanPhamImg;
		}

		// PUT: api/BaoTris/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutSanPhamImg(Guid id, SanPhamImgDto SanPhamImg)
		{
			if (id != SanPhamImg.ImageId)
			{
				return BadRequest();
			}

			try
			{
				await _sanPhamImgService.Update(SanPhamImg);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _sanPhamImgService.GetById(id) == null)
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


		[HttpPost("UploadImageBase64")]
		public async Task<ActionResult<SanPhamImgDto>> PostSanPhamImg( SanPhamImgDto sanPhamImg)
		{
			
			var result = await _sanPhamImgService.Add(sanPhamImg);

			return CreatedAtAction("GetSanPhamImg", new { id = sanPhamImg.ImageId }, sanPhamImg);
		}


		// DELETE: api/BaoTris/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSanPhamImg(Guid id)
		{
			var sanPham = await _sanPhamImgService.GetById(id);
			if (sanPham == null)
			{
				return NotFound();
			}

			await _sanPhamImgService.Delete(sanPham);

			return NoContent();
		}
		[NonAction]
		private string GetFilepath(SanPhamImgDto input)
		{
			return this.environment.WebRootPath + "\\Upload\\product\\" + input;
		}

	}
}
