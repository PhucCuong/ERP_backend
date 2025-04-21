using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface IKeHoachSanXuatRepository
	{
	Task<IEnumerable<KeHoachSanXuat>> GetAll();
		Task<KeHoachSanXuat> GetById(int id);
		Task<KeHoachSanXuat> Update(KeHoachSanXuat input);
		Task<KeHoachSanXuat> Add(KeHoachSanXuat input);
		Task<KeHoachSanXuat> Delete(KeHoachSanXuat input);

		Task<bool> UpdateStatus (UpdateStatusKeHoach requestBody);
	}
}
