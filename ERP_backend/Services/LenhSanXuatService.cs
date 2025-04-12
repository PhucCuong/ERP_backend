using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class LenhSanXuatService : ILenhSanXuatService
	{
		private readonly ILenhSanXuatRepository _lenhSanXuatRepository;

		public LenhSanXuatService(ILenhSanXuatRepository lenhSanXuatRepository)
		{
			_lenhSanXuatRepository = lenhSanXuatRepository;
		}
		public async Task<LenhSanXuatDto> Add(LenhSanXuatDto input)
		{
			var convertData = ConvertDtoToLenhSanXuat(input);
			var result = await _lenhSanXuatRepository.Add(convertData);
			return ConvertLenhSanXuatToDto(result);
		}

		public async Task<LenhSanXuatDto> Delete(LenhSanXuatDto input)
		{
			var convertData = ConvertDtoToLenhSanXuat(input);
			var result = await _lenhSanXuatRepository.Delete(convertData);
			return ConvertLenhSanXuatToDto(result);
		}

		public async Task<IEnumerable<LenhSanXuatDto>> GetAll()
		{
			var result = await _lenhSanXuatRepository.GetAll();
			return ConvertListLenhSanXuatToDto(result);
		}

		public async Task<LenhSanXuatDto> GetById(int id)
		{
			var result = await _lenhSanXuatRepository.GetById(id);
			return ConvertLenhSanXuatToDto(result);
		}

		public async Task<LenhSanXuatDto> Update(LenhSanXuatDto input)
		{
			var convertData = ConvertDtoToLenhSanXuat(input);
			var result = await _lenhSanXuatRepository.Update(convertData);
			return ConvertLenhSanXuatToDto(result);
		}
		public static LenhSanXuatDto ConvertLenhSanXuatToDto(LenhSanXuat input)
		{
			var result = new LenhSanXuatDto();
			if (input == null)
			{
				return result;
			}
            // LSX/00001
            result.MaLenh = "LSX/" + input.MaLenh.ToString().PadLeft(5,'0');
			result.MaKeHoach = input.MaKeHoach;
			result.MaQuyTrinh = input.MaQuyTrinh;
			result.MaSanPham = input.MaSanPham;
			result.SoLuong = input.SoLuong;
			result.NgayBatDau = input.NgayBatDau;
			result.NgayKetThuc = input.NgayKetThuc;
			result.TrangThai = input.TrangThai;
			result.NguoiChiuTrachNhiem = input.NguoiChiuTrachNhiem;
			result.MaDinhMuc = input.MaDinhMuc;
			result.KhuVucSanXuat = input.KhuVucSanXuat;




			return result;
		}

		private IEnumerable<LenhSanXuatDto> ConvertListLenhSanXuatToDto(IEnumerable<LenhSanXuat> input)
		{
			var result = new List<LenhSanXuatDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertLenhSanXuatToDto(item));
			}

			return result;
		}

		private LenhSanXuat ConvertDtoToLenhSanXuat(LenhSanXuatDto input)
		{
			var result = new LenhSanXuat();
			if (input == null)
			{
				return result;
			}
			// LSX/00001
			result.MaKeHoach = input.MaKeHoach;
			result.MaQuyTrinh = input.MaQuyTrinh;
			result.MaSanPham = input.MaSanPham;
			result.SoLuong = input.SoLuong;
			result.NgayBatDau = input.NgayBatDau;
			result.NgayKetThuc = input.NgayKetThuc;
			result.TrangThai = input.TrangThai;
			result.NguoiChiuTrachNhiem = input.NguoiChiuTrachNhiem;
			result.MaDinhMuc = input.MaDinhMuc;
			result.KhuVucSanXuat = input.KhuVucSanXuat;
			return result;
		}

		private IEnumerable<LenhSanXuat> ConvertListDtoToLenhSanXuat(IEnumerable<LenhSanXuatDto> input)
		{
			var result = new List<LenhSanXuat>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToLenhSanXuat(item));
			}

			return result;
		}

    }

}
