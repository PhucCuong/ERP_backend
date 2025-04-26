
using System.Linq;
using ERP_backend.DTOs;
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

		public async Task<NhapKho> GetById(string id)
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

        public async Task<bool> AddList(AddListNhapKhoDto addListNhapKhoDto)
        {
            for (int i = 1; i <= addListNhapKhoDto.SoLuongNhap; i++)
            {
                var soseri = $"{addListNhapKhoDto.MaKeHoach}{i.ToString("D5")}";

                var nhapKho = new NhapKho
                {
                    Soseri = soseri,
                    MaSanPham = addListNhapKhoDto.MaSanPham,
                    NgayNhap = addListNhapKhoDto.NgayNhap,
                    NguoiNhap = addListNhapKhoDto.NguoiNhap,
                    TrangThai = addListNhapKhoDto.TrangThai,
                    MoTa = addListNhapKhoDto.MoTa,
                    NgayTao = addListNhapKhoDto.NgayTao ?? DateTime.UtcNow,
                    NgayChinhSua = addListNhapKhoDto.NgayChinhSua
                };

                await Add(nhapKho);
            }

            return true;
        }

        public async Task<List<ChatLuongSanPham>> GetAllListCheckQuality()
        {
            var result = await (from nk in _context.NhapKhos
                                join sp in _context.SanPhams
                                on nk.MaSanPham equals sp.MaSanPham
                                where nk.TrangThai == "Watting"
                                select new ChatLuongSanPham
                                {
                                    Soseri = nk.Soseri,
                                    TenSanPham = sp.TenSanPham, 
                                    NgayNhap = nk.NgayNhap,
                                    NguoiNhap = nk.NguoiNhap
                                }).ToListAsync();

            return result;
        }
    }
}
