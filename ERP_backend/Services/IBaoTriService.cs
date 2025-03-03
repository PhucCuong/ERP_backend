using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface IBaoTriService
	{
		Task<IEnumerable<BaoTriDto>> GetAll();
		Task<BaoTriDto> GetById(Guid id);
		Task<BaoTriDto> Update(BaoTriDto input);
		Task<BaoTriDto> Add(BaoTriDto input);
		Task<BaoTriDto> Delete(BaoTriDto input);
	}
}
