using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface IDinhMucNguyenVatLieuService
	{
	Task<IEnumerable<DinhMucNguyenVatLieuDto>> GetAll();
		Task<DinhMucNguyenVatLieuDto> GetById(Guid id);
		Task<DinhMucNguyenVatLieuDto> Update(DinhMucNguyenVatLieuDto input);
		Task<DinhMucNguyenVatLieuDto> Add(DinhMucNguyenVatLieuDto input);
		Task<DinhMucNguyenVatLieuDto> Delete(DinhMucNguyenVatLieuDto input);
	}
}
