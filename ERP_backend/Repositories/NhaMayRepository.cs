
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class NhaMayRepository : INhaMayRepository
	{
		private readonly QlySanXuatErpContext _context;

		public NhaMayRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<NhaMay>> GetAll()
		{
			return await _context.NhaMays.ToListAsync();
		}

		public async Task<NhaMay> GetById(Guid id)
		{
			return await _context.NhaMays.FindAsync(id);
		}

		public async Task<NhaMay> Update(NhaMay input)
		{
			var result = _context.NhaMays.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<NhaMay> Add(NhaMay input)
		{
			var result = _context.NhaMays.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<NhaMay> Delete(NhaMay input)
		{
			var result = _context.NhaMays.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		
	}
}
