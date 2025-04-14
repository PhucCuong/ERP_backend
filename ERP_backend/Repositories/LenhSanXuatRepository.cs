
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class LenhSanXuatRepository : ILenhSanXuatRepository
	{
		private readonly QlySanXuatErpContext _context;

		public LenhSanXuatRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<LenhSanXuat>> GetAll()
		{
			return await _context.LenhSanXuats.ToListAsync();
		}

		public async Task<LenhSanXuat> GetById(int id)
		{
			return await _context.LenhSanXuats.FindAsync(id);
		}

		public async Task<LenhSanXuat> Update(LenhSanXuat input)
		{
			var result = _context.LenhSanXuats.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<LenhSanXuat> Add(LenhSanXuat input)
		{
			var result = _context.LenhSanXuats.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<bool> Delete(int id)
		{
            // Tìm đối tượng LenhSanXuat theo id
            var lenhsx = await _context.LenhSanXuats.FindAsync(id);

            // Nếu không tìm thấy thì trả về false
            if (lenhsx == null)
            {
                return false;
            }

            // Xóa đối tượng
            _context.LenhSanXuats.Remove(lenhsx);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}
