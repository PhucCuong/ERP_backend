using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class NhapKhoService : INhapKhoService
	{
		private readonly INhapKhoRepository _nhapKhoRepository;

		public NhapKhoService(INhapKhoRepository nhapKhoRepository)
		{
			_nhapKhoRepository = nhapKhoRepository;
		}
		public async Task<NhapKhoDto> Add(NhapKhoDto input)
		{
			var convertData = ConvertDtoToNhapKho(input);
			var result = await _nhapKhoRepository.Add(convertData);
			return ConvertNhapKhoToDto(result);
		}

		public async Task<NhapKhoDto> Delete(NhapKhoDto input)
		{
			var convertData = ConvertDtoToNhapKho(input);
			var result = await _nhapKhoRepository.Delete(convertData);
			return ConvertNhapKhoToDto(result);
		}

		public async Task<IEnumerable<NhapKhoDto>> GetAll()
		{
			var result = await _nhapKhoRepository.GetAll();
			return ConvertListNhapKhoToDto(result);
		}

		public async Task<NhapKhoDto> GetById(string id)
		{
			var result = await _nhapKhoRepository.GetById(id);
			return ConvertNhapKhoToDto(result);
		}

		public async Task<NhapKhoDto> Update(NhapKhoDto input)
		{
			var convertData = ConvertDtoToNhapKho(input);
			var result = await _nhapKhoRepository.Update(convertData);
			return ConvertNhapKhoToDto(result);
		}
		private NhapKhoDto ConvertNhapKhoToDto(NhapKho input)
		{
			var result = new NhapKhoDto();
			if (input == null)
			{
				return result;
			}
			result.Soseri = input.Soseri;
			result.MaSanPham = input.MaSanPham;
			result.SoLuong = input.SoLuong;
			result.NgayNhap = input.NgayNhap;
			result.NguoiNhap = input.NguoiNhap;
			result.TrangThai = input.TrangThai;
			result.MoTa = input.MoTa;
			result.NgayTao = input.NgayTao;
			result.NgayChinhSua = input.NgayTao;
			return result;
		}

		private IEnumerable<NhapKhoDto> ConvertListNhapKhoToDto(IEnumerable<NhapKho> input)
		{
			var result = new List<NhapKhoDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertNhapKhoToDto(item));
			}

			return result;
		}

		private NhapKho ConvertDtoToNhapKho(NhapKhoDto input)
		{
			var result = new NhapKho();
			if (input == null)
			{
				return result;
			}
			result.Soseri = input.Soseri;
			result.MaSanPham = input.MaSanPham;
			result.SoLuong = input.SoLuong;
			result.NgayNhap = input.NgayNhap;
			result.NguoiNhap = input.NguoiNhap;
			result.TrangThai = input.TrangThai;
			result.MoTa = input.MoTa;
			result.NgayTao = input.NgayTao;
			result.NgayChinhSua = input.NgayTao;
			return result;
		}

		private IEnumerable<NhapKho> ConvertListDtoToNhapKho(IEnumerable<NhapKhoDto> input)
		{
			var result = new List<NhapKho>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToNhapKho(item));
			}

			return result;
		}
	}

}
