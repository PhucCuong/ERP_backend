
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class LenhGoBoRepository : ILenhGoBoRepository
	{
		private readonly QlySanXuatErpContext _context;

		public LenhGoBoRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<LenhGoBo>> GetAll()
		{
			return await _context.LenhGoBos.ToListAsync();
		}

		public async Task<LenhGoBo> GetById(int id)
		{
			return await _context.LenhGoBos.FindAsync(id);
		}

		public async Task<LenhGoBo> Update(LenhGoBo input)
		{
			var result = _context.LenhGoBos.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<LenhGoBo> Add(LenhGoBo input)
		{
			var result = _context.LenhGoBos.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<LenhGoBo> Delete(LenhGoBo input)
		{
			var result = _context.LenhGoBos.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		
	}
}
