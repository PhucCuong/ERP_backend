using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class BaoTriService : IBaoTriService
	{
		private readonly IBaoTriRepository _baoTriRepository;

		public BaoTriService(IBaoTriRepository baoTriRepository)
		{
			_baoTriRepository = baoTriRepository;
		}
		public async Task<BaoTriDto> Add(BaoTriDto input)
		{
			var convertData = ConvertDtoToBaoTri(input);
			var result = await _baoTriRepository.Add(convertData);
			return ConvertBaoTriToDto(result);
		}

		public async Task<BaoTriDto> Delete(BaoTriDto input)
		{
			var convertData = ConvertDtoToBaoTri(input);
			var result = await _baoTriRepository.Delete(convertData);
			return ConvertBaoTriToDto(result);
		}

		public async Task<IEnumerable<BaoTriDto>> GetAll()
		{
			var result = await _baoTriRepository.GetAll();
			return ConvertListBaoTriToDto(result);
		}

		public async Task<BaoTriDto> GetById(Guid id)
		{
			var result = await _baoTriRepository.GetById(id);
			return ConvertBaoTriToDto(result);
		}

		public async Task<BaoTriDto> Update(BaoTriDto input)
		{
			var convertData = ConvertDtoToBaoTri(input);
			var result = await _baoTriRepository.Update(convertData);
			return ConvertBaoTriToDto(result);
		}
		private BaoTriDto ConvertBaoTriToDto(BaoTri input)
		{
			var result = new BaoTriDto();
			if (input == null)
			{
				return result;
			}
			result.MaBaoTri = input.MaBaoTri;
			result.MaNhaMay = input.MaNhaMay;
			result.TenBaoTri = input.TenBaoTri;
			result.MoTa = input.MoTa;
			result.NgayBatDau = input.NgayBatDau;
			result.NgayKetThuc = input.NgayKetThuc;
			result.TrangThai = input.TrangThai;



			return result;
		}

		private IEnumerable<BaoTriDto> ConvertListBaoTriToDto(IEnumerable<BaoTri> input)
		{
			var result = new List<BaoTriDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertBaoTriToDto(item));
			}

			return result;
		}

		private BaoTri ConvertDtoToBaoTri(BaoTriDto input)
		{
			var result = new BaoTri();
			if (input == null)
			{
				return result;
			}
			result.MaBaoTri = input.MaBaoTri;
			result.MaNhaMay = input.MaNhaMay;
			result.TenBaoTri = input.TenBaoTri;
			result.MoTa = input.MoTa;
			result.NgayBatDau = input.NgayBatDau;
			result.NgayKetThuc = input.NgayKetThuc;
			result.TrangThai = input.TrangThai;
			return result;
		}

		private IEnumerable<BaoTri> ConvertListDtoToBaoTri(IEnumerable<BaoTriDto> input)
		{
			var result = new List<BaoTri>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToBaoTri(item));
			}

			return result;
		}
	}

}
