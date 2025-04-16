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
using Microsoft.AspNetCore.Authorization;

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
		//// [Authorize(Roles = "Bộ phận sản xuất")]
		public async Task<ActionResult<IEnumerable<ChiTietHoatDongSanXuatDto>>> GetChiTietHoatDongSanXuats()
        {
			var result = await _chiTietHoatDongSanXuatService.GetAll();
			return Ok(result);
		}

        // GET: api/ChiTietHoatDongSanXuats/5
        [HttpGet("{id}")]
		// [Authorize(Roles = "Bộ phận sản xuất")]
		public async Task<ActionResult<ChiTietHoatDongSanXuatDto>> GetChiTietHoatDongSanXuat(Guid id)
        {
			var hoatDong = await _chiTietHoatDongSanXuatService.GetById(id);
			if (hoatDong == null) return NotFound();

			if (!hoatDong.FileData.StartsWith("http"))
			{
				hoatDong.FileData = $"{Request.Scheme}://{Request.Host}/{hoatDong.FileData.TrimStart('/')}";
			}

			return Ok(hoatDong);
		}
		[HttpGet("download/{id}")]
		public async Task<IActionResult> DownloadFile(Guid id)
		{
			var hoatDong = await _chiTietHoatDongSanXuatService.GetById(id);
			if (hoatDong == null || string.IsNullOrEmpty(hoatDong.FileData))
			{
				return NotFound(new { message = "Không tìm thấy file." });
			}

			try
			{
				// Nếu FileData chứa URL, trích xuất đường dẫn thực sự
				var relativePath = hoatDong.FileData;
				if (hoatDong.FileData.StartsWith("http"))
				{
					relativePath = new Uri(hoatDong.FileData).AbsolutePath.TrimStart('/');
				}

				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", relativePath);
				filePath = Uri.UnescapeDataString(filePath); // Loại bỏ ký tự đặc biệt

				Console.WriteLine($"Checking file path: {filePath}");

				if (!System.IO.File.Exists(filePath))
				{
					return NotFound(new { message = "File không tồn tại trên server.", filePath });
				}

				var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
				return File(fileBytes, "application/pdf", Path.GetFileName(filePath));
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "Lỗi khi xử lý file.", error = ex.Message });
			}
		}
		// PUT: api/ChiTietHoatDongSanXuats/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		// [Authorize(Roles = "Bộ phận sản xuất")]
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
		// [Authorize(Roles = "Bộ phận sản xuất")]
		public async Task<ActionResult<ChiTietHoatDongSanXuatDto>> PostChiTietHoatDongSanXuat([FromForm]  ChiTietHoatDongSanXuatDto chiTietHoatDongSanXuat)
        {
			var result = await _chiTietHoatDongSanXuatService.Add(chiTietHoatDongSanXuat);

			return CreatedAtAction("GetChiTietHoatDongSanXuat", new { id = chiTietHoatDongSanXuat.MaHoatDong }, chiTietHoatDongSanXuat);
		}
		[HttpPost("{id}/upload")]
		public async Task<IActionResult> UploadFile(Guid id, IFormFile file)
		{
			if (file == null || file.Length == 0)
			{
				return BadRequest(new { message = "Vui lòng chọn file hợp lệ." });
			}

			try
			{
				// Chỉ upload file, không cập nhật thông tin hoạt động
				var filePath = await _chiTietHoatDongSanXuatService.UploadFileOnly(id, file);

				return Ok(new
				{
					message = "Upload thành công",
					fileName = file.FileName,
					filePath = filePath
					// Không trả về thông tin hoạt động
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "Lỗi khi upload file",
					error = ex.Message
				});
			}
		}

		// DELETE: api/ChiTietHoatDongSanXuats/5
		[HttpDelete("{id}")]
		// [Authorize(Roles = "Bộ phận sản xuất")]
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

        [HttpPost("kiem-tra-thu-tu")]
        public async Task<IActionResult> KiemTraThuTu([FromBody] CheckThuTuHoatDongDto request)
        {
            var hoatDongList = await _chiTietHoatDongSanXuatService.GetAll();
            var hoatDongsCungQuyTrinh = hoatDongList
                .Where(hd => hd.MaQuyTrinh == request.MaQuyTrinh)
                .ToList();

            // Nếu danh sách rỗng thì cho phép thêm với thuTu = 1
            if (!hoatDongsCungQuyTrinh.Any())
            {
                if (request.ThuTu != 1)
                {
                    return Ok(new
                    {
                        success = false,
                        message = "Chưa có bước nào trong quy trình này. Hãy nhập số thứ tự là: 1"
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = "Thứ tự hợp lệ, có thể thêm mới."
                });
            }

            var maxThuTu = hoatDongsCungQuyTrinh.Max(hd => hd.ThuTu);

            // Kiểm tra trùng thứ tự
            var isTrungThuTu = hoatDongsCungQuyTrinh.Any(hd => hd.ThuTu == request.ThuTu);
            if (isTrungThuTu)
            {
                return Ok(new
                {
                    success = false,
                    message = $"Đã tồn tại bước với thứ tự này. Thứ tự lớn nhất hiện tại của quy trình là {maxThuTu}."
                });
            }

            // Kiểm tra khoảng cách không hợp lệ
            if (request.ThuTu > maxThuTu + 1)
            {
                return Ok(new
                {
                    success = false,
                    message = $"Hãy nhập số thứ tự là: {maxThuTu + 1}"
                });
            }

            return Ok(new
            {
                success = true,
                message = "Thứ tự hợp lệ, có thể thêm mới."
            });
        }


        //private bool ChiTietHoatDongSanXuatExists(Guid id)
        //{
        //    return _context.ChiTietHoatDongSanXuats.Any(e => e.MaHoatDong == id);
        //}
    }
}
