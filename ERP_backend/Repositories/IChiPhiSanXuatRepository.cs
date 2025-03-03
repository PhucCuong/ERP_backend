using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface IChiPhiSanXuatRepository
	{
		Task<IEnumerable<ChiPhiSanXuat>> GetAll();
		Task<ChiPhiSanXuat> GetById(Guid id);
		Task<ChiPhiSanXuat> Update(ChiPhiSanXuat input);
		Task<ChiPhiSanXuat> Add(ChiPhiSanXuat input);
		Task<ChiPhiSanXuat> Delete(ChiPhiSanXuat input);
	}
}
