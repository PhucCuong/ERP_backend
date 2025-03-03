
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class BaoTriRepository : IBaoTriRepository
	{
		private readonly QlySanXuatErpContext _context;

		public BaoTriRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<BaoTri>> GetAll()
		{
			return await _context.BaoTris.ToListAsync();
		}

		public async Task<BaoTri> GetById(Guid id)
		{
			return await _context.BaoTris.FindAsync(id);
		}

		public async Task<BaoTri> Update(BaoTri input)
		{
			var result = _context.BaoTris.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<BaoTri> Add(BaoTri input)
		{
			var result = _context.BaoTris.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<BaoTri> Delete(BaoTri input)
		{
			var result = _context.BaoTris.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		
	}
}
