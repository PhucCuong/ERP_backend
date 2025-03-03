using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface IKiemTraChatLuongService
	{
	Task<IEnumerable<KiemTraChatLuongDto>> GetAll();
		Task<KiemTraChatLuongDto> GetById(Guid id);
		Task<KiemTraChatLuongDto> Update(KiemTraChatLuongDto input);
		Task<KiemTraChatLuongDto> Add(KiemTraChatLuongDto input);
		Task<KiemTraChatLuongDto> Delete(KiemTraChatLuongDto input);
	}
}
