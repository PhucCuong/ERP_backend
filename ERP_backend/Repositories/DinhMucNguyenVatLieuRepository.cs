
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ERP_backend.Repositories
{
	public class DinhMucNguyenVatLieuRepository : IDinhMucNguyenVatLieuRepository
	{
		private readonly QlySanXuatErpContext _context;

		public DinhMucNguyenVatLieuRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<DinhMucNguyenVatLieu>> GetAll()
		{
			return await _context.DinhMucNguyenVatLieus.ToListAsync();
		}

		public async Task<DinhMucNguyenVatLieu> GetById(Guid id)
		{
			return await _context.DinhMucNguyenVatLieus.FindAsync(id);
		}

		public async Task<DinhMucNguyenVatLieu> Update(DinhMucNguyenVatLieu input)
		{
			var result = _context.DinhMucNguyenVatLieus.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<DinhMucNguyenVatLieu> Add(DinhMucNguyenVatLieu input)
		{
			var result = _context.DinhMucNguyenVatLieus.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<DinhMucNguyenVatLieu> Delete(DinhMucNguyenVatLieu input)
		{
			var result = _context.DinhMucNguyenVatLieus.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<IEnumerable<DinhMucNguyenVatLieu>> GetByConditionAsync(Expression<Func<DinhMucNguyenVatLieu, bool>> expression)
		{
			return await _context.DinhMucNguyenVatLieus.Where(expression).ToListAsync();
		}
	}
}
