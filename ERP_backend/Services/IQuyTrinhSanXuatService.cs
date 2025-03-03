using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface IQuyTrinhSanXuatService
	{
	Task<IEnumerable<QuyTrinhSanXuatDto>> GetAll();
		Task<QuyTrinhSanXuatDto> GetById(Guid id);
		Task<QuyTrinhSanXuatDto> Update(QuyTrinhSanXuatDto input);
		Task<QuyTrinhSanXuatDto> Add(QuyTrinhSanXuatDto input);
		Task<QuyTrinhSanXuatDto> Delete(QuyTrinhSanXuatDto input);
	}
}
