using ERP_backend.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class BaoCaoSanXuatRepository : IBaoCaoSanXuatRepository
	{
		private readonly QlySanXuatErpContext _context;

		public BaoCaoSanXuatRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}

        public async Task<BaoCaoTongHopSanXuat> GetTienDoSanXuat()
        {
            var tongLenh = await _context.LenhSanXuats.CountAsync();

            var soChuaBatDau = await _context.LenhSanXuats
                .CountAsync(x => x.TrangThai == "Ready");

            var soHoanThanh = await _context.LenhSanXuats
                .CountAsync(x => x.TrangThai == "Done");

            var soDangThucHien = await _context.LenhSanXuats
                .CountAsync(x => x.TrangThai == "Inprogress");

            var soTamDung = await _context.LenhSanXuats
                .CountAsync(x => x.TrangThai == "Pause");

            var soBiKhoa = await _context.LenhSanXuats
                .CountAsync(x => x.TrangThai == "Block");

            return new BaoCaoTongHopSanXuat
            {
                TongLenhSanXuat = tongLenh,
                SoLenhSanXuatChuaBatDau = soChuaBatDau,
                SoLenhSanXuatHoanThanh = soHoanThanh,
                SoLenhSanXuatDangThucHien = soDangThucHien,
                SoLenhSanXuatTamDung = soTamDung,
                SoLenhSanXuatBiKhoa = soBiKhoa
            };
        }

        public async Task<List<BaoCaoSanPhamSanXuat>> GetTongQuanSoLuongSanPham()
        {
            var result = await (from k in _context.KeHoachSanXuats
                                join sp in _context.SanPhams on k.MaSanPham equals sp.MaSanPham
                                group new { k, sp } by k.MaSanPham into grouped
                                select new BaoCaoSanPhamSanXuat
                                {
                                    MaSanPham = grouped.Key,  // MaSanPham của nhóm
                                    TenSanPham = grouped.Select(g => g.sp.TenSanPham).FirstOrDefault(),  // Truy cập TenSanPham từ bảng SanPham
                                    SoLuong = grouped.Sum(g => g.k.SoLuong)  // Tính tổng SoLuong
                                })
                            .ToListAsync();

            return result;
        }


    }
}
