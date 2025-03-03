
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class YeuCauNguyenVatLieuRepository : IYeuCauNguyenVatLieuRepository
	{
		private readonly QlySanXuatErpContext _context;

		public YeuCauNguyenVatLieuRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<YeuCauNguyenVatLieu>> GetAll()
		{
			return await _context.YeuCauNguyenVatLieus.ToListAsync();
		}

		public async Task<YeuCauNguyenVatLieu> GetById(Guid id)
		{
			return await _context.YeuCauNguyenVatLieus.FindAsync(id);
		}

		public async Task<YeuCauNguyenVatLieu> Update(YeuCauNguyenVatLieu input)
		{
			var result = _context.YeuCauNguyenVatLieus.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<YeuCauNguyenVatLieu> Add(YeuCauNguyenVatLieu input)
		{
			var result = _context.YeuCauNguyenVatLieus.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<YeuCauNguyenVatLieu> Delete(YeuCauNguyenVatLieu input)
		{
			var result = _context.YeuCauNguyenVatLieus.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		
	}
}
