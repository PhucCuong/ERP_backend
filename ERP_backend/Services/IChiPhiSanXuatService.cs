using ERP_backend.DTOs;

namespace ERP_backend.Services
{
	public interface IChiPhiSanXuatService
	{
		Task<IEnumerable<ChiPhiSanXuatDto>> GetAll();
		Task<ChiPhiSanXuatDto> GetById(Guid id);
		Task<ChiPhiSanXuatDto> Update(ChiPhiSanXuatDto input);
		Task<ChiPhiSanXuatDto> Add(ChiPhiSanXuatDto input);
		Task<ChiPhiSanXuatDto> Delete(ChiPhiSanXuatDto input);
	}
}
