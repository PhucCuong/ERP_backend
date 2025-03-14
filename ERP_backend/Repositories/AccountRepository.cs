using ERP_backend.Helper;
using ERP_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ERP_backend.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly IConfiguration configuration;
		private readonly RoleManager<IdentityRole<Guid>> roleManager;
		public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
			IConfiguration configuration, RoleManager<IdentityRole<Guid>> roleManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.configuration = configuration;
			this.roleManager = roleManager;

		}
		// Thêm Role mới vào hệ thống
		public async Task<bool> AddRoleAsync(string roleName)
		{
			if (!await roleManager.RoleExistsAsync(roleName))
			{
				var result = await roleManager.CreateAsync(new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = roleName });
				return result.Succeeded;
			}
			return false;
		}

		// Gán Role cho User
		public async Task<bool> AssignRoleAsync(string username, string roleName)
		{
			var user = await userManager.FindByNameAsync(username);
			if (user == null)
			{
				return false; // Không tìm thấy user
			}

			if (!await roleManager.RoleExistsAsync(roleName))
			{
				return false; // Role không tồn tại
			}

			var result = await userManager.AddToRoleAsync(user, roleName);
			return result.Succeeded;
		}

		public async Task<string> SignInAsync(SignInModel model)
		{
			var user = await userManager.FindByNameAsync(model.UserName);
			var passwordValid = await userManager.CheckPasswordAsync(user, model.Password);
			var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
			if (user == null || !passwordValid)
			{
				return string.Empty;
			}

			var authClaims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, model.UserName),
				new Claim(ClaimTypes.Surname, user.HoTen),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};
			var userRoles = await userManager.GetRolesAsync(user);
			foreach(var role in userRoles)
			{
				authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
			}
			var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

			var token = new JwtSecurityToken(
				issuer: configuration["JWT:ValidIssuer"],
				audience: configuration["JWT:ValidAudience"],
				expires: DateTime.Now.AddMinutes(30),
				claims: authClaims,
				signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public async Task<IdentityResult> SignUpAsync(SignUpModel model)
		{
			var user = new ApplicationUser
			{
				HoTen = model.HoTen,
			    UserName=model.TenDangNhap,
				Email = model.Email,
				PhoneNumber=model.PhoneNumber,
				ChucVu = model.ChucVu
			};
			return await userManager.CreateAsync(user, model.Password);
		}
		

	}
}
