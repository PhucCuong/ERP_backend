
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class ChucVuRespository : IChucVuRepository
	{
		private readonly QlySanXuatErpContext _context;

		public ChucVuRespository(QlySanXuatErpContext context)
		{
			_context = context;
		}

		public async Task<ChucVu> Add(ChucVu input)
		{
			var result = _context.ChucVus.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<ChucVu> Delete(ChucVu input)
		{
			var result = _context.ChucVus.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<IEnumerable<ChucVu>> GetAll()
		{
			return await _context.ChucVus.ToListAsync();

		}

		public async Task<ChucVu> GetById(Guid id)
		{
			return await _context.ChucVus.FindAsync(id);

		}

		public async Task<ChucVu> Update(ChucVu input)
		{
			var result = _context.ChucVus.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
	}
}
