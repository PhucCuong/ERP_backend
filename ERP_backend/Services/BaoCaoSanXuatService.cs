using ERP_backend.DTOs;
using ERP_backend.DTOs.Request;
using ERP_backend.Models;
using ERP_backend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Services
{
	public class BaoCaoSanXuatService : IBaoCaoSanXuatService
	{
		private readonly IBaoCaoSanXuatRepository _BaoCaoSanXuatRepository;

		public BaoCaoSanXuatService(IBaoCaoSanXuatRepository BaoCaoSanXuatRepository)
		{
			_BaoCaoSanXuatRepository = BaoCaoSanXuatRepository;
		}
		public async Task<BaoCaoSanXuatDto> Add(BaoCaoSanXuatDto input)
		{
			var convertData = ConvertDtoToBaoCaoSanXuat(input);
			var result= await _BaoCaoSanXuatRepository.Add(convertData);
			return ConvertBaoCaoSanXuatToDto(result);
		}

		public async Task<BaoCaoSanXuatDto> Delete(BaoCaoSanXuatDto input)
		{
			var convertData = ConvertDtoToBaoCaoSanXuat(input);
			var result = await _BaoCaoSanXuatRepository.Delete(convertData);
			return ConvertBaoCaoSanXuatToDto(result);
		}

		public async Task<IEnumerable<BaoCaoSanXuatDto>> GetAll()
		{
			var result = await _BaoCaoSanXuatRepository.GetAll();
			return ConvertListBaoCaoSanXuatToDto(result);

		}

		public async Task<BaoCaoSanXuatDto> GetById(Guid id)
		{
			var result = await _BaoCaoSanXuatRepository.GetById(id);
			return ConvertBaoCaoSanXuatToDto(result);
		}

		public async Task<BaoCaoSanXuatDto> Update(BaoCaoSanXuatDto input)
		{
			var convertData = ConvertDtoToBaoCaoSanXuat(input);
			var result = await _BaoCaoSanXuatRepository.Update(convertData);
			return ConvertBaoCaoSanXuatToDto(result);
		}

		private BaoCaoSanXuatDto ConvertBaoCaoSanXuatToDto(BaoCaoSanXuat input)
		{
			var result = new BaoCaoSanXuatDto();
			if (input == null)
			{
				return result;
			}
			result.MaBaoCao = input.MaBaoCao;
			result.MaKeHoach = input.MaKeHoach;
			result.TenSanPham = input.TenSanPham;
			result.NgayBatDau = input.NgayBatDau;
			result.NgayKetThuc = input.NgayKetThuc;
			result.SoLuongSxMucTieu = input.SoLuongSxMucTieu;
			result.SoLuongSxThucTe = input.SoLuongSxThucTe;
			result.ThoiGianSanXuatThucTe = input.ThoiGianSanXuatThucTe;
			result.ThoiGianSanXuatKeHoach = input.ThoiGianSanXuatKeHoach;
			result.HieuSuatSanXuat = input.HieuSuatSanXuat;
			result.TrangThai = input.TrangThai;
			result.NgayChinhSua = input.NgayChinhSua;

			return result;
		}

		private IEnumerable<BaoCaoSanXuatDto> ConvertListBaoCaoSanXuatToDto(IEnumerable<BaoCaoSanXuat> input)
		{
			var result = new List<BaoCaoSanXuatDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertBaoCaoSanXuatToDto(item));
			}

			return result;
		}

		private BaoCaoSanXuat ConvertDtoToBaoCaoSanXuat(BaoCaoSanXuatDto input)
		{
			var result = new BaoCaoSanXuat();
			if (input == null)
			{
				return result;
			}
			result.MaBaoCao = input.MaBaoCao;
			result.MaKeHoach = input.MaKeHoach;
			result.TenSanPham = input.TenSanPham;
			result.NgayBatDau = input.NgayBatDau;
			result.NgayKetThuc = input.NgayKetThuc;
			result.SoLuongSxMucTieu = input.SoLuongSxMucTieu;
			result.SoLuongSxThucTe = input.SoLuongSxThucTe;
			result.ThoiGianSanXuatThucTe = input.ThoiGianSanXuatThucTe;
			result.ThoiGianSanXuatKeHoach = input.ThoiGianSanXuatKeHoach;
			result.HieuSuatSanXuat = input.HieuSuatSanXuat;
			result.TrangThai = input.TrangThai;
			result.NgayChinhSua = input.NgayChinhSua;

			return result;
		}

		private IEnumerable<BaoCaoSanXuat> ConvertListDtoToBaoCaoSanXuat(IEnumerable<BaoCaoSanXuatDto> input)
		{
			var result = new List<BaoCaoSanXuat>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToBaoCaoSanXuat(item));
			}

			return result;
		}
	}
}
