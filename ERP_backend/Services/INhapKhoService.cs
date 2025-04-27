using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface INhapKhoService
	{
	Task<IEnumerable<NhapKhoDto>> GetAll();
		Task<NhapKhoDto> GetById(string id);
		Task<NhapKhoDto> Update(NhapKhoDto input);
		Task<NhapKhoDto> Add(NhapKhoDto input);
		Task<NhapKhoDto> Delete(NhapKhoDto input);
        Task<bool> AddList(AddListNhapKhoDto addListNhapKhoDto);
        Task<List<ChatLuongSanPham>> GetAllListCheckQuality();

        Task<bool> UpdateStatus(UpdateStatusNhapKhoDto input);
    }
}
