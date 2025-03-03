using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class KhoService : IKhoService
	{
		private readonly IKhoRepository _KhoRepository;

		public KhoService(IKhoRepository KhoRepository)
		{
			_KhoRepository = KhoRepository;
		}
		public async Task<KhoDto> Add(KhoDto input)
		{
			var convertData = ConvertDtoToKho(input);
			var result = await _KhoRepository.Add(convertData);
			return ConvertKhoToDto(result);
		}

		public async Task<KhoDto> Delete(KhoDto input)
		{
			var convertData = ConvertDtoToKho(input);
			var result = await _KhoRepository.Delete(convertData);
			return ConvertKhoToDto(result);
		}

		public async Task<IEnumerable<KhoDto>> GetAll()
		{
			var result = await _KhoRepository.GetAll();
			return ConvertListKhoToDto(result);
		}

		public async Task<KhoDto> GetById(Guid id)
		{
			var result = await _KhoRepository.GetById(id);
			return ConvertKhoToDto(result);
		}

		public async Task<KhoDto> Update(KhoDto input)
		{
			var convertData = ConvertDtoToKho(input);
			var result = await _KhoRepository.Update(convertData);
			return ConvertKhoToDto(result);
		}
		private KhoDto ConvertKhoToDto(Kho input)
		{
			var result = new KhoDto();
			if (input == null)
			{
				return result;
			}
			result.MaKho = input.MaKho;
			result.TenKho = input.TenKho;
			result.DiaChi = input.DiaChi;
			result.TrangThai = input.TrangThai;
			return result;
		}

		private IEnumerable<KhoDto> ConvertListKhoToDto(IEnumerable<Kho> input)
		{
			var result = new List<KhoDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertKhoToDto(item));
			}

			return result;
		}

		private Kho ConvertDtoToKho(KhoDto input)
		{
			var result = new Kho();
			if (input == null)
			{
				return result;
			}
			result.MaKho = input.MaKho;
			result.TenKho = input.TenKho;
			result.DiaChi = input.DiaChi;
			result.TrangThai = input.TrangThai;
			return result;
		}

		private IEnumerable<Kho> ConvertListDtoToKho(IEnumerable<KhoDto> input)
		{
			var result = new List<Kho>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToKho(item));
			}

			return result;
		}
	}

}
