using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class NguyenVatLieuService : INguyenVatLieuService
	{
		private readonly INguyenVatLieuRepository _nguyenVatLieuRepository;

		public NguyenVatLieuService(INguyenVatLieuRepository nguyenVatLieuRepository)
		{
			_nguyenVatLieuRepository = nguyenVatLieuRepository;
		}
		public async Task<NguyenVatLieuDto> Add(NguyenVatLieuDto input)
		{
			var convertData = ConvertDtoToNguyenVatLieu(input);
			var result = await _nguyenVatLieuRepository.Add(convertData);
			return ConvertNguyenVatLieuToDto(result);
		}

		public async Task<NguyenVatLieuDto> Delete(NguyenVatLieuDto input)
		{
			var convertData = ConvertDtoToNguyenVatLieu(input);
			var result = await _nguyenVatLieuRepository.Delete(convertData);
			return ConvertNguyenVatLieuToDto(result);
		}

		public async Task<IEnumerable<NguyenVatLieuDto>> GetAll()
		{
			var result = await _nguyenVatLieuRepository.GetAll();
			return ConvertListNguyenVatLieuToDto(result);
		}

		public async Task<NguyenVatLieuDto> GetById(Guid id)
		{
			var result = await _nguyenVatLieuRepository.GetById(id);
			return ConvertNguyenVatLieuToDto(result);
		}

		public async Task<NguyenVatLieuDto> Update(NguyenVatLieuDto input)
		{
			var convertData = ConvertDtoToNguyenVatLieu(input);
			var result = await _nguyenVatLieuRepository.Update(convertData);
			return ConvertNguyenVatLieuToDto(result);
		}
		private NguyenVatLieuDto ConvertNguyenVatLieuToDto(NguyenVatLieu input)
		{
			var result = new NguyenVatLieuDto();
			if (input == null)
			{
				return result;
			}
			result.MaNguyenVatLieu = input.MaNguyenVatLieu;
			result.TenNguyenVatLieu = input.TenNguyenVatLieu;
			result.MaVach = input.MaVach;
			result.NhomNguyenVatLieu = input.NhomNguyenVatLieu;
			result.DonViTinh = input.DonViTinh;
			result.GiaNhap = input.GiaNhap;
			result.TonKhoToiThieu = input.TonKhoToiThieu;
			result.TonKhoToiDa = input.TonKhoToiDa;
			result.TonKhoHienCo= input.TonKhoHienCo;
			result.TrangThai = input.TrangThai;



			return result;
		}

		private IEnumerable<NguyenVatLieuDto> ConvertListNguyenVatLieuToDto(IEnumerable<NguyenVatLieu> input)
		{
			var result = new List<NguyenVatLieuDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertNguyenVatLieuToDto(item));
			}

			return result;
		}

		private NguyenVatLieu ConvertDtoToNguyenVatLieu(NguyenVatLieuDto input)
		{
			var result = new NguyenVatLieu();
			if (input == null)
			{
				return result;
			}
			result.MaNguyenVatLieu = input.MaNguyenVatLieu;
			result.TenNguyenVatLieu = input.TenNguyenVatLieu;
			result.MaVach = input.MaVach;
			result.NhomNguyenVatLieu = input.NhomNguyenVatLieu;
			result.DonViTinh = input.DonViTinh;
			result.GiaNhap = input.GiaNhap;
			result.TonKhoToiThieu = input.TonKhoToiThieu;
			result.TonKhoToiDa = input.TonKhoToiDa;
			result.TonKhoHienCo = input.TonKhoHienCo;
			result.TrangThai = input.TrangThai;

			return result;
		}
		private IEnumerable<NguyenVatLieu> ConvertListDtoToNguyenVatLieu(IEnumerable<NguyenVatLieuDto> input)
		{
			var result = new List<NguyenVatLieu>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToNguyenVatLieu(item));
			}

			return result;
		}
	}

}
