using ERP_backend.DTOs;
using ERP_backend.Models;
using System.Linq.Expressions;

namespace ERP_backend.Repositories
{
	public interface ILenhSanXuatRepository
	{
		Task<IEnumerable<LenhSanXuat>> GetAll();
		Task<LenhSanXuat> GetById(int id);
		Task<LenhSanXuat> Update(LenhSanXuat input);
		Task<LenhSanXuat> Add(LenhSanXuat input);
		Task<bool> Delete(int id);
		
        Task<bool> AddListWorkOrder(ThemNhieuLenhSanXuatDto modelReq);
		Task<List<WorkOrder>> GetWorkOrderListByPlantCode(int plantCode);
		Task<bool> UpdateStatusAndTime(UpdateStatusLenhSanXuat modelRequest);
		Task<IEnumerable<LenhSanXuat>> GetByConditionAsync(Expression<Func<LenhSanXuat, bool>> predicate);
	}
}
