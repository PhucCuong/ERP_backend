using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface IKhoService
	{
		Task<IEnumerable<KhoDto>> GetAll();
		Task<KhoDto> GetById(Guid id);
		Task<KhoDto> Update(KhoDto input);
		Task<KhoDto> Add(KhoDto input);
		Task<KhoDto> Delete(KhoDto input);
	}
}
