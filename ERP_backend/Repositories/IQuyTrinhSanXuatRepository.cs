using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface IQuyTrinhSanXuatRepository
	{
	Task<IEnumerable<QuyTrinhSanXuat>> GetAll();
		Task<QuyTrinhSanXuat> GetById(Guid id);
		Task<QuyTrinhSanXuat> Update(QuyTrinhSanXuat input);
		Task<QuyTrinhSanXuat> Add(QuyTrinhSanXuat input);
		Task<QuyTrinhSanXuat> Delete(QuyTrinhSanXuat input);
	}
}
