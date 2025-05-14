using ERP_backend.DTOs;
using ERP_backend.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ERP_backend.Repositories
{
	public class BaoCaoSanXuatRepository : IBaoCaoSanXuatRepository
	{
		private readonly QlySanXuatErpContext _context;

		public BaoCaoSanXuatRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}

        public async Task<FilterChatLuongSanPham> filterChatLuongSanPham(FilterChatLuongSanPhamDto requestBody)
        {
            var query = _context.NhapKhos.AsQueryable();

            // Lọc theo MaSanPham nếu khác "All"
            if (!string.IsNullOrEmpty(requestBody.MaSanPham) && requestBody.MaSanPham != "All")
            {
                if (Guid.TryParse(requestBody.MaSanPham, out Guid maSanPhamGuid))
                {
                    query = query.Where(nk => nk.MaSanPham == maSanPhamGuid);
                }
                else
                {
                    throw new ArgumentException("Mã sản phẩm không hợp lệ.");
                }
            }

            // Lọc theo ngày nếu có
            if (requestBody.NgayBatDau.HasValue && requestBody.NgayKetThuc.HasValue)
            {
                var endDateInclusive = requestBody.NgayKetThuc.Value.AddDays(1);
                query = query.Where(nk => nk.NgayNhap >= requestBody.NgayBatDau.Value &&
                                          nk.NgayNhap < endDateInclusive);
            }

            var tongSanPham = await query.CountAsync();
            var sanPhamChoDuyet = await query.Where(x => x.TrangThai == "Watting").CountAsync();
            var sanPhamDatYeuCau = await query.Where(x => x.TrangThai == "Passed").CountAsync();
            var sanPhamKhongDat = await query.Where(x => x.TrangThai == "Failed").CountAsync();

            return new FilterChatLuongSanPham
            {
                TongSanPham = tongSanPham,
                SanPhamChoDuyet = sanPhamChoDuyet,
                SanPhamDatYeuCau = sanPhamDatYeuCau,
                SanPhamKhongDatYeuCau = sanPhamKhongDat
            };
        }

        public async Task<BaoCaoTongHopSanXuat> GetTienDoSanXuat(FilterTienDoSanXuatDto requestBody)
        {
            var query = _context.LenhSanXuats.AsQueryable();

            // Lọc theo MaSanPham nếu khác "All"
            if (!string.IsNullOrEmpty(requestBody.MaSanPham) && requestBody.MaSanPham != "All")
            {
                if (Guid.TryParse(requestBody.MaSanPham, out Guid maSanPhamGuid))
                {
                    query = query.Where(nk => nk.MaSanPham == maSanPhamGuid);
                }
                else
                {
                    throw new ArgumentException("Mã sản phẩm không hợp lệ.");
                }
            }

            // Lọc theo ngày nếu có
            if (requestBody.NgayBatDau.HasValue && requestBody.NgayKetThuc.HasValue)
            {
                var ngayBatDau = requestBody.NgayBatDau.Value.Date;
                var ngayKetThuc = requestBody.NgayKetThuc.Value.Date;

                query = query.Where(nk =>
                    nk.NgayBatDau.Date >= ngayBatDau &&
                    nk.NgayKetThuc.Date <= ngayKetThuc
                );
            }




            var tongLenh = await query.CountAsync();

            var soChuaBatDau = await query.CountAsync(x => x.TrangThai == "Ready");
            var soHoanThanh = await query.CountAsync(x => x.TrangThai == "Done");
            var soDangThucHien = await query.CountAsync(x => x.TrangThai == "Inprogress");
            var soTamDung = await query.CountAsync(x => x.TrangThai == "Pause");
            var soBiKhoa = await query.CountAsync(x => x.TrangThai == "Block");

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
