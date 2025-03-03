
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class LenhSanXuatRepository : ILenhSanXuatRepository
	{
		private readonly QlySanXuatErpContext _context;

		public LenhSanXuatRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<LenhSanXuat>> GetAll()
		{
			return await _context.LenhSanXuats.ToListAsync();
		}

		public async Task<LenhSanXuat> GetById(Guid id)
		{
			return await _context.LenhSanXuats.FindAsync(id);
		}

		public async Task<LenhSanXuat> Update(LenhSanXuat input)
		{
			var result = _context.LenhSanXuats.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<LenhSanXuat> Add(LenhSanXuat input)
		{
			var result = _context.LenhSanXuats.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<LenhSanXuat> Delete(LenhSanXuat input)
		{
			var result = _context.LenhSanXuats.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		
	}
}
