using ERP_backend.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ERP_backend.Repositories
{
	public interface IAccountRepository
	{
		Task<IdentityResult> SignUpAsync(SignUpModel model);
		Task<string> SignInAsync(SignInModel model);

		Task<bool> AddRoleAsync(string roleName); // Thêm Role mới
		Task<bool> AssignRoleAsync(string userId, string roleName); // Gán Role cho User
	}
}
