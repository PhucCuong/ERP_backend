using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface IBaoTriRepository
	{
	Task<IEnumerable<BaoTri>> GetAll();
		Task<BaoTri> GetById(Guid id);
		Task<BaoTri> Update(BaoTri input);
		Task<BaoTri> Add(BaoTri input);
		Task<BaoTri> Delete(BaoTri input);
	}
}
