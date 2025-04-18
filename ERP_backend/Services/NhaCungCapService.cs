using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class NhaCungCapService : INhaCungCapService
	{
		private readonly INhaCungCapRepository _NhaCungCapRepository;

		public NhaCungCapService(INhaCungCapRepository NhaCungCapRepository)
		{
			_NhaCungCapRepository = NhaCungCapRepository;
		}
		public async Task<NhaCungCapDto> Add(NhaCungCapDto input)
		{
			var convertData = ConvertDtoToNhaCungCap(input);
			var result = await _NhaCungCapRepository.Add(convertData);
			return ConvertNhaCungCapToDto(result);
		}

		public async Task<NhaCungCapDto?> Delete(NhaCungCapDto input)
		{
			var existingNhaCungCap = await _NhaCungCapRepository.GetById(input.MaNhaCungCap);

			if (existingNhaCungCap == null)
			{
				return null; // Hoặc throw NotFoundException
			}

			var result = await _NhaCungCapRepository.Delete(existingNhaCungCap);
			return ConvertNhaCungCapToDto(result);
		}
		public async Task<IEnumerable<NhaCungCapDto>> GetAll()
		{
			var result = await _NhaCungCapRepository.GetAll();
			return ConvertListNhaCungCapToDto(result);
		}

		public async Task<NhaCungCapDto> GetById(Guid id)
		{
			var result = await _NhaCungCapRepository.GetById(id);
			return ConvertNhaCungCapToDto(result);
		}

		public async Task<NhaCungCapDto> Update(NhaCungCapDto input)
		{
			var convertData = ConvertDtoToNhaCungCap(input);
			var result = await _NhaCungCapRepository.Update(convertData);
			return ConvertNhaCungCapToDto(result);
		}
		private NhaCungCapDto ConvertNhaCungCapToDto(NhaCungCap input)
		{
			var result = new NhaCungCapDto();
			if (input == null)
			{
				return result;
			}
			result.MaNhaCungCap = input.MaNhaCungCap;
			result.TenNhaCungCap = input.TenNhaCungCap;
			result.MaNguyenVatLieu = input.MaNguyenVatLieu;
			result.DiaChi = input.DiaChi;
			result.SoDienThoai = input.SoDienThoai;
			result.Email = input.Email;
			result.GhiChu = input.GhiChu;


			return result;
		}

		private IEnumerable<NhaCungCapDto> ConvertListNhaCungCapToDto(IEnumerable<NhaCungCap> input)
		{
			var result = new List<NhaCungCapDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertNhaCungCapToDto(item));
			}

			return result;
		}

		private NhaCungCap ConvertDtoToNhaCungCap(NhaCungCapDto input)
		{
			var result = new NhaCungCap();
			if (input == null)
			{
				return result;
			}
			result.MaNhaCungCap = input.MaNhaCungCap;
			result.TenNhaCungCap = input.TenNhaCungCap;
			result.MaNguyenVatLieu = input.MaNguyenVatLieu;
			result.DiaChi = input.DiaChi;
			result.SoDienThoai = input.SoDienThoai;
			result.Email = input.Email;
			result.GhiChu = input.GhiChu;
			return result;
		}

		private IEnumerable<NhaCungCap> ConvertListDtoToNhaCungCap(IEnumerable<NhaCungCapDto> input)
		{
			var result = new List<NhaCungCap>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToNhaCungCap(item));
			}

			return result;
		}
	}

}
