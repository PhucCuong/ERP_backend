using ERP_backend.Models;
namespace ERP_backend.Repositories
{
	public interface INguyenVatLieuRepository
	{
	Task<IEnumerable<NguyenVatLieu>> GetAll();
		Task<NguyenVatLieu> GetById(Guid id);
		Task<NguyenVatLieu> Update(NguyenVatLieu input);
		Task<NguyenVatLieu> Add(NguyenVatLieu input);
		Task<NguyenVatLieu> Delete(NguyenVatLieu input);
	}
}
