using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class ChiPhiSanXuatRepository : IChiPhiSanXuatRepository
	{
		private readonly QlySanXuatErpContext _context;

		public ChiPhiSanXuatRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}


		public async Task<ChiPhiSanXuat> Add(ChiPhiSanXuat input)
		{
			var result = _context.ChiPhiSanXuats.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		
		public async Task<ChiPhiSanXuat> Delete(ChiPhiSanXuat input)
		{
			var result = _context.ChiPhiSanXuats.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<IEnumerable<ChiPhiSanXuat>> GetAll()
		{
			return await _context.ChiPhiSanXuats.ToListAsync();
		}

		public async Task<ChiPhiSanXuat> GetById(Guid id)
		{
			return await _context.ChiPhiSanXuats.FindAsync(id);
		}
		public async Task<ChiPhiSanXuat> Update(ChiPhiSanXuat input)
		{
			var result = _context.ChiPhiSanXuats.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
	}
}
