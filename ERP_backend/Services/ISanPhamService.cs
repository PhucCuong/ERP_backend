using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface ISanPhamService
	{
	Task<IEnumerable<SanPhamDto>> GetAll();
		Task<SanPhamDto> GetById(Guid id);
		Task<SanPhamDto> Update(SanPhamDto input);
		Task<SanPhamDto> Add(SanPhamDto input);
		Task<SanPhamDto> Delete(SanPhamDto input);
	}
}
