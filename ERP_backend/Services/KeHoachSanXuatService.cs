using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class KeHoachSanXuatService : IKeHoachSanXuatService
	{
		private readonly IKeHoachSanXuatRepository _KeHoachSanXuatRepository;

		public KeHoachSanXuatService(IKeHoachSanXuatRepository KeHoachSanXuatRepository)
		{
			_KeHoachSanXuatRepository = KeHoachSanXuatRepository;
		}
		public async Task<KeHoachSanXuatDto> Add(KeHoachSanXuatDto input)
		{
			var convertData = ConvertDtoToKeHoachSanXuat(input);
			var result = await _KeHoachSanXuatRepository.Add(convertData);
			return ConvertKeHoachSanXuatToDto(result);
		}

		public async Task<KeHoachSanXuatDto> Delete(KeHoachSanXuatDto input)
		{
			var convertData = ConvertDtoToKeHoachSanXuat(input);
			var result = await _KeHoachSanXuatRepository.Delete(convertData);
			return ConvertKeHoachSanXuatToDto(result);
		}

		public async Task<IEnumerable<KeHoachSanXuatDto>> GetAll()
		{
			var result = await _KeHoachSanXuatRepository.GetAll();
			return ConvertListKeHoachSanXuatToDto(result);
		}

		public async Task<KeHoachSanXuatDto> GetById(int id)
		{
			var result = await _KeHoachSanXuatRepository.GetById(id);
			return ConvertKeHoachSanXuatToDto(result);
		}

		public async Task<KeHoachSanXuatDto> Update(KeHoachSanXuatDto input)
		{
			var convertData = ConvertDtoToKeHoachSanXuat(input);
			var result = await _KeHoachSanXuatRepository.Update(convertData);
			return ConvertKeHoachSanXuatToDto(result);
		}
		private KeHoachSanXuatDto ConvertKeHoachSanXuatToDto(KeHoachSanXuat input)
		{
			var result = new KeHoachSanXuatDto();
			if (input == null)
			{
				return result;
			}
            // KHSX/00001
            result.MaKeHoach = "KHSX/" + input.MaKeHoach.ToString().PadLeft(5, '0');
			result.MaSanPham = input.MaSanPham;
			result.MaNhaMay = input.MaNhaMay;
			result.SoLuong = input.SoLuong;
			result.NgayBatDauDuKien = input.NgayBatDauDuKien;
			result.NgayKetThucDuKien = input.NgayKetThucDuKien;
			result.MucTonKhoAnToan = input.MucTonKhoAnToan;
			result.SoLuongSanXuatToiThieu = input.SoLuongSanXuatToiThieu;
			result.SoLuongSanXuatToiDa = input.SoLuongSanXuatToiDa;
			result.TrangThai = input.TrangThai;
			result.NguoiTao = input.NguoiTao;
			result.NgayTao = input.NgayTao;
			result.NguoiChinhSua = input.NguoiChinhSua ;
			result.NgayChinhSua = input.NgayChinhSua;



			return result;
		}

		private IEnumerable<KeHoachSanXuatDto> ConvertListKeHoachSanXuatToDto(IEnumerable<KeHoachSanXuat> input)
		{
			var result = new List<KeHoachSanXuatDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertKeHoachSanXuatToDto(item));
			}

			return result;
		}

		private KeHoachSanXuat ConvertDtoToKeHoachSanXuat(KeHoachSanXuatDto input)
		{
			var result = new KeHoachSanXuat();
			if (input == null)
			{
				return result;
			}
			// KHSX/00001
			//result.MaKeHoach = int.Parse(input.MaKeHoach.Substring(5,5));
			result.MaSanPham = input.MaSanPham;
			result.MaNhaMay = input.MaNhaMay;
			result.SoLuong = input.SoLuong;
			result.NgayBatDauDuKien = input.NgayBatDauDuKien;
			result.NgayKetThucDuKien = input.NgayKetThucDuKien;
			result.MucTonKhoAnToan = input.MucTonKhoAnToan;
			result.SoLuongSanXuatToiThieu = input.SoLuongSanXuatToiThieu;
			result.SoLuongSanXuatToiDa = input.SoLuongSanXuatToiDa;
			result.TrangThai = input.TrangThai;
			result.NguoiTao = input.NguoiTao;
			result.NgayTao = input.NgayTao;
			result.NguoiChinhSua = input.NguoiChinhSua;
			result.NgayChinhSua = input.NgayChinhSua;

			return result;

		}

        public async Task<bool> UpdateStatus(UpdateStatusKeHoach requestBody)
		{
			var result = await _KeHoachSanXuatRepository.UpdateStatus(requestBody);
			return result;
		}


        private IEnumerable<KeHoachSanXuat> ConvertListDtoToKeHoachSanXuat(IEnumerable<KeHoachSanXuatDto> input)
		{
			var result = new List<KeHoachSanXuat>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToKeHoachSanXuat(item));
			}

			return result;
		}
	}

}
