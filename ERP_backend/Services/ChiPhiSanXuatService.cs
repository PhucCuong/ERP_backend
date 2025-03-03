using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class ChiPhiSanXuatService : IChiPhiSanXuatService
	{
		private readonly IChiPhiSanXuatRepository _ChiPhiSanXuatRepository;

		public ChiPhiSanXuatService(IChiPhiSanXuatRepository chiPhiSanXuatRepository)
		{
			_ChiPhiSanXuatRepository = chiPhiSanXuatRepository;
		}
		public async Task<ChiPhiSanXuatDto> Add(ChiPhiSanXuatDto input)
		{
			var convertData = ConvertDtoToChiPhiSanXuat(input);
			var result = await _ChiPhiSanXuatRepository.Add(convertData);
			return ConvertChiPhiSanXuatToDto(result);
		}

		public async Task<ChiPhiSanXuatDto> Delete(ChiPhiSanXuatDto input)
		{
			var convertData = ConvertDtoToChiPhiSanXuat(input);
			var result = await _ChiPhiSanXuatRepository.Delete(convertData);
			return ConvertChiPhiSanXuatToDto(result);
		}

		public async Task<IEnumerable<ChiPhiSanXuatDto>> GetAll()
		{
			var result = await _ChiPhiSanXuatRepository.GetAll();
			return ConvertListChiPhiSanXuatToDto(result);
		}

		public async Task<ChiPhiSanXuatDto> GetById(Guid id)
		{
			var result = await _ChiPhiSanXuatRepository.GetById(id);
			return ConvertChiPhiSanXuatToDto(result);
		}

		public  async Task<ChiPhiSanXuatDto> Update(ChiPhiSanXuatDto input)
		{
			var convertData = ConvertDtoToChiPhiSanXuat(input);
			var result = await _ChiPhiSanXuatRepository.Update(convertData);
			return ConvertChiPhiSanXuatToDto(result);
		}
		private ChiPhiSanXuatDto ConvertChiPhiSanXuatToDto(ChiPhiSanXuat input)
		{
			var result = new ChiPhiSanXuatDto();
			if (input == null)
			{
				return result;
			}
			result.MaChiPhiSanXuat = input.MaChiPhiSanXuat;
			result.MaLenhSanXuat = input.MaLenhSanXuat;
			result.LoaiChiPhi = input.LoaiChiPhi;
			result.MoTa = input.MoTa;
			result.SoTien = input.SoTien;
			result.MoTa = input.MoTa;
			result.NgayTao = input.NgayTao;



			return result;
		}

		private IEnumerable<ChiPhiSanXuatDto> ConvertListChiPhiSanXuatToDto(IEnumerable<ChiPhiSanXuat> input)
		{
			var result = new List<ChiPhiSanXuatDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertChiPhiSanXuatToDto(item));
			}

			return result;
		}

		private ChiPhiSanXuat ConvertDtoToChiPhiSanXuat(ChiPhiSanXuatDto input)
		{
			var result = new ChiPhiSanXuat();
			if (input == null)
			{
				return result;
			}
			result.MaChiPhiSanXuat = input.MaChiPhiSanXuat;
			result.MaLenhSanXuat = input.MaLenhSanXuat;
			result.LoaiChiPhi = input.LoaiChiPhi;
			result.MoTa = input.MoTa;
			result.SoTien = input.SoTien;
			result.MoTa = input.MoTa;
			result.NgayTao = input.NgayTao;
			return result;
		}

		private IEnumerable<ChiPhiSanXuat> ConvertListDtoToChiPhiSanXuat(IEnumerable<ChiPhiSanXuatDto> input)
		{
			var result = new List<ChiPhiSanXuat>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToChiPhiSanXuat(item));
			}

			return result;
		}
	}
}
