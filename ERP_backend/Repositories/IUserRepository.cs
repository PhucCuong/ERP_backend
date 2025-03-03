using ERP_backend.Models;

namespace ERP_backend.Repositories
{
	public interface IUserRepository
	{
	Task<IEnumerable<User>> GetAll();
		Task<User> GetById(Guid id);
		Task<User> Update(User input);
		Task<User> Add(User input);
		Task<User> Delete(User input);
	}
}
