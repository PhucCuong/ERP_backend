using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface ITonKhoService
	{
		Task<IEnumerable<TonKhoDto>> GetAll();
		Task<TonKhoDto> GetById(Guid id);
		Task<TonKhoDto> Update(TonKhoDto input);
		Task<TonKhoDto> Add(TonKhoDto input);
		Task<TonKhoDto> Delete(TonKhoDto input);
	}
}
