using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface IBaoCaoSanXuatRepository
	{
		Task<BaoCaoSanXuat> Add(BaoCaoSanXuat input);
		Task<BaoCaoSanXuat> Delete(BaoCaoSanXuat input);
		Task<IEnumerable<BaoCaoSanXuat>> GetAll();
		Task<BaoCaoSanXuat> GetById(Guid id);
	    Task<BaoCaoSanXuat> Update(BaoCaoSanXuat input);
	}
}
