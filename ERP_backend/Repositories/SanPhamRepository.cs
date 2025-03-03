
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class SanPhamRepository : ISanPhamRepository
	{
		private readonly QlySanXuatErpContext _context;

		public SanPhamRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<SanPham>> GetAll()
		{
			return await _context.SanPhams.ToListAsync();
		}

		public async Task<SanPham> GetById(Guid id)
		{
			return await _context.SanPhams.FindAsync(id);
		}

		public async Task<SanPham> Update(SanPham input)
		{
			var result = _context.SanPhams.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<SanPham> Add(SanPham input)
		{
			var result = _context.SanPhams.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<SanPham> Delete(SanPham input)
		{
			var result = _context.SanPhams.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		
	}
}
