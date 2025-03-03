using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class KiemTraChatLuongService : IKiemTraChatLuongService
	{
		private readonly IKiemTraChatLuongRepository _KiemTraChatLuongRepository;

		public KiemTraChatLuongService(IKiemTraChatLuongRepository KiemTraChatLuongRepository)
		{
			_KiemTraChatLuongRepository = KiemTraChatLuongRepository;
		}
		public async Task<KiemTraChatLuongDto> Add(KiemTraChatLuongDto input)
		{
			var convertData = ConvertDtoToKiemTraChatLuong(input);
			var result = await _KiemTraChatLuongRepository.Add(convertData);
			return ConvertKiemTraChatLuongToDto(result);
		}

		public async Task<KiemTraChatLuongDto> Delete(KiemTraChatLuongDto input)
		{
			var convertData = ConvertDtoToKiemTraChatLuong(input);
			var result = await _KiemTraChatLuongRepository.Delete(convertData);
			return ConvertKiemTraChatLuongToDto(result);
		}

		public async Task<IEnumerable<KiemTraChatLuongDto>> GetAll()
		{
			var result = await _KiemTraChatLuongRepository.GetAll();
			return ConvertListKiemTraChatLuongToDto(result);
		}

		public async Task<KiemTraChatLuongDto> GetById(Guid id)
		{
			var result = await _KiemTraChatLuongRepository.GetById(id);
			return ConvertKiemTraChatLuongToDto(result);
		}

		public async Task<KiemTraChatLuongDto> Update(KiemTraChatLuongDto input)
		{
			var convertData = ConvertDtoToKiemTraChatLuong(input);
			var result = await _KiemTraChatLuongRepository.Update(convertData);
			return ConvertKiemTraChatLuongToDto(result);
		}
		private KiemTraChatLuongDto ConvertKiemTraChatLuongToDto(KiemTraChatLuong input)
		{
			var result = new KiemTraChatLuongDto();
			if (input == null)
			{
				return result;
			}
			result.MaKiemTra = input.MaKiemTra;
			result.MaSanPham = input.MaSanPham;
			result.NgayKiemTra = input.NgayKiemTra;
			result.MoTa = input.MoTa;
			result.DoiKiemTra = input.DoiKiemTra;
			result.NguoiPhuTrach = input.NguoiPhuTrach;
			result.KetQua = input.KetQua;
			result.NgayTao = input.NgayTao;
			result.NgayChinhSua = input.NgayChinhSua;



			return result;
		}

		private IEnumerable<KiemTraChatLuongDto> ConvertListKiemTraChatLuongToDto(IEnumerable<KiemTraChatLuong> input)
		{
			var result = new List<KiemTraChatLuongDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertKiemTraChatLuongToDto(item));
			}

			return result;
		}

		private KiemTraChatLuong ConvertDtoToKiemTraChatLuong(KiemTraChatLuongDto input)
		{
			var result = new KiemTraChatLuong();
			if (input == null)
			{
				return result;
			}
			result.MaKiemTra = input.MaKiemTra;
			result.MaSanPham = input.MaSanPham;
			result.NgayKiemTra = input.NgayKiemTra;
			result.MoTa = input.MoTa;
			result.DoiKiemTra = input.DoiKiemTra;
			result.NguoiPhuTrach = input.NguoiPhuTrach;
			result.KetQua = input.KetQua;
			result.NgayTao = input.NgayTao;
			result.NgayChinhSua = input.NgayChinhSua;
			return result;
		}

		private IEnumerable<KiemTraChatLuong> ConvertListDtoToKiemTraChatLuong(IEnumerable<KiemTraChatLuongDto> input)
		{
			var result = new List<KiemTraChatLuong>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToKiemTraChatLuong(item));
			}

			return result;
		}
	}

}
