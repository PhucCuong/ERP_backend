using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface INhaCungCapRepository
	{
	Task<IEnumerable<NhaCungCap>> GetAll();
		Task<NhaCungCap> GetById(Guid id);
		Task<NhaCungCap> Update(NhaCungCap input);
		Task<NhaCungCap> Add(NhaCungCap input);
		Task<NhaCungCap> Delete(NhaCungCap input);
	}
}
