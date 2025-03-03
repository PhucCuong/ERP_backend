using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface INhaMayService
	{
	Task<IEnumerable<NhaMayDto>> GetAll();
		Task<NhaMayDto> GetById(Guid id);
		Task<NhaMayDto> Update(NhaMayDto input);
		Task<NhaMayDto> Add(NhaMayDto input);
		Task<NhaMayDto> Delete(NhaMayDto input);
	}
}
