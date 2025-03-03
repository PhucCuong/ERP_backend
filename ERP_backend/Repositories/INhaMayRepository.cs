using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface INhaMayRepository
	{
	Task<IEnumerable<NhaMay>> GetAll();
		Task<NhaMay> GetById(Guid id);
		Task<NhaMay> Update(NhaMay input);
		Task<NhaMay> Add(NhaMay input);
		Task<NhaMay> Delete(NhaMay input);
	}
}
