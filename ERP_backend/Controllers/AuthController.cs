using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ERP_backend.Models;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Google.Apis.Auth;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly SignInManager<ApplicationUser> _signInManager;
	private readonly RoleManager<IdentityRole<Guid>> _roleManager;
	private readonly IConfiguration _configuration;
	public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
		RoleManager<IdentityRole<Guid>> roleManager, IConfiguration configuration)
	{
		_userManager = userManager;
		_signInManager = signInManager;
		_roleManager = roleManager;
		_configuration = configuration;
	}
	[HttpGet("sign-in")]

	public IActionResult GoogleLogin()
	{
		var redirectUrl = Url.Action(nameof(GoogleResponse), "Auth", null, Request.Scheme);
		if (string.IsNullOrEmpty(redirectUrl))
		{
			return BadRequest("Invalid redirect URL");
		}

		var properties = new AuthenticationProperties
		{
			RedirectUri = redirectUrl,
			Items = { { "LoginProvider", "Google" } },
			AllowRefresh = true
		};

		return Challenge(properties, GoogleDefaults.AuthenticationScheme);
	}


	[HttpPost("google-response")]
	public async Task<IActionResult> GoogleResponse([FromBody] GoogleAuthRequest request)
	{
		var payload = await VerifyGoogleToken(request.IdToken);
		if (payload == null)
		{
			return BadRequest("Invalid Google token.");
		}

		var email = payload.Email;
		var user = await _userManager.FindByEmailAsync(email);
		if (user == null)
		{
			user = new ApplicationUser { UserName = email, Email = email };
			var createUserResult = await _userManager.CreateAsync(user);
			if (!createUserResult.Succeeded)
			{
				return BadRequest(new { errors = createUserResult.Errors.Select(e => e.Description) });
			}

			if (!await _roleManager.RoleExistsAsync("Khách hàng"))
			{
				await _roleManager.CreateAsync(new IdentityRole<Guid>("Khách hàng"));
			}
			await _userManager.AddToRoleAsync(user, "Khách hàng");
		}

		var token = await GenerateJwtToken(user);
		return Ok(new { token });
	}

	// Xác thực Google token
	private async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(string idToken)
	{
		try
		{
			var settings = new GoogleJsonWebSignature.ValidationSettings()
			{
				Audience = new List<string> { _configuration["Google:ClientId"] }
			};
			return await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
		}
		catch
		{
			return null;
		}
	}
	public class GoogleAuthRequest
	{
		public string IdToken { get; set; }
	}
	private async Task<string> GenerateJwtToken(ApplicationUser user)
	{
		var claims = new List<Claim>
	{
		new Claim(ClaimTypes.Email, user.Email),
		new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
	};

		var roles = await _userManager.GetRolesAsync(user);
		foreach (var role in roles)
		{
			claims.Add(new Claim(ClaimTypes.Role, role));
		}

		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken(
			issuer: _configuration["JWT:Issuer"],
			audience: _configuration["JWT:Audience"],
			claims: claims,
			expires: DateTime.UtcNow.AddHours(3),
			signingCredentials: creds
		);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}

}
