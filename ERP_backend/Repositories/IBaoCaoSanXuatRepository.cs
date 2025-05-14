using ERP_backend.DTOs;
using ERP_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP_backend.Repositories
{
	public interface IBaoCaoSanXuatRepository
	{
		public Task<BaoCaoTongHopSanXuat> GetTienDoSanXuat(FilterTienDoSanXuatDto requestBody);

		public Task<List<BaoCaoSanPhamSanXuat>> GetTongQuanSoLuongSanPham();

		public Task<FilterChatLuongSanPham> filterChatLuongSanPham(FilterChatLuongSanPhamDto requestBody);
	}
}
