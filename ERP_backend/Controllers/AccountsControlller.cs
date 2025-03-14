using ERP_backend.Models;
using ERP_backend.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ERP_backend.Controllers
{
    public class AccountsControlller : ControllerBase
	{
		private readonly IAccountRepository accountRepo;

		public AccountsControlller(IAccountRepository repo)
		{
			accountRepo = repo;
		}
		[HttpPost("SignUp")]
		public async Task<IActionResult> SignUp(SignUpModel signUpModel)
		{
			var result = await accountRepo.SignUpAsync(signUpModel);
			if (result.Succeeded)
			{
				return Ok(result.Succeeded);
			}

			return StatusCode(500);
		}

		[HttpPost("SignIn")]
		public async Task<IActionResult> SignIn([FromBody] SignInModel signInModel)
		{
			var result = await accountRepo.SignInAsync(signInModel);

			if (string.IsNullOrEmpty(result))
			{
				return Unauthorized();
			}

			return Ok(result);
		}
		[HttpPost("add-role")]
		public async Task<IActionResult> AddRole(string roleName)
		{
			var result = await accountRepo.AddRoleAsync(roleName);
			if (result)
				return Ok(new { message = "Role created successfully!" });
			return BadRequest(new { message = "Role already exists or failed to create." });
		}

		[HttpPost("assign-role")]
		public async Task<IActionResult> AssignRole(string userName, string roleName)
		{
			var result = await accountRepo.AssignRoleAsync(userName, roleName);
			if (result)
				return Ok(new { message = "Role assigned successfully!" });
			return BadRequest(new { message = "User or role does not exist, or assignment failed." });
		}
	}
}
