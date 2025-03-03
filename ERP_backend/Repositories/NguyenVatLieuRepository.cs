
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class NguyenVatLieuRepository : INguyenVatLieuRepository
	{
		private readonly QlySanXuatErpContext _context;

		public NguyenVatLieuRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<NguyenVatLieu>> GetAll()
		{
			return await _context.NguyenVatLieus.ToListAsync();
		}

		public async Task<NguyenVatLieu> GetById(Guid id)
		{
			return await _context.NguyenVatLieus.FindAsync(id);
		}

		public async Task<NguyenVatLieu> Update(NguyenVatLieu input)
		{
			var result = _context.NguyenVatLieus.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<NguyenVatLieu> Add(NguyenVatLieu input)
		{
			var result = _context.NguyenVatLieus.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<NguyenVatLieu> Delete(NguyenVatLieu input)
		{
			var result = _context.NguyenVatLieus.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		
	}
}
