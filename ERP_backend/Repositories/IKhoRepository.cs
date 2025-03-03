using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface IKhoRepository
	{
		Task<Kho> Add(Kho input);
		Task<Kho> Delete(Kho input);
		Task<IEnumerable<Kho>> GetAll();
		Task<Kho> GetById(Guid id);
		Task<Kho> Update(Kho input);
	}
}
