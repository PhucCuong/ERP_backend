
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class KiemTraChatLuongRepository : IKiemTraChatLuongRepository
	{
		private readonly QlySanXuatErpContext _context;

		public KiemTraChatLuongRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<KiemTraChatLuong>> GetAll()
		{
			return await _context.KiemTraChatLuongs.ToListAsync();
		}

		public async Task<KiemTraChatLuong> GetById(Guid id)
		{
			return await _context.KiemTraChatLuongs.FindAsync(id);
		}

		public async Task<KiemTraChatLuong> Update(KiemTraChatLuong input)
		{
			var result = _context.KiemTraChatLuongs.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<KiemTraChatLuong> Add(KiemTraChatLuong input)
		{
			var result = _context.KiemTraChatLuongs.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<KiemTraChatLuong> Delete(KiemTraChatLuong input)
		{
			var result = _context.KiemTraChatLuongs.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		
	}
}
