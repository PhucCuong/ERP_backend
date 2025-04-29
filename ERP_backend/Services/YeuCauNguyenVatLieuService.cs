using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class YeuCauNguyenVatLieuService : IYeuCauNguyenVatLieuService
	{
		private readonly IYeuCauNguyenVatLieuRepository _yeuCauNguyenVatLieuRepository;

		public YeuCauNguyenVatLieuService(IYeuCauNguyenVatLieuRepository yeuCauNguyenVatLieuRepository)
		{
			_yeuCauNguyenVatLieuRepository = yeuCauNguyenVatLieuRepository;
		}
		public async Task<YeuCauNguyenVatLieuDto> Add(YeuCauNguyenVatLieuDto input)
		{
			var convertData = ConvertDtoToYeuCauNguyenVatLieu(input);
			var result = await _yeuCauNguyenVatLieuRepository.Add(convertData);
			return ConvertYeuCauNguyenVatLieuToDto(result);
		}

		public async Task<YeuCauNguyenVatLieuDto> Delete(YeuCauNguyenVatLieuDto input)
		{
			var convertData = ConvertDtoToYeuCauNguyenVatLieu(input);
			var result = await _yeuCauNguyenVatLieuRepository.Delete(convertData);
			return ConvertYeuCauNguyenVatLieuToDto(result);
		}

		public async Task<IEnumerable<YeuCauNguyenVatLieuDto>> GetAll()
		{
			var result = await _yeuCauNguyenVatLieuRepository.GetAll();
			return ConvertListYeuCauNguyenVatLieuToDto(result);
		}

		public async Task<YeuCauNguyenVatLieuDto> GetById(Guid id)
		{
			var result = await _yeuCauNguyenVatLieuRepository.GetById(id);
			return ConvertYeuCauNguyenVatLieuToDto(result);
		}

		public async Task<YeuCauNguyenVatLieuDto> Update(YeuCauNguyenVatLieuDto input)
		{
			var convertData = ConvertDtoToYeuCauNguyenVatLieu(input);
			var result = await _yeuCauNguyenVatLieuRepository.Update(convertData);
			return ConvertYeuCauNguyenVatLieuToDto(result);
		}
		private YeuCauNguyenVatLieuDto ConvertYeuCauNguyenVatLieuToDto(YeuCauNguyenVatLieu input)
		{
			var result = new YeuCauNguyenVatLieuDto();
			if (input == null)
			{
				return result;
			}
			result.MaYeuCauNvl = input.MaYeuCauNvl;
			result.MaNguyenVatLieu = input.MaNguyenVatLieu;
			result.SoLuongCanThiet = input.SoLuongCanThiet;
			result.MaNhaCungCap = input.MaNhaCungCap;
			result.NgayGiaoHangDuKien = input.NgayGiaoHangDuKien;
			result.NgayTao = input.NgayTao;
			result.TongTien = input.TongTien;
			return result;
		}

		private IEnumerable<YeuCauNguyenVatLieuDto> ConvertListYeuCauNguyenVatLieuToDto(IEnumerable<YeuCauNguyenVatLieu> input)
		{
			var result = new List<YeuCauNguyenVatLieuDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertYeuCauNguyenVatLieuToDto(item));
			}

			return result;
		}

		private YeuCauNguyenVatLieu ConvertDtoToYeuCauNguyenVatLieu(YeuCauNguyenVatLieuDto input)
		{
			var result = new YeuCauNguyenVatLieu();
			if (input == null)
			{
				return result;
			}
			result.MaYeuCauNvl = input.MaYeuCauNvl;
			result.MaNguyenVatLieu = input.MaNguyenVatLieu;
			result.SoLuongCanThiet = input.SoLuongCanThiet;
			result.MaNhaCungCap = input.MaNhaCungCap;
			result.NgayGiaoHangDuKien = input.NgayGiaoHangDuKien;
			result.NgayTao = input.NgayTao;
			result.TongTien = input.TongTien;
			return result;
		}

		private IEnumerable<YeuCauNguyenVatLieu> ConvertListDtoToYeuCauNguyenVatLieu(IEnumerable<YeuCauNguyenVatLieuDto> input)
		{
			var result = new List<YeuCauNguyenVatLieu>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToYeuCauNguyenVatLieu(item));
			}

			return result;
		}
	}

}
