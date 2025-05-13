using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface IBaoCaoSanXuatService
	{
        public Task<BaoCaoTongHopSanXuat> GetTienDoSanXuat();

        public Task<List<BaoCaoSanPhamSanXuat>> GetTongQuanSoLuongSanPham();
    }
}
