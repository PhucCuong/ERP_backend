using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class QuyTrinhSanXuatService : IQuyTrinhSanXuatService
	{
		private readonly IQuyTrinhSanXuatRepository _quyTrinhSanXuatRepository;

		public QuyTrinhSanXuatService(IQuyTrinhSanXuatRepository quyTrinhSanXuatRepository)
		{
			_quyTrinhSanXuatRepository = quyTrinhSanXuatRepository;
		}
		public async Task<QuyTrinhSanXuatDto> Add(QuyTrinhSanXuatDto input)
		{
			var convertData = ConvertDtoToQuyTrinhSanXuat(input);
			var result = await _quyTrinhSanXuatRepository.Add(convertData);
			return ConvertQuyTrinhSanXuatToDto(result);
		}

		public async Task<QuyTrinhSanXuatDto> Delete(QuyTrinhSanXuatDto input)
		{
			var convertData = ConvertDtoToQuyTrinhSanXuat(input);
			var result = await _quyTrinhSanXuatRepository.Delete(convertData);
			return ConvertQuyTrinhSanXuatToDto(result);
		}

		public async Task<IEnumerable<QuyTrinhSanXuatDto>> GetAll()
		{
			var result = await _quyTrinhSanXuatRepository.GetAll();
			return ConvertListQuyTrinhSanXuatToDto(result);
		}

		public async Task<QuyTrinhSanXuatDto> GetById(Guid id)
		{
			var result = await _quyTrinhSanXuatRepository.GetById(id);
			return ConvertQuyTrinhSanXuatToDto(result);
		}

		public async Task<QuyTrinhSanXuatDto> Update(QuyTrinhSanXuatDto input)
		{
			var convertData = ConvertDtoToQuyTrinhSanXuat(input);
			var result = await _quyTrinhSanXuatRepository.Update(convertData);
			return ConvertQuyTrinhSanXuatToDto(result);
		}
		private QuyTrinhSanXuatDto ConvertQuyTrinhSanXuatToDto(QuyTrinhSanXuat input)
		{
			var result = new QuyTrinhSanXuatDto();
			if (input == null)
			{
				return result;
			}
			result.MaQuyTrinh = input.MaQuyTrinh;
			result.TenQuyTrinh = input.TenQuyTrinh;
			result.MoTa = input.MoTa;
			result.TrangThai = input.TrangThai;
			return result;
		}

		private IEnumerable<QuyTrinhSanXuatDto> ConvertListQuyTrinhSanXuatToDto(IEnumerable<QuyTrinhSanXuat> input)
		{
			var result = new List<QuyTrinhSanXuatDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertQuyTrinhSanXuatToDto(item));
			}

			return result;
		}

		private QuyTrinhSanXuat ConvertDtoToQuyTrinhSanXuat(QuyTrinhSanXuatDto input)
		{
			var result = new QuyTrinhSanXuat();
			if (input == null)
			{
				return result;
			}
			result.MaQuyTrinh = input.MaQuyTrinh;
			result.TenQuyTrinh = input.TenQuyTrinh;
			result.MoTa = input.MoTa;
			result.TrangThai = input.TrangThai;
			return result;
		}

		private IEnumerable<QuyTrinhSanXuat> ConvertListDtoToQuyTrinhSanXuat(IEnumerable<QuyTrinhSanXuatDto> input)
		{
			var result = new List<QuyTrinhSanXuat>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToQuyTrinhSanXuat(item));
			}

			return result;
		}
	}

}
