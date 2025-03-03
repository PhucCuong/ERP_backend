using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface ISanPhamImgService
	{
		Task<IEnumerable<SanPhamImgDto>> GetAll();
		Task<SanPhamImgDto> GetById(Guid id);
		Task<SanPhamImgDto> Update(SanPhamImgDto input);
		Task<SanPhamImgDto> Add(SanPhamImgDto input);
		Task<SanPhamImgDto> Delete(SanPhamImgDto input);
	}
}
