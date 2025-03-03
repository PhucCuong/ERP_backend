using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface ISanPhamRepository
	{
	Task<IEnumerable<SanPham>> GetAll();
		Task<SanPham> GetById(Guid id);
		Task<SanPham> Update(SanPham input);
		Task<SanPham> Add(SanPham input);
		Task<SanPham> Delete(SanPham input);
	}
}
