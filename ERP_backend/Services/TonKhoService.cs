using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class TonKhoService : ITonKhoService
	{
		private readonly ITonKhoRepository _TonKhoRepository;

		public TonKhoService(ITonKhoRepository TonKhoRepository)
		{
			_TonKhoRepository = TonKhoRepository;
		}
		public async Task<TonKhoDto> Add(TonKhoDto input)
		{
			var convertData = ConvertDtoToTonKho(input);
			var result = await _TonKhoRepository.Add(convertData);
			return ConvertTonKhoToDto(result);
		}

		public async Task<TonKhoDto> Delete(TonKhoDto input)
		{
			var convertData = ConvertDtoToTonKho(input);
			var result = await _TonKhoRepository.Delete(convertData);
			return ConvertTonKhoToDto(result);
		}

		public async Task<IEnumerable<TonKhoDto>> GetAll()
		{
			var result = await _TonKhoRepository.GetAll();
			return ConvertListTonKhoToDto(result);
		}

		public async Task<TonKhoDto> GetById(Guid id)
		{
			var result = await _TonKhoRepository.GetById(id);
			return ConvertTonKhoToDto(result);
		}

		public async Task<TonKhoDto> Update(TonKhoDto input)
		{
			var convertData = ConvertDtoToTonKho(input);
			var result = await _TonKhoRepository.Update(convertData);
			return ConvertTonKhoToDto(result);
		}
		private TonKhoDto ConvertTonKhoToDto(TonKho input)
		{
			var result = new TonKhoDto();
			if (input == null)
			{
				return result;
			}
			result.MaKho = input.MaKho;
			result.MaNguyenVatLieu = input.MaNguyenVatLieu;
			result.SoLuongTon = input.SoLuongTon;
			result.MucToiThieu = input.MucToiThieu;
			result.NgayCapNhatCuoi = input.NgayCapNhatCuoi;
			return result;
		}

		private IEnumerable<TonKhoDto> ConvertListTonKhoToDto(IEnumerable<TonKho> input)
		{
			var result = new List<TonKhoDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertTonKhoToDto(item));
			}

			return result;
		}

		private TonKho ConvertDtoToTonKho(TonKhoDto input)
		{
			var result = new TonKho();
			if (input == null)
			{
				return result;
			}
			result.MaKho = input.MaKho;
			result.MaNguyenVatLieu = input.MaNguyenVatLieu;
			result.SoLuongTon = input.SoLuongTon;
			result.MucToiThieu = input.MucToiThieu;
			result.NgayCapNhatCuoi = input.NgayCapNhatCuoi;
			return result;
		}

		private IEnumerable<TonKho> ConvertListDtoToTonKho(IEnumerable<TonKhoDto> input)
		{
			var result = new List<TonKho>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToTonKho(item));
			}

			return result;
		}
	}

}
