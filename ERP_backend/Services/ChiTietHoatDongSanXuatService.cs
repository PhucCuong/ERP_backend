using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ERP_backend.Services
{
	public class ChiTietHoatDongSanXuatService : IChiTietHoatDongSanXuatService
	{
		private readonly IChiTietHoatDongSanXuatRepository _chiTietHoatDongSanXuatRepository;
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly QlySanXuatErpContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public ChiTietHoatDongSanXuatService(IChiTietHoatDongSanXuatRepository chiTietHoatDongSanXuatRepository,
			IWebHostEnvironment webHostEnvironment, QlySanXuatErpContext context, IHttpContextAccessor httpContextAccessor)
		{
			_chiTietHoatDongSanXuatRepository = chiTietHoatDongSanXuatRepository;
			_webHostEnvironment = webHostEnvironment;
			_context = context;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<ChiTietHoatDongSanXuatDto> Add(ChiTietHoatDongSanXuatDto input)
		{
			var convertData = ConvertDtoToChiTietHoatDongSanXuat(input);
			var result = await _chiTietHoatDongSanXuatRepository.Add(convertData);
			return ConvertChiTietHoatDongSanXuatToDto(result);
		}

		public async Task<ChiTietHoatDongSanXuatDto?> Delete(ChiTietHoatDongSanXuatDto input)
		{
			var existingChiTietHoatDongSanXuat = await _chiTietHoatDongSanXuatRepository.GetById(input.MaHoatDong);

			if (existingChiTietHoatDongSanXuat == null)
			{
				return null; // Hoặc throw NotFoundException
			}

			var result = await _chiTietHoatDongSanXuatRepository.Delete(existingChiTietHoatDongSanXuat);
			return ConvertChiTietHoatDongSanXuatToDto(result);
		}


		public async Task<IEnumerable<ChiTietHoatDongSanXuatDto>> GetAll()
		{
			var result = await _chiTietHoatDongSanXuatRepository.GetAll();
			return ConvertListChiTietHoatDongSanXuatToDto(result);
		}

		public async Task<ChiTietHoatDongSanXuatDto> GetById(Guid id)
		{
			var hoatDong = await _context.ChiTietHoatDongSanXuats
	   .Where(h => h.MaHoatDong == id)
	   .Select(h => new ChiTietHoatDongSanXuatDto
	   {
		   MaHoatDong = h.MaHoatDong,
		   TenHoatDong = h.TenHoatDong,
		   FileData = h.FileData != null ? $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{h.FileData}" : null
	   })
	   .FirstOrDefaultAsync();

			return hoatDong;
		}

		public async Task<ChiTietHoatDongSanXuatDto> Update(ChiTietHoatDongSanXuatDto input)
		{
			var convertData = ConvertDtoToChiTietHoatDongSanXuat(input);
			var result = await _chiTietHoatDongSanXuatRepository.Update(convertData);
			return ConvertChiTietHoatDongSanXuatToDto(result);
		}
		public async Task<ChiTietHoatDongSanXuatDto> UploadFile(Guid id, IFormFile file)
		{
			// Kiểm tra entity có tồn tại không, thay thế MaHoatDong bằng MaQuyTrinh
			var entity = await _chiTietHoatDongSanXuatRepository.GetById(id);
			if (entity == null)
			{
				throw new KeyNotFoundException("Hoạt động không tồn tại.");
			}

			// Kiểm tra file hợp lệ
			if (file == null || file.Length == 0)
			{
				throw new ArgumentException("File không hợp lệ.");
			}

			// Chỉ chấp nhận file Excel & PDF
			var allowedExtensions = new[] { ".xlsx", ".xls", ".pdf" };
			var fileExtension = Path.GetExtension(file.FileName).ToLower();
			if (!allowedExtensions.Contains(fileExtension))
			{
				throw new ArgumentException("Chỉ hỗ trợ file Excel (.xlsx, .xls) hoặc PDF (.pdf).");
			}

			// Đọc dữ liệu file vào entity
			using (var stream = file.OpenReadStream()) // Tối ưu bộ nhớ hơn MemoryStream
			{
				using (var memoryStream = new MemoryStream())
				{
					await stream.CopyToAsync(memoryStream);
					entity.FileData = Convert.ToBase64String(memoryStream.ToArray());
				}
			}

			// Lưu tên file & cập nhật thông tin vào DB
			entity.TenHoatDong = file.FileName;
			await _chiTietHoatDongSanXuatRepository.Update(entity);

			return ConvertChiTietHoatDongSanXuatToDto(entity);
		}
		public async Task<string> UploadFileOnly(Guid id, IFormFile file)
		{
			var hoatDong = await _context.ChiTietHoatDongSanXuats.FindAsync(id);
			if (hoatDong == null)
			{
				throw new Exception("Hoạt động không tồn tại.");
			}

			var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "PDF");
			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}

			var fileName = $"{id}.pdf";
			var filePath = Path.Combine(folderPath, fileName);

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			// Lưu đường dẫn vào DB
			hoatDong.FileData = $"/Uploads/PDF/{fileName}";
			_context.ChiTietHoatDongSanXuats.Update(hoatDong);
			await _context.SaveChangesAsync();

			return $"/Uploads/PDF/{id}.pdf";
		}
		private ChiTietHoatDongSanXuatDto ConvertChiTietHoatDongSanXuatToDto(ChiTietHoatDongSanXuat input)
		{
			var result = new ChiTietHoatDongSanXuatDto();
			if (input == null)
			{
				return result;
			}
			result.MaHoatDong = input.MaHoatDong;
			result.MaQuyTrinh = input.MaQuyTrinh;
			result.TenHoatDong = input.TenHoatDong;
			result.GiaiDoanSanXuat = input.GiaiDoanSanXuat;
			result.ThuTu = input.ThuTu;
			result.SoLuongChoXuLy = input.SoLuongChoXuLy;
			
			result.ThoiGianMacDinh = input.ThoiGianMacDinh;
			result.DieuKienBatDauGiaiDoanTiepTheo = input.DieuKienBatDauGiaiDoanTiepTheo;
			result.MoTa = input.MoTa;
			result.FileData = input.FileData;
			return result;
		}

		private IEnumerable<ChiTietHoatDongSanXuatDto> ConvertListChiTietHoatDongSanXuatToDto(IEnumerable<ChiTietHoatDongSanXuat> input)
		{
			var result = new List<ChiTietHoatDongSanXuatDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertChiTietHoatDongSanXuatToDto(item));
			}

			return result;
		}

		private ChiTietHoatDongSanXuat ConvertDtoToChiTietHoatDongSanXuat(ChiTietHoatDongSanXuatDto input)
		{
			var result = new ChiTietHoatDongSanXuat();
			if (input == null)
			{
				return result;
			}
			result.MaHoatDong = input.MaHoatDong;
			result.MaQuyTrinh = input.MaQuyTrinh;	
			result.TenHoatDong = input.TenHoatDong;
			result.GiaiDoanSanXuat = input.GiaiDoanSanXuat		;
			result.ThuTu = input.ThuTu;
			result.SoLuongChoXuLy = input.SoLuongChoXuLy;
			
			result.ThoiGianMacDinh = input.ThoiGianMacDinh;
			result.DieuKienBatDauGiaiDoanTiepTheo = input.DieuKienBatDauGiaiDoanTiepTheo;
			result.MoTa = input.MoTa;
			result.FileData = input.FileData;
			return result;
		}

		private IEnumerable<ChiTietHoatDongSanXuat> ConvertListDtoToChiTietHoatDongSanXuat(IEnumerable<ChiTietHoatDongSanXuatDto> input)
		{
			var result = new List<ChiTietHoatDongSanXuat>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToChiTietHoatDongSanXuat(item));
			}

			return result;
		}

		

	}
}
