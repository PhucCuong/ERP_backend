using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface IUserService
	{
	Task<IEnumerable<UserDto>> GetAll();
		Task<UserDto> GetById(Guid id);
		Task<UserDto> Update(UserDto input);
		Task<UserDto> Add(UserDto input);
		Task<UserDto> Delete(UserDto input);
	}
}
