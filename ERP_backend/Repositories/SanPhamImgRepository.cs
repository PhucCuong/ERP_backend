
using ERP_backend.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class SanPhamImgRepository : ISanPhamImgRepository
	{
		private readonly QlySanXuatErpContext _context;
		
		public SanPhamImgRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<SanPhamImg>> GetAll()
		{
			return await _context.SanPhamImgs.ToListAsync();
		}

		public async Task<SanPhamImg> GetById(Guid id)
		{
			return await _context.SanPhamImgs.FindAsync(id);
		}

		public async Task<SanPhamImg> Update(SanPhamImg input)
		{
			var result = _context.SanPhamImgs.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<SanPhamImg> Add(SanPhamImg input)
		{
			var result = _context.SanPhamImgs.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<SanPhamImg> Delete(SanPhamImg input)
		{
			var result = _context.SanPhamImgs.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}
		

	}
}
