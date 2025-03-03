
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class KhoRepository : IKhoRepository
	{
		private readonly QlySanXuatErpContext _context;

		public KhoRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Kho>> GetAll()
		{
			return await _context.Khos.ToListAsync();
		}

		public async Task<Kho> GetById(Guid id)
		{
			return await _context.Khos.FindAsync(id);
		}

		public async Task<Kho> Update(Kho input)
		{
			var result = _context.Khos.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<Kho> Add(Kho input)
		{
			var result = _context.Khos.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<Kho> Delete(Kho input)
		{
			var result = _context.Khos.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		
	}
}
