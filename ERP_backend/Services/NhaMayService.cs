using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class NhaMayService : INhaMayService
	{
		private readonly INhaMayRepository _nhaMayRepository;

		public NhaMayService(INhaMayRepository nhaMayRepository)
		{
			_nhaMayRepository = nhaMayRepository;
		}
		public async Task<NhaMayDto> Add(NhaMayDto input)
		{
			var convertData = ConvertDtoToNhaMay(input);
			var result = await _nhaMayRepository.Add(convertData);
			return ConvertNhaMayToDto(result);
		}

		public async Task<NhaMayDto?> Delete(NhaMayDto input)
		{
			var existingNhaMay = await _nhaMayRepository.GetById(input.MaNhaMay);

			if (existingNhaMay == null)
			{
				return null; // Hoặc throw NotFoundException
			}

			var result = await _nhaMayRepository.Delete(existingNhaMay);
			return ConvertNhaMayToDto(result);
		}

		public async Task<IEnumerable<NhaMayDto>> GetAll()
		{
			var result = await _nhaMayRepository.GetAll();
			return ConvertListNhaMayToDto(result);
		}

		public async Task<NhaMayDto> GetById(Guid id)
		{
			var result = await _nhaMayRepository.GetById(id);
			return ConvertNhaMayToDto(result);
		}

		public async Task<NhaMayDto> Update(NhaMayDto input)
		{
			var convertData = ConvertDtoToNhaMay(input);
			var result = await _nhaMayRepository.Update(convertData);
			return ConvertNhaMayToDto(result);
		}
		private NhaMayDto ConvertNhaMayToDto(NhaMay input)
		{
			var result = new NhaMayDto();
			if (input == null)
			{
				return result;
			}
			result.MaNhaMay = input.MaNhaMay;
			result.TenNhaMay = input.TenNhaMay;
			result.PhanLoai = input.PhanLoai;
			result.DiaChi = input.DiaChi;
			result.SoDienThoai = input.SoDienThoai;
			result.NguoiQuanLy = input.NguoiQuanLy;
			result.ChiPhi = input.ChiPhi;



			return result;
		}

		private IEnumerable<NhaMayDto> ConvertListNhaMayToDto(IEnumerable<NhaMay> input)
		{
			var result = new List<NhaMayDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertNhaMayToDto(item));
			}

			return result;
		}

		private NhaMay ConvertDtoToNhaMay(NhaMayDto input)
		{
			var result = new NhaMay();
			if (input == null)
			{
				return result;
			}
			result.TenNhaMay = input.TenNhaMay;
			result.PhanLoai = input.PhanLoai;
			result.DiaChi = input.DiaChi;
			result.SoDienThoai = input.SoDienThoai;
			result.NguoiQuanLy = input.NguoiQuanLy;
			result.ChiPhi = input.ChiPhi;
			return result;
		}

		private IEnumerable<NhaMay> ConvertListDtoToNhaMay(IEnumerable<NhaMayDto> input)
		{
			var result = new List<NhaMay>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToNhaMay(item));
			}

			return result;
		}
	}

}
