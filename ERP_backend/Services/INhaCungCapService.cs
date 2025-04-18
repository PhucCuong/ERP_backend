using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface INhaCungCapService
	{
		Task<IEnumerable<NhaCungCapDto>> GetAll();
		Task<NhaCungCapDto> GetById(Guid id);
		Task<NhaCungCapDto> Update(NhaCungCapDto input);
		Task<NhaCungCapDto> Add(NhaCungCapDto input);
		Task<NhaCungCapDto> Delete(NhaCungCapDto input);
	}
}
