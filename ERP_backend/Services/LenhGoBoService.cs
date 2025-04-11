using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class LenhGoBoService : ILenhGoBoService
	{
		private readonly ILenhGoBoRepository _LenhGoBoRepository;

		public LenhGoBoService(ILenhGoBoRepository LenhGoBoRepository)
		{
			_LenhGoBoRepository = LenhGoBoRepository;
		}
		public async Task<LenhGoBoDto> Add(LenhGoBoDto input)
		{
			var convertData = ConvertDtoToLenhGoBo(input);
			var result = await _LenhGoBoRepository.Add(convertData);
			return ConvertLenhGoBoToDto(result);
		}

		public async Task<LenhGoBoDto> Delete(LenhGoBoDto input)
		{
			var convertData = ConvertDtoToLenhGoBo(input);
			var result = await _LenhGoBoRepository.Delete(convertData);
			return ConvertLenhGoBoToDto(result);
		}

		public async Task<IEnumerable<LenhGoBoDto>> GetAll()
		{
			var result = await _LenhGoBoRepository.GetAll();
			return ConvertListLenhGoBoToDto(result);
		}

		public async Task<LenhGoBoDto> GetById(int id)
		{
			var result = await _LenhGoBoRepository.GetById(id);
			return ConvertLenhGoBoToDto(result);
		}

		public async Task<LenhGoBoDto> Update(LenhGoBoDto input)
		{
			var convertData = ConvertDtoToLenhGoBo(input);
			var result = await _LenhGoBoRepository.Update(convertData);
			return ConvertLenhGoBoToDto(result);
		}
		private LenhGoBoDto ConvertLenhGoBoToDto(LenhGoBo input)
		{
			var result = new LenhGoBoDto();
			if (input == null)
			{
				return result;
			}
			result.MaLenhGoBo = input.MaLenhGoBo;
			result.MaKeHoach = input.MaKeHoach;
			result.MaSanPham = input.MaSanPham;
			result.LyDoGoBo = input.LyDoGoBo;
			result.NgayBatDau = input.NgayBatDau;
			result.NgayKetThuc = input.NgayKetThuc;
			result.TrangThai = input.TrangThai;
			result.NguoiChiuTrachNhiem = input.NguoiChiuTrachNhiem;



			return result;
		}

		private IEnumerable<LenhGoBoDto> ConvertListLenhGoBoToDto(IEnumerable<LenhGoBo> input)
		{
			var result = new List<LenhGoBoDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertLenhGoBoToDto(item));
			}

			return result;
		}

		private LenhGoBo ConvertDtoToLenhGoBo(LenhGoBoDto input)
		{
			var result = new LenhGoBo();
			if (input == null)
			{
				return result;
			}
			result.MaLenhGoBo = input.MaLenhGoBo;
			result.MaKeHoach = input.MaKeHoach;
			result.MaSanPham = input.MaSanPham;
			result.LyDoGoBo = input.LyDoGoBo;
			result.NgayBatDau = input.NgayBatDau;
			result.NgayKetThuc = input.NgayKetThuc;
			result.TrangThai = input.TrangThai;
			result.NguoiChiuTrachNhiem = input.NguoiChiuTrachNhiem;
			return result;
		}

		private IEnumerable<LenhGoBo> ConvertListDtoToLenhGoBo(IEnumerable<LenhGoBoDto> input)
		{
			var result = new List<LenhGoBo>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToLenhGoBo(item));
			}

			return result;
		}
	}

}
