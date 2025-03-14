using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class DinhMucNguyenVatLieuService : IDinhMucNguyenVatLieuService
	{
		private readonly IDinhMucNguyenVatLieuRepository _dinhMucNguyenVatLieuRepository;

		public DinhMucNguyenVatLieuService(IDinhMucNguyenVatLieuRepository DinhMucNguyenVatLieuRepository)
		{
			_dinhMucNguyenVatLieuRepository = DinhMucNguyenVatLieuRepository;
		}
		public async Task<DinhMucNguyenVatLieuDto> Add(DinhMucNguyenVatLieuDto input)
		{
			var convertData = ConvertDtoToDinhMucNguyenVatLieu(input);
			var result = await _dinhMucNguyenVatLieuRepository.Add(convertData);
			return ConvertDinhMucNguyenVatLieuToDto(result);
		}

        public async Task<DinhMucNguyenVatLieuDto?> Delete(DinhMucNguyenVatLieuDto input)
        {
            var existingDinhMuc = await _dinhMucNguyenVatLieuRepository.GetById(input.MaDinhMuc);

            if (existingDinhMuc == null)
            {
                return null; // Hoặc throw NotFoundException
            }

            var result = await _dinhMucNguyenVatLieuRepository.Delete(existingDinhMuc);
            return ConvertDinhMucNguyenVatLieuToDto(result);
        }

        public async Task<IEnumerable<DinhMucNguyenVatLieuDto>> GetAll()
		{
			var result = await _dinhMucNguyenVatLieuRepository.GetAll();
			return ConvertListDinhMucNguyenVatLieuToDto(result);
		}

		public async Task<DinhMucNguyenVatLieuDto> GetById(Guid id)
		{
			var result = await _dinhMucNguyenVatLieuRepository.GetById(id);
			return ConvertDinhMucNguyenVatLieuToDto(result);
		}

		public async Task<DinhMucNguyenVatLieuDto> Update(DinhMucNguyenVatLieuDto input)
		{
			var convertData = ConvertDtoToDinhMucNguyenVatLieu(input);
			var result = await _dinhMucNguyenVatLieuRepository.Update(convertData);
			return ConvertDinhMucNguyenVatLieuToDto(result);
		}
		private DinhMucNguyenVatLieuDto ConvertDinhMucNguyenVatLieuToDto(DinhMucNguyenVatLieu input)
		{
			var result = new DinhMucNguyenVatLieuDto();
			if (input == null)
			{
				return result;
			}
			result.MaDinhMuc = input.MaDinhMuc;
			result.MaSanPham = input.MaSanPham;
			result.MaNguyenVatLieu = input.MaNguyenVatLieu;
			result.SoLuong = input.SoLuong;
			result.MucDoSuDung = input.MucDoSuDung;
			result.ThoiGianSanXuat = input.ThoiGianSanXuat;
			result.NgayTao = input.NgayTao;
			result.NgayChinhSua = input.NgayChinhSua;
			return result;
		}

		private IEnumerable<DinhMucNguyenVatLieuDto> ConvertListDinhMucNguyenVatLieuToDto(IEnumerable<DinhMucNguyenVatLieu> input)
		{
			var result = new List<DinhMucNguyenVatLieuDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDinhMucNguyenVatLieuToDto(item));
			}

			return result;
		}

		private DinhMucNguyenVatLieu ConvertDtoToDinhMucNguyenVatLieu(DinhMucNguyenVatLieuDto input)
		{
			var result = new DinhMucNguyenVatLieu();
			if (input == null)
			{
				return result;
			}
			result.MaDinhMuc = input.MaDinhMuc;
			result.MaSanPham = input.MaSanPham;
			result.MaNguyenVatLieu = input.MaNguyenVatLieu;
			result.SoLuong = input.SoLuong;
			result.MucDoSuDung = input.MucDoSuDung;
			result.ThoiGianSanXuat = input.ThoiGianSanXuat;
			result.NgayTao = input.NgayTao;
			result.NgayChinhSua = input.NgayChinhSua;
			return result;
		}

		private IEnumerable<DinhMucNguyenVatLieu> ConvertListDtoToDinhMucNguyenVatLieu(IEnumerable<DinhMucNguyenVatLieuDto> input)
		{
			var result = new List<DinhMucNguyenVatLieu>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToDinhMucNguyenVatLieu(item));
			}

			return result;
		}
	}

}
