using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface ILenhGoBoRepository
	{
	Task<IEnumerable<LenhGoBo>> GetAll();
		Task<LenhGoBo> GetById(Guid id);
		Task<LenhGoBo> Update(LenhGoBo input);
		Task<LenhGoBo> Add(LenhGoBo input);
		Task<LenhGoBo> Delete(LenhGoBo input);
	}
}
