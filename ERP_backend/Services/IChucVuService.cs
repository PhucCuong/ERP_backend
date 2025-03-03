using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface IChucVuService
	{
	Task<IEnumerable<ChucVuDto>> GetAll();
		Task<ChucVuDto> GetById(Guid id);
		Task<ChucVuDto> Update(ChucVuDto input);
		Task<ChucVuDto> Add(ChucVuDto input);
		Task<ChucVuDto> Delete(ChucVuDto input);
	}
}
