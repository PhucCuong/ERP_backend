
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

    }
}
