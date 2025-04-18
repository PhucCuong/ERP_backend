
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class NhaCungCapRepository : INhaCungCapRepository
	{
		private readonly QlySanXuatErpContext _context;

		public NhaCungCapRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<NhaCungCap>> GetAll()
		{
			return await _context.NhaCungCaps.ToListAsync();
		}

		public async Task<NhaCungCap> GetById(Guid id)
		{
			return await _context.NhaCungCaps.FindAsync(id);
		}

		public async Task<NhaCungCap> Update(NhaCungCap input)
		{
			var result = _context.NhaCungCaps.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<NhaCungCap> Add(NhaCungCap input)
		{
			var result = _context.NhaCungCaps.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<NhaCungCap> Delete(NhaCungCap input)
		{
			var result = _context.NhaCungCaps.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		
	}
}
