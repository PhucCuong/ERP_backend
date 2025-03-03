using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface IKiemTraChatLuongRepository
	{
	Task<IEnumerable<KiemTraChatLuong>> GetAll();
		Task<KiemTraChatLuong> GetById(Guid id);
		Task<KiemTraChatLuong> Update(KiemTraChatLuong input);
		Task<KiemTraChatLuong> Add(KiemTraChatLuong input);
		Task<KiemTraChatLuong> Delete(KiemTraChatLuong input);
	}
}
