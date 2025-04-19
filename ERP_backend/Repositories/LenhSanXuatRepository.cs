
using ERP_backend.DTOs;
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

        public async Task<bool> AddListWorkOrder(ThemNhieuLenhSanXuatDto modelReq)
        {
            // Bước 1: Lấy danh sách các MaHoatDong từ ChiTietHoatDongSanXuat
            var danhSachMaHoatDong = await _context.ChiTietHoatDongSanXuats
                .Where(x => x.MaQuyTrinh == modelReq.MaQuyTrinh)
                .OrderBy(x => x.ThuTu)
                .Select(x => x.MaHoatDong)
                .ToListAsync();

            // Kiểm tra nếu không có dữ liệu
            if (danhSachMaHoatDong == null || !danhSachMaHoatDong.Any())
                return false;

            // Bước 2: Với mỗi MaHoatDong, map sang LenhSanXuat và gọi hàm Add
            foreach (var maHoatDong in danhSachMaHoatDong)
            {
                var lenhSanXuat = new LenhSanXuat
                {
                    MaKeHoach = modelReq.MaKeHoach,
                    MaQuyTrinh = modelReq.MaQuyTrinh,
                    MaSanPham = modelReq.MaSanPham,
                    NgayBatDau = modelReq.NgayBatDau,
                    NgayKetThuc = modelReq.NgayKetThuc,
                    NguoiChiuTrachNhiem = modelReq.NguoiChiuTrachNhiem,
                    SoLuong = modelReq.SoLuong,
                    TrangThai = modelReq.TrangThai,
                    KhuVucSanXuat = modelReq.KhuVucSanXuat.ToString(), // vì model là Guid, DB là string
                    MaHoatDong = maHoatDong,
                    MaDinhMuc = Guid.NewGuid() // nếu bạn cần tạo mới, hoặc bạn có logic khác thì chỉnh lại
                };

                // Gọi hàm Add (giả sử đã tồn tại)
                await Add(lenhSanXuat);
            }

            return true;
        }

        public async Task<List<WorkOrder>> GetWorkOrderListByPlantCode(int plantCode)
        {
            var query = from lsx in _context.LenhSanXuats
                        join hdsx in _context.ChiTietHoatDongSanXuats
                            on lsx.MaHoatDong equals hdsx.MaHoatDong
                        join qt in _context.QuyTrinhSanXuats
                            on hdsx.MaQuyTrinh equals qt.MaQuyTrinh
                        join sp in _context.SanPhams
                            on qt.MaSanPham equals sp.MaSanPham
                        where lsx.MaKeHoach == plantCode
                        select new WorkOrder
                        {
                            MaLenh = "LSX/" + lsx.MaLenh.ToString().PadLeft(5,'0'),
                            MaKeHoach = lsx.MaKeHoach,
                            SoLuong = lsx.SoLuong,
                            NgayBatDau = lsx.NgayBatDau,
                            NgayKetThuc = lsx.NgayKetThuc,
                            TrangThai = lsx.TrangThai,
                            NguoiChiuTrachNhiem = lsx.NguoiChiuTrachNhiem,
                            KhuVucSanXuat = lsx.KhuVucSanXuat,

                            TenHoatDong = hdsx.TenHoatDong,
                            ThuTu = hdsx.ThuTu,

                            TenQuyTrinh = qt.TenQuyTrinh,
                            TenSanPham = sp.TenSanPham,
                            ThoiGianDuKien = hdsx.ThoiGianMacDinh,
                            ThoiGianThucTe = lsx.ThoiGianThucTe
                        };

            return await query.ToListAsync();
        }


    }
}
