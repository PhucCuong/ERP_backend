using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;
namespace ERP_backend.Repositories
{
	public class ChiTietHoatDongSanXuatRepository : IChiTietHoatDongSanXuatRepository
	{
		private readonly QlySanXuatErpContext _context;

		public ChiTietHoatDongSanXuatRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}

		public async Task<ChiTietHoatDongSanXuat> Add(ChiTietHoatDongSanXuat input)
		{
			var result = _context.ChiTietHoatDongSanXuats.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;

		}

		public async Task<ChiTietHoatDongSanXuat> Delete(ChiTietHoatDongSanXuat input)
		{
			var result = _context.ChiTietHoatDongSanXuats.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<IEnumerable<ChiTietHoatDongSanXuat>> GetAll()
		{
			return await _context.ChiTietHoatDongSanXuats.ToListAsync();
		}

		public async Task<ChiTietHoatDongSanXuat> GetById(Guid id)
		{
			return await _context.ChiTietHoatDongSanXuats.FindAsync(id);
		}

	
		public async Task<ChiTietHoatDongSanXuat> Update(ChiTietHoatDongSanXuat input)
		{
			var result = _context.ChiTietHoatDongSanXuats.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
	}
}
