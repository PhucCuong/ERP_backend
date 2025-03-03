
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class TonKhoRepository : ITonKhoRepository
	{
		private readonly QlySanXuatErpContext _context;

		public TonKhoRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<TonKho>> GetAll()
		{
			return await _context.TonKhos.ToListAsync();
		}

		public async Task<TonKho> GetById(Guid id)
		{
			return await _context.TonKhos.FindAsync(id);
		}

		public async Task<TonKho> Update(TonKho input)
		{
			var result = _context.TonKhos.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<TonKho> Add(TonKho input)
		{
			var result = _context.TonKhos.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<TonKho> Delete(TonKho input)
		{
			var result = _context.TonKhos.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		
	}
}
