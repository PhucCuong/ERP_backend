using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;
using Humanizer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Services
{
	public class SanPhamImgService : ISanPhamImgService
	{
		private readonly ISanPhamImgRepository _sanPhamImgRepository;
		
		public SanPhamImgService(ISanPhamImgRepository sanPhamImgRepository)
		{
			_sanPhamImgRepository = sanPhamImgRepository;
			
		}
		public async Task<SanPhamImgDto> Add(SanPhamImgDto input)
		{


			var convertData = ConvertDtoToSanPhamImg(input);
			var result = await _sanPhamImgRepository.Add(convertData);
			return ConvertSanPhamImgToDto(result);
		}

		public async Task<SanPhamImgDto> Delete(SanPhamImgDto input)
		{
			var convertData = ConvertDtoToSanPhamImg(input);
			var result = await _sanPhamImgRepository.Delete(convertData);
			return ConvertSanPhamImgToDto(result);
		}

		public async Task<IEnumerable<SanPhamImgDto>> GetAll()
		{
			var result = await _sanPhamImgRepository.GetAll();
			return ConvertListSanPhamImgToDto(result);
		}

		public async Task<SanPhamImgDto> GetById(Guid id)
		{
			var result = await _sanPhamImgRepository.GetById(id);
			return ConvertSanPhamImgToDto(result);
		}

		public async Task<SanPhamImgDto> Update(SanPhamImgDto input)
		{
			var convertData = ConvertDtoToSanPhamImg(input);
			var result = await _sanPhamImgRepository.Update(convertData);
			return ConvertSanPhamImgToDto(result);
		}
		private SanPhamImgDto ConvertSanPhamImgToDto(SanPhamImg input)
		{
			var result = new SanPhamImgDto();
			if (input == null)
			{
				return result;
			}

			result.ImageId = input.ImageId;
			result.MaSanPham = input.MaSanPham;

			// Chuyển byte[] sang Base64 string để trả về cho client
			result.ImgUrl = input.ImgUrl != null ? Convert.ToBase64String(input.ImgUrl) : null;

			return result;
		}


		private IEnumerable<SanPhamImgDto> ConvertListSanPhamImgToDto(IEnumerable<SanPhamImg> input)
		{

			var result = new List<SanPhamImgDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertSanPhamImgToDto(item));
			}

			return result;
		}

		private SanPhamImg ConvertDtoToSanPhamImg(SanPhamImgDto input)
		{
			var result = new SanPhamImg();
			if (input == null)
			{
				return result;
			}
			result.ImageId = input.ImageId;
			result.MaSanPham = input.MaSanPham;

			// Chuyển Base64 string thành byte[] để lưu vào database
			result.ImgUrl = !string.IsNullOrEmpty(input.ImgUrl) ? Convert.FromBase64String(input.ImgUrl) : null;

			return result;
		}


		private IEnumerable<SanPhamImg> ConvertListDtoToSanPhamImg(IEnumerable<SanPhamImgDto> input)
		{
			var result = new List<SanPhamImg>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToSanPhamImg(item));
			}

			return result;
		}
	
	}

}
