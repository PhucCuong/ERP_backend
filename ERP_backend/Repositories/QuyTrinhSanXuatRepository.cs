
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class QuyTrinhSanXuatRepository : IQuyTrinhSanXuatRepository
	{
		private readonly QlySanXuatErpContext _context;

		public QuyTrinhSanXuatRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<QuyTrinhSanXuat>> GetAll()
		{
			return await _context.QuyTrinhSanXuats.ToListAsync();
		}

		public async Task<QuyTrinhSanXuat> GetById(Guid id)
		{
			return await _context.QuyTrinhSanXuats.FindAsync(id);
		}

		public async Task<QuyTrinhSanXuat> Update(QuyTrinhSanXuat input)
		{
			var result = _context.QuyTrinhSanXuats.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<QuyTrinhSanXuat> Add(QuyTrinhSanXuat input)
		{
			var result = _context.QuyTrinhSanXuats.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<QuyTrinhSanXuat> Delete(QuyTrinhSanXuat input)
		{
			var result = _context.QuyTrinhSanXuats.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		
	}
}
