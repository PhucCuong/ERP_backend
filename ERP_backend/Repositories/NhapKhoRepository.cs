
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class NhapKhoRepository : INhapKhoRepository
	{
		private readonly QlySanXuatErpContext _context;

		public NhapKhoRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<NhapKho>> GetAll()
		{
			return await _context.NhapKhos.ToListAsync();
		}

		public async Task<NhapKho> GetById(Guid id)
		{
			return await _context.NhapKhos.FindAsync(id);
		}

		public async Task<NhapKho> Update(NhapKho input)
		{
			var result = _context.NhapKhos.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<NhapKho> Add(NhapKho input)
		{
			var result = _context.NhapKhos.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<NhapKho> Delete(NhapKho input)
		{
			var result = _context.NhapKhos.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		
	}
}
