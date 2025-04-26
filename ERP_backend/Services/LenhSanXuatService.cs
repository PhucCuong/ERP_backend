using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace ERP_backend.Services
{
	public class LenhSanXuatService : ILenhSanXuatService
	{
		private readonly ILenhSanXuatRepository _lenhSanXuatRepository;
		private readonly IDinhMucNguyenVatLieuRepository _dinhMucRepository;
		private readonly INguyenVatLieuRepository _nguyenVatLieuRepository;
		public LenhSanXuatService(
				ILenhSanXuatRepository lenhSanXuatRepository,
				IDinhMucNguyenVatLieuRepository dinhMucRepository,
				INguyenVatLieuRepository nguyenVatLieuRepository)
		{
			_lenhSanXuatRepository = lenhSanXuatRepository;
			_dinhMucRepository = dinhMucRepository;
			_nguyenVatLieuRepository = nguyenVatLieuRepository;
		}
		public async Task<LenhSanXuatDto> Add(LenhSanXuatDto input)
		{
			var convertData = ConvertDtoToLenhSanXuat(input);
			var result = await _lenhSanXuatRepository.Add(convertData);
			return ConvertLenhSanXuatToDto(result);
		}
		public async Task<bool> Delete(int id)
		{
			// Bước 1: Lấy thông tin lệnh sản xuất cần xóa
			var lenh = await _lenhSanXuatRepository.GetById(id);
			if (lenh == null)
			{
				throw new Exception("Không tìm thấy lệnh sản xuất để xóa.");
			}

			bool canHoanTonKho = true;

			// Bước 2: Nếu có MaKeHoach thì chỉ được trừ tồn kho một lần duy nhất
			if (lenh.MaKeHoach != 0)
			{
				var otherWithSameMaKeHoach = await _lenhSanXuatRepository
					.GetByConditionAsync(l => l.MaKeHoach == lenh.MaKeHoach && l.MaLenh != lenh.MaLenh);

				// Nếu còn lệnh khác cùng MaKeHoach, thì không hoàn tồn kho
				if (otherWithSameMaKeHoach.Any())
				{
					canHoanTonKho = false;
				}
			}

			// Bước 3: Nếu được phép hoàn tồn kho thì cập nhật lại số lượng tồn
			if (canHoanTonKho)
			{
				var dinhMucList = await _dinhMucRepository
					.GetByConditionAsync(dm => dm.MaDinhMuc == lenh.MaDinhMuc);

				foreach (var dinhMuc in dinhMucList)
				{
					var nguyenVatLieu = await _nguyenVatLieuRepository.GetById(dinhMuc.MaNguyenVatLieu);
					if (nguyenVatLieu == null)
					{
						throw new Exception($"Không tìm thấy nguyên vật liệu với mã: {dinhMuc.MaNguyenVatLieu}");
					}

					// Cộng lại vào tồn kho
					decimal soLuongHoanLai = dinhMuc.SoLuong * lenh.SoLuong;
					nguyenVatLieu.TonKhoHienCo += soLuongHoanLai;

					await _nguyenVatLieuRepository.Update(nguyenVatLieu);
				}
			}

			// Bước 4: Xóa tất cả các lệnh sản xuất có cùng MaLenh
			var lenhSanXuatList = await _lenhSanXuatRepository
				.GetByConditionAsync(l => l.MaLenh == lenh.MaLenh);

			if (lenhSanXuatList == null || !lenhSanXuatList.Any())
			{
				throw new Exception("Không tìm thấy lệnh sản xuất nào để xóa.");
			}

			foreach (var item in lenhSanXuatList)
			{
				bool deleted = await _lenhSanXuatRepository.Delete(item.MaLenh);
				if (!deleted)
				{
					throw new Exception($"Lỗi khi xóa lệnh sản xuất với ID {item.MaLenh}");
				}
			}

			return true;
		}


		public async Task<IEnumerable<LenhSanXuatDto>> GetAll()
		{
			var result = await _lenhSanXuatRepository.GetAll();
			return ConvertListLenhSanXuatToDto(result);
		}

		public async Task<LenhSanXuatDto> GetById(int id)
		{
			var result = await _lenhSanXuatRepository.GetById(id);
			return ConvertLenhSanXuatToDto(result);
		}

		public async Task<LenhSanXuatDto> Update(LenhSanXuatDto input)
		{
			var convertData = ConvertDtoToLenhSanXuat(input);
			var result = await _lenhSanXuatRepository.Update(convertData);
			return ConvertLenhSanXuatToDto(result);
		}
		public static LenhSanXuatDto ConvertLenhSanXuatToDto(LenhSanXuat input)
		{
			var result = new LenhSanXuatDto();
			if (input == null)
			{
				return result;
			}
            // LSX/00001
            result.MaLenh = "LSX/" + input.MaLenh.ToString().PadLeft(5,'0');
			result.MaKeHoach = input.MaKeHoach;
			result.MaQuyTrinh = input.MaQuyTrinh;
			result.MaSanPham = input.MaSanPham;
			result.SoLuong = input.SoLuong;
			result.NgayBatDau = input.NgayBatDau;
			result.NgayKetThuc = input.NgayKetThuc;
			result.TrangThai = input.TrangThai;
			result.NguoiChiuTrachNhiem = input.NguoiChiuTrachNhiem;
			result.MaDinhMuc = input.MaDinhMuc;
			result.KhuVucSanXuat = input.KhuVucSanXuat;
			return result;
		}

		private IEnumerable<LenhSanXuatDto> ConvertListLenhSanXuatToDto(IEnumerable<LenhSanXuat> input)
		{
			var result = new List<LenhSanXuatDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertLenhSanXuatToDto(item));
			}

			return result;
		}

		private LenhSanXuat ConvertDtoToLenhSanXuat(LenhSanXuatDto input)
		{
			var result = new LenhSanXuat();
			if (input == null)
			{
				return result;
			}
			// LSX/00001
			result.MaKeHoach = input.MaKeHoach;
			result.MaQuyTrinh = input.MaQuyTrinh;
			result.MaSanPham = input.MaSanPham;
			result.SoLuong = input.SoLuong;
			result.NgayBatDau = input.NgayBatDau;
			result.NgayKetThuc = input.NgayKetThuc;
			result.TrangThai = input.TrangThai;
			result.NguoiChiuTrachNhiem = input.NguoiChiuTrachNhiem;
			result.MaDinhMuc = input.MaDinhMuc;
			result.KhuVucSanXuat = input.KhuVucSanXuat;
			return result;
		}

		private IEnumerable<LenhSanXuat> ConvertListDtoToLenhSanXuat(IEnumerable<LenhSanXuatDto> input)
		{
			var result = new List<LenhSanXuat>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToLenhSanXuat(item));
			}

			return result;
		}

		public async Task<bool> AddListWorkOrder(ThemNhieuLenhSanXuatDto modelReq)
		{
			// Truy cập trực tiếp modelReq.MaSanPham, modelReq.MaDinhMuc nếu cần
			var dinhMucList = await _dinhMucRepository.GetByConditionAsync(dm =>
				dm.MaSanPham == modelReq.MaSanPham /* && dm.MaDinhMuc == ??? */);

			if (dinhMucList == null || !dinhMucList.Any())
			{
				throw new Exception($"Không tìm thấy định mức cho sản phẩm có mã: {modelReq.MaSanPham}");
			}

			foreach (var dinhMuc in dinhMucList)
			{
				var nguyenVatLieu = await _nguyenVatLieuRepository.GetById(dinhMuc.MaNguyenVatLieu);
				if (nguyenVatLieu == null)
					throw new Exception($"Không tìm thấy nguyên vật liệu với ID: {dinhMuc.MaNguyenVatLieu}");

				decimal soLuongTru = dinhMuc.SoLuong * modelReq.SoLuong;

				if (nguyenVatLieu.TonKhoHienCo < soLuongTru)
					throw new Exception($"Không đủ tồn kho cho nguyên vật liệu: {nguyenVatLieu.TenNguyenVatLieu}");

				nguyenVatLieu.TonKhoHienCo -= soLuongTru;

				await _nguyenVatLieuRepository.Update(nguyenVatLieu);
			}

			// Tùy bạn: có thể tạo 1 lệnh sản xuất hoặc danh sách nếu muốn
			var result = await _lenhSanXuatRepository.AddListWorkOrder(modelReq);
			return true;
		}


		public async Task<List<WorkOrder>> GetWorkOrderListByPlantCode(int plantCode)
		{
			var result = await _lenhSanXuatRepository.GetWorkOrderListByPlantCode(plantCode);
			return result;
        }

		public async Task<bool> UpdateStatusAndTime(UpdateStatusLenhSanXuat modelRequest)
		{
			var result = await _lenhSanXuatRepository.UpdateStatusAndTime(modelRequest);
			return result;
		}

    }

}
