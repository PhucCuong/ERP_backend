using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface INhapKhoRepository
	{
	Task<IEnumerable<NhapKho>> GetAll();
		Task<NhapKho> GetById(string id);
		Task<NhapKho> Update(NhapKho input);
		Task<NhapKho> Add(NhapKho input);
		Task<NhapKho> Delete(NhapKho input);
	}
}
