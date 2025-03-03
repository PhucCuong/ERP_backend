using ERP_backend.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class BaoCaoSanXuatRepository : IBaoCaoSanXuatRepository
	{
		private readonly QlySanXuatErpContext _context;

		public BaoCaoSanXuatRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}

		public async Task<BaoCaoSanXuat> Add(BaoCaoSanXuat input)
		{
			var result = _context.BaoCaoSanXuats.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;

		}
		
		public async Task<BaoCaoSanXuat> Delete(BaoCaoSanXuat input)
		{
			var result = _context.BaoCaoSanXuats.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<IEnumerable<BaoCaoSanXuat>> GetAll()
		{
			return await _context.BaoCaoSanXuats.ToListAsync();
		}

		public async Task<BaoCaoSanXuat> GetById(Guid id)
		{
			return await _context.BaoCaoSanXuats.FindAsync(id);
		}

		public async Task<BaoCaoSanXuat> Update(BaoCaoSanXuat input)
		{
			var result = _context.BaoCaoSanXuats.Update(input).Entity;
			
			await _context.SaveChangesAsync();
			return result;
		}
	}
}
