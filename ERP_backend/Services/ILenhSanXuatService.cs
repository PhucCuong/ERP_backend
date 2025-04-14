using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface ILenhSanXuatService
	{
	Task<IEnumerable<LenhSanXuatDto>> GetAll();
		Task<LenhSanXuatDto> GetById(int id);
		Task<LenhSanXuatDto> Update(LenhSanXuatDto input);
		Task<LenhSanXuatDto> Add(LenhSanXuatDto input);
		Task<bool> Delete(int input);
    }
}
