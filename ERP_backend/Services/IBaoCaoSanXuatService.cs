using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface IBaoCaoSanXuatService
	{
		Task<BaoCaoSanXuatDto> Add(BaoCaoSanXuatDto input);
		Task<BaoCaoSanXuatDto> Delete(BaoCaoSanXuatDto input);
		Task<IEnumerable<BaoCaoSanXuatDto>> GetAll();
		Task<BaoCaoSanXuatDto> GetById(int id);
		Task<BaoCaoSanXuatDto> Update(BaoCaoSanXuatDto input);
	}
}
