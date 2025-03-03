using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class SanPhamService : ISanPhamService
	{
		private readonly ISanPhamRepository _sanPhamRepository;

		public SanPhamService(ISanPhamRepository sanPhamRepository)
		{
			_sanPhamRepository = sanPhamRepository;
		}
		public async Task<SanPhamDto> Add(SanPhamDto input)
		{
			var convertData = ConvertDtoToSanPham(input);
			var result = await _sanPhamRepository.Add(convertData);
			return ConvertSanPhamToDto(result);
		}

		public async Task<SanPhamDto?> Delete(SanPhamDto input)
		{
			var existingSanPham = await _sanPhamRepository.GetById(input.MaSanPham);

			if (existingSanPham == null)
			{
				return null; // Hoặc throw NotFoundException
			}

			var result = await _sanPhamRepository.Delete(existingSanPham);
			return ConvertSanPhamToDto(result);
		}

		public async Task<IEnumerable<SanPhamDto>> GetAll()
		{
			var result = await _sanPhamRepository.GetAll();
			return ConvertListSanPhamToDto(result);
		}

		public async Task<SanPhamDto> GetById(Guid id)
		{
			var result = await _sanPhamRepository.GetById(id);
			return ConvertSanPhamToDto(result);
		}

		public async Task<SanPhamDto> Update(SanPhamDto input)
		{
			var convertData = ConvertDtoToSanPham(input);
			var result = await _sanPhamRepository.Update(convertData);
			return ConvertSanPhamToDto(result);
		}
		private SanPhamDto ConvertSanPhamToDto(SanPham input)
		{
			var result = new SanPhamDto();
			if (input == null)
			{
				return result;
			}
			result.MaSanPham = input.MaSanPham;
			result.TenSanPham = input.TenSanPham;
			result.MaVach = input.MaVach;
			result.DonViTinh = input.DonViTinh;
			result.NhomSanPham = input.NhomSanPham;
			result.GiaBan = input.GiaBan;
			result.MoTa = input.MoTa;


			return result;
		}

		private IEnumerable<SanPhamDto> ConvertListSanPhamToDto(IEnumerable<SanPham> input)
		{
			var result = new List<SanPhamDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertSanPhamToDto(item));
			}

			return result;
		}

		private SanPham ConvertDtoToSanPham(SanPhamDto input)
		{
			var result = new SanPham();
			if (input == null)
			{
				return result;
			}
			result.MaSanPham = input.MaSanPham;
			result.TenSanPham = input.TenSanPham;
			result.MaVach = input.MaVach;
			result.DonViTinh = input.DonViTinh;
			result.NhomSanPham = input.NhomSanPham;
			result.GiaBan = input.GiaBan;
			result.MoTa = input.MoTa;
			
			return result;
		}

		private IEnumerable<SanPham> ConvertListDtoToSanPham(IEnumerable<SanPhamDto> input)
		{
			var result = new List<SanPham>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToSanPham(item));
			}

			return result;
		}
	}

}
