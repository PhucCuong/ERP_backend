
using ERP_backend.DTOs;
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

			var lenhsx = await _context.LenhSanXuats.FindAsync(id);

			if (lenhsx == null)
			{
				return false;
			}

			_context.LenhSanXuats.Remove(lenhsx);
			var result = await _context.SaveChangesAsync();

			return result > 0;
		}

		public async Task<bool> AddListWorkOrder(ThemNhieuLenhSanXuatDto modelReq)
		{
			// Bước 1: Lấy danh sách các MaHoatDong từ ChiTietHoatDongSanXuat theo thứ tự
			var danhSachMaHoatDong = await _context.ChiTietHoatDongSanXuats
				.Where(x => x.MaQuyTrinh == modelReq.MaQuyTrinh)
				.OrderBy(x => x.ThuTu)
				.Select(x => x.MaHoatDong)
				.ToListAsync();

			// Kiểm tra nếu không có dữ liệu thì dừng
			if (danhSachMaHoatDong == null || !danhSachMaHoatDong.Any())
				throw new Exception("Không tìm thấy hoạt động sản xuất cho quy trình này!");

			// Bước 2: Với mỗi MaHoatDong, tạo một lệnh sản xuất tương ứng
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
					KhuVucSanXuat = modelReq.KhuVucSanXuat?.ToString(), // Đảm bảo null-safe nếu KhuVucSanXuat là Guid?
					MaHoatDong = maHoatDong,
					// TODO: Chỗ này bạn cần lấy đúng MaDinhMuc từ DB hoặc tính toán tương ứng:
					MaDinhMuc = await LayMaDinhMucTheoSanPham(modelReq.MaSanPham)
				};

				await Add(lenhSanXuat); // Giả định hàm Add xử lý lưu vào DB và kiểm tra tồn kho v.v...
			}

			return true;
		}
		private async Task<Guid> LayMaDinhMucTheoSanPham(Guid maSanPham)
		{
			var dinhMuc = await _context.DinhMucNguyenVatLieus
				.Where(dm => dm.MaSanPham == maSanPham)
				.OrderByDescending(dm => dm.NgayTao) // Ưu tiên cái mới nhất?
				.FirstOrDefaultAsync();

			if (dinhMuc == null)
				throw new Exception($"Không tìm thấy định mức cho sản phẩm có mã: {maSanPham}");

			return dinhMuc.MaDinhMuc;
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
                            ThoiGianThucTe = lsx.ThoiGianThucTe,
                            DieuKienBatDauGiaiDoanTiepTheo = hdsx.DieuKienBatDauGiaiDoanTiepTheo,
                        };

            return await query.ToListAsync();
        }

        public async Task<bool> UpdateStatusAndTime(UpdateStatusLenhSanXuat modelRequest)
        {
            var lsx = await _context.LenhSanXuats.FindAsync(modelRequest.MaLenh);

            lsx.TrangThai = modelRequest.TrangThai;
            lsx.ThoiGianThucTe = modelRequest.ThoiGianThucTe;

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
		public async Task<IEnumerable<LenhSanXuat>> GetByConditionAsync(Expression<Func<LenhSanXuat, bool>> predicate)
		{
			return await _context.Set<LenhSanXuat>().Where(predicate).ToListAsync();
		}

	}
}
