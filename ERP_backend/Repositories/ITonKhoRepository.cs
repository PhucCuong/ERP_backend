using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface ITonKhoRepository
	{
	Task<IEnumerable<TonKho>> GetAll();
		Task<TonKho> GetById(Guid id);
		Task<TonKho> Update(TonKho input);
		Task<TonKho> Add(TonKho input);
		Task<TonKho> Delete(TonKho input);
	}
}
