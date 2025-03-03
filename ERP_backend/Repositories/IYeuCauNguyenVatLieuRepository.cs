using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface IYeuCauNguyenVatLieuRepository
	{
	Task<IEnumerable<YeuCauNguyenVatLieu>> GetAll();
		Task<YeuCauNguyenVatLieu> GetById(Guid id);
		Task<YeuCauNguyenVatLieu> Update(YeuCauNguyenVatLieu input);
		Task<YeuCauNguyenVatLieu> Add(YeuCauNguyenVatLieu input);
		Task<YeuCauNguyenVatLieu> Delete(YeuCauNguyenVatLieu input);
	}
}
