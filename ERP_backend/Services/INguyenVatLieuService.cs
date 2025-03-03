using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface INguyenVatLieuService
	{
		Task<IEnumerable<NguyenVatLieuDto>> GetAll();
		Task<NguyenVatLieuDto> GetById(Guid id);
		Task<NguyenVatLieuDto> Update(NguyenVatLieuDto input);
		Task<NguyenVatLieuDto> Add(NguyenVatLieuDto input);
		Task<NguyenVatLieuDto> Delete(NguyenVatLieuDto input);
	}
}
