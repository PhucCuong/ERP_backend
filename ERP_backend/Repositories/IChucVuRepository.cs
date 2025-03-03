using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface IChucVuRepository
	{
	Task<IEnumerable<ChucVu>> GetAll();
		Task<ChucVu> GetById(Guid id);
		Task<ChucVu> Update(ChucVu input);
		Task<ChucVu> Add(ChucVu input);
		Task<ChucVu> Delete(ChucVu input);
	}
}
