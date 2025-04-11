
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class KeHoachSanXuatRepository : IKeHoachSanXuatRepository
	{
		private readonly QlySanXuatErpContext _context;

		public KeHoachSanXuatRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<KeHoachSanXuat>> GetAll()
		{
			return await _context.KeHoachSanXuats.ToListAsync();
		}

		public async Task<KeHoachSanXuat> GetById(int id)
		{
			return await _context.KeHoachSanXuats.FindAsync(id);
		}

		public async Task<KeHoachSanXuat> Update(KeHoachSanXuat input)
		{
			var result = _context.KeHoachSanXuats.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<KeHoachSanXuat> Add(KeHoachSanXuat input)
		{
			var result = _context.KeHoachSanXuats.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<KeHoachSanXuat> Delete(KeHoachSanXuat input)
		{
			var result = _context.KeHoachSanXuats.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		
	}
}
