using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface ILenhSanXuatRepository
	{
	Task<IEnumerable<LenhSanXuat>> GetAll();
		Task<LenhSanXuat> GetById(Guid id);
		Task<LenhSanXuat> Update(LenhSanXuat input);
		Task<LenhSanXuat> Add(LenhSanXuat input);
		Task<LenhSanXuat> Delete(LenhSanXuat input);
	}
}
