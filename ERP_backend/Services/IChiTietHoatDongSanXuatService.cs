using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface IChiTietHoatDongSanXuatService
	{
	Task<IEnumerable<ChiTietHoatDongSanXuatDto>> GetAll();
		Task<ChiTietHoatDongSanXuatDto> GetById(Guid id);
		Task<ChiTietHoatDongSanXuatDto> Update(ChiTietHoatDongSanXuatDto input);
		Task<ChiTietHoatDongSanXuatDto> Add(ChiTietHoatDongSanXuatDto input);
		Task<ChiTietHoatDongSanXuatDto> Delete(ChiTietHoatDongSanXuatDto input);
		Task<ChiTietHoatDongSanXuatDto> UploadFile(Guid id, IFormFile file);
		Task<string> UploadFileOnly(Guid id, IFormFile file);
	}
}
