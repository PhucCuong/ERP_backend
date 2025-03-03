using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface ISanPhamImgRepository
	{
		Task<SanPhamImg> Add(SanPhamImg input);
		Task<SanPhamImg> Delete(SanPhamImg input);
		Task<IEnumerable<SanPhamImg>> GetAll();
		Task<SanPhamImg> GetById(Guid id);
		Task<SanPhamImg> Update(SanPhamImg input);
	}
}
