using ERP_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP_backend.Repositories
{
	public interface IBaoCaoSanXuatRepository
	{
		public Task<BaoCaoTongHopSanXuat> GetTienDoSanXuat();

		public Task<List<BaoCaoSanPhamSanXuat>> GetTongQuanSoLuongSanPham();
	}
}
