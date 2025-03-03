using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface IYeuCauNguyenVatLieuService
	{
	Task<IEnumerable<YeuCauNguyenVatLieuDto>> GetAll();
		Task<YeuCauNguyenVatLieuDto> GetById(Guid id);
		Task<YeuCauNguyenVatLieuDto> Update(YeuCauNguyenVatLieuDto input);
		Task<YeuCauNguyenVatLieuDto> Add(YeuCauNguyenVatLieuDto input);
		Task<YeuCauNguyenVatLieuDto> Delete(YeuCauNguyenVatLieuDto input);
	}
}
