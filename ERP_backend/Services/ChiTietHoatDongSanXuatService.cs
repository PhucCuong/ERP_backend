using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class ChiTietHoatDongSanXuatService : IChiTietHoatDongSanXuatService
	{
		private readonly IChiTietHoatDongSanXuatRepository _chiTietHoatDongSanXuatRepository;

		public ChiTietHoatDongSanXuatService(IChiTietHoatDongSanXuatRepository chiTietHoatDongSanXuatRepository)
		{
			_chiTietHoatDongSanXuatRepository = chiTietHoatDongSanXuatRepository;
		}

		public async Task<ChiTietHoatDongSanXuatDto> Add(ChiTietHoatDongSanXuatDto input)
		{
			var convertData = ConvertDtoToChiTietHoatDongSanXuat(input);
			var result = await _chiTietHoatDongSanXuatRepository.Add(convertData);
			return ConvertChiTietHoatDongSanXuatToDto(result);
		}

		public async Task<ChiTietHoatDongSanXuatDto> Delete(ChiTietHoatDongSanXuatDto input)
		{
			var convertData = ConvertDtoToChiTietHoatDongSanXuat(input);
			var result = await _chiTietHoatDongSanXuatRepository.Delete(convertData);
			return ConvertChiTietHoatDongSanXuatToDto(result);
		}

		public async Task<IEnumerable<ChiTietHoatDongSanXuatDto>> GetAll()
		{
			var result = await _chiTietHoatDongSanXuatRepository.GetAll();
			return ConvertListChiTietHoatDongSanXuatToDto(result);
		}

		public async Task<ChiTietHoatDongSanXuatDto> GetById(Guid id)
		{
			var result = await _chiTietHoatDongSanXuatRepository.GetById(id);
			return ConvertChiTietHoatDongSanXuatToDto(result);
		}

		public async Task<ChiTietHoatDongSanXuatDto> Update(ChiTietHoatDongSanXuatDto input)
		{
			var convertData = ConvertDtoToChiTietHoatDongSanXuat(input);
			var result = await _chiTietHoatDongSanXuatRepository.Update(convertData);
			return ConvertChiTietHoatDongSanXuatToDto(result);
		}
		private ChiTietHoatDongSanXuatDto ConvertChiTietHoatDongSanXuatToDto(ChiTietHoatDongSanXuat input)
		{
			var result = new ChiTietHoatDongSanXuatDto();
			if (input == null)
			{
				return result;
			}
			result.MaHoatDong = input.MaHoatDong;
			result.MaQuyTrinh = input.MaQuyTrinh;
			result.TenHoatDong = input.TenHoatDong;
			result.GiaiDoanSanXuat = input.GiaiDoanSanXuat;
			result.ThuTu = input.ThuTu;
			result.SoLuongChoXuLy = input.SoLuongChoXuLy;
			result.LoaiTinhThoiGian = input.LoaiTinhThoiGian;
			result.ThoiGianMacDinh = input.ThoiGianMacDinh;
			result.DieuKienBatDauGiaiDoanTiepTheo = input.DieuKienBatDauGiaiDoanTiepTheo;
			result.MoTa = input.MoTa;


			return result;
		}

		private IEnumerable<ChiTietHoatDongSanXuatDto> ConvertListChiTietHoatDongSanXuatToDto(IEnumerable<ChiTietHoatDongSanXuat> input)
		{
			var result = new List<ChiTietHoatDongSanXuatDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertChiTietHoatDongSanXuatToDto(item));
			}

			return result;
		}

		private ChiTietHoatDongSanXuat ConvertDtoToChiTietHoatDongSanXuat(ChiTietHoatDongSanXuatDto input)
		{
			var result = new ChiTietHoatDongSanXuat();
			if (input == null)
			{
				return result;
			}
			result.MaHoatDong = input.MaHoatDong;
			result.MaQuyTrinh = input.MaQuyTrinh;	
			result.TenHoatDong = input.TenHoatDong;
			result.GiaiDoanSanXuat = input.GiaiDoanSanXuat		;
			result.ThuTu = input.ThuTu;
			result.SoLuongChoXuLy = input.SoLuongChoXuLy;
			result.LoaiTinhThoiGian = input.LoaiTinhThoiGian;
			result.ThoiGianMacDinh = input.ThoiGianMacDinh;
			result.DieuKienBatDauGiaiDoanTiepTheo = input.DieuKienBatDauGiaiDoanTiepTheo;
			result.MoTa = input.MoTa;
			

			return result;
		}

		private IEnumerable<ChiTietHoatDongSanXuat> ConvertListDtoToChiTietHoatDongSanXuat(IEnumerable<ChiTietHoatDongSanXuatDto> input)
		{
			var result = new List<ChiTietHoatDongSanXuat>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToChiTietHoatDongSanXuat(item));
			}

			return result;
		}
	}
}
