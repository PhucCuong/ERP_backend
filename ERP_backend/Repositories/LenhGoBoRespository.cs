
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

		public async Task<List<LenhGoBoResponse>> RenderLenhGoBo()
		{
            var result = await (from gb in _context.LenhGoBos
                                join sp in _context.SanPhams
                                on gb.MaSanPham equals sp.MaSanPham
                                select new LenhGoBoResponse
                                {
                                    MaLenhGoBo = gb.MaLenhGoBo,
                                    MaKeHoach = gb.MaKeHoach,
                                    TenSanPham = sp.TenSanPham,
                                    LyDoGoBo = gb.LyDoGoBo,
                                    TrangThai = gb.TrangThai,
                                    NguoiChiuTrachNhiem = gb.NguoiChiuTrachNhiem
                                }).ToListAsync();
			return result;
        }

		public async Task<bool> UpdateStatus(UpdateStatusLenhGoBo input)
		{
			var lenhgobo = await _context.LenhGoBos.FindAsync(input.MaLenhGoBo);
			lenhgobo.TrangThai = input.TrangThai;
			var result = await _context.SaveChangesAsync();
			return result > 0;
        }

    }
}
