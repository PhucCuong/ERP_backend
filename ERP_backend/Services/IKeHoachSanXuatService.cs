using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface IKeHoachSanXuatService
	{
	Task<IEnumerable<KeHoachSanXuatDto>> GetAll();
		Task<KeHoachSanXuatDto> GetById(int id);
		Task<KeHoachSanXuatDto> Update(KeHoachSanXuatDto input);
		Task<KeHoachSanXuatDto> Add(KeHoachSanXuatDto input);
		Task<KeHoachSanXuatDto> Delete(KeHoachSanXuatDto input);
	}
}
