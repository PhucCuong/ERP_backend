using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface IDinhMucNguyenVatLieuRepository
	{
	Task<IEnumerable<DinhMucNguyenVatLieu>> GetAll();
		Task<DinhMucNguyenVatLieu> GetById(Guid id);
		Task<DinhMucNguyenVatLieu> Update(DinhMucNguyenVatLieu input);
		Task<DinhMucNguyenVatLieu> Add(DinhMucNguyenVatLieu input);
		Task<DinhMucNguyenVatLieu> Delete(DinhMucNguyenVatLieu input);
	}
}
