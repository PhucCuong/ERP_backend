using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface IChiTietHoatDongSanXuatRepository
	{
	Task<IEnumerable<ChiTietHoatDongSanXuat>> GetAll();
		Task<ChiTietHoatDongSanXuat> GetById(Guid id);
		Task<ChiTietHoatDongSanXuat> Update(ChiTietHoatDongSanXuat input);
		Task<ChiTietHoatDongSanXuat> Add(ChiTietHoatDongSanXuat input);
		Task<ChiTietHoatDongSanXuat> Delete(ChiTietHoatDongSanXuat input);
	}
}
