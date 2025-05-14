using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface IBaoCaoSanXuatService
	{
        public Task<BaoCaoTongHopSanXuat> GetTienDoSanXuat(FilterTienDoSanXuatDto requestBody);

        public Task<List<BaoCaoSanPhamSanXuat>> GetTongQuanSoLuongSanPham();

        public Task<FilterChatLuongSanPham> filterChatLuongSanPham(FilterChatLuongSanPhamDto requestBody);
    }
}
