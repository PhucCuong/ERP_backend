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

        public async Task<BaoCaoTongHopSanXuat> GetTienDoSanXuat()
        {
            var result  = await _BaoCaoSanXuatRepository.GetTienDoSanXuat();
			return result;
        }

        public async Task<List<BaoCaoSanPhamSanXuat>> GetTongQuanSoLuongSanPham()
        {
            var result = await _BaoCaoSanXuatRepository.GetTongQuanSoLuongSanPham();
            return result;
        }

        public async Task<FilterChatLuongSanPham> filterChatLuongSanPham(FilterChatLuongSanPhamDto requestBody)
        {
            var result = await _BaoCaoSanXuatRepository.filterChatLuongSanPham(requestBody);
            return result;
        }
    }
}
