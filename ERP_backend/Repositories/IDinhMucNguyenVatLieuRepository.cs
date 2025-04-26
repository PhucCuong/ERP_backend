using ERP_backend.Models;
using System.Linq.Expressions;

namespace ERP_backend.Repositories
{
	public interface IDinhMucNguyenVatLieuRepository
	{
	Task<IEnumerable<DinhMucNguyenVatLieu>> GetAll();
		Task<DinhMucNguyenVatLieu> GetById(Guid id);
		Task<DinhMucNguyenVatLieu> Update(DinhMucNguyenVatLieu input);
		Task<DinhMucNguyenVatLieu> Add(DinhMucNguyenVatLieu input);
		Task<DinhMucNguyenVatLieu> Delete(DinhMucNguyenVatLieu input);
		Task<IEnumerable<DinhMucNguyenVatLieu>> GetByConditionAsync(Expression<Func<DinhMucNguyenVatLieu, bool>> expression);
	}
}
