using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class ChucVuService : IChucVuService
	{
		private readonly IChucVuRepository _ChucVuRepository;

		public ChucVuService(IChucVuRepository ChucVuRepository)
		{
			_ChucVuRepository = ChucVuRepository;
		}
		public async Task<ChucVuDto> Add(ChucVuDto input)
		{
			var convertData = ConvertDtoToChucVu(input);
			var result = await _ChucVuRepository.Add(convertData);
			return ConvertChucVuToDto(result);
		}

		public async Task<ChucVuDto> Delete(ChucVuDto input)
		{
			var convertData = ConvertDtoToChucVu(input);
			var result = await _ChucVuRepository.Delete(convertData);
			return ConvertChucVuToDto(result);
		}

		public async Task<IEnumerable<ChucVuDto>> GetAll()
		{
			var result = await _ChucVuRepository.GetAll();
			return ConvertListChucVuToDto(result);
		}

		public async Task<ChucVuDto> GetById(Guid id)
		{
			var result = await _ChucVuRepository.GetById(id);
			return ConvertChucVuToDto(result);
		}

		public async Task<ChucVuDto> Update(ChucVuDto input)
		{
			var convertData = ConvertDtoToChucVu(input);
			var result = await _ChucVuRepository.Update(convertData);
			return ConvertChucVuToDto(result);
		}
		private ChucVuDto ConvertChucVuToDto(ChucVu input)
		{
			var result = new ChucVuDto();
			if (input == null)
			{
				return result;
			}
			result.MaChucVu = input.MaChucVu;
			
			result.TenChucVu = input.TenChucVu;
			return result;
		}

		private IEnumerable<ChucVuDto> ConvertListChucVuToDto(IEnumerable<ChucVu> input)
		{
			var result = new List<ChucVuDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertChucVuToDto(item));
			}

			return result;
		}

		private ChucVu ConvertDtoToChucVu(ChucVuDto input)
		{
			var result = new ChucVu();
			if (input == null)
			{
				return result;
			}
			result.MaChucVu = input.MaChucVu;
			
			result.TenChucVu = input.TenChucVu;
			
			return result;
		}

		private IEnumerable<ChucVu> ConvertListDtoToChucVu(IEnumerable<ChucVuDto> input)
		{
			var result = new List<ChucVu>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToChucVu(item));
			}

			return result;
		}
	}

}
