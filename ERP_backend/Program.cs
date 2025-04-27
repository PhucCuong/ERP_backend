
using Microsoft.EntityFrameworkCore;
using ERP_backend.Models;
using ERP_backend.Repositories;
using ERP_backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Register Repository to DI
builder.Services.AddTransient<IBaoCaoSanXuatRepository, BaoCaoSanXuatRepository>();
builder.Services.AddTransient<IBaoTriRepository, BaoTriRepository>();
builder.Services.AddTransient<IChiPhiSanXuatRepository, ChiPhiSanXuatRepository>();
builder.Services.AddTransient<IChiTietHoatDongSanXuatRepository, ChiTietHoatDongSanXuatRepository>();

builder.Services.AddTransient<IDinhMucNguyenVatLieuRepository, DinhMucNguyenVatLieuRepository>();
builder.Services.AddTransient<IKeHoachSanXuatRepository, KeHoachSanXuatRepository>();
builder.Services.AddTransient<ILenhGoBoRepository, LenhGoBoRepository>();

builder.Services.AddTransient<ILenhSanXuatRepository, LenhSanXuatRepository>();
builder.Services.AddTransient<INguyenVatLieuRepository, NguyenVatLieuRepository>();
builder.Services.AddTransient<INhaMayRepository, NhaMayRepository>();
builder.Services.AddTransient<INhapKhoRepository, NhapKhoRepository>();
builder.Services.AddTransient<IQuyTrinhSanXuatRepository, QuyTrinhSanXuatRepository>();
builder.Services.AddTransient<ISanPhamRepository, SanPhamRepository>();
builder.Services.AddScoped<ISanPhamImgRepository, SanPhamImgRepository>();

builder.Services.AddTransient<INguyenVatLieuRepository, NguyenVatLieuRepository>();
builder.Services.AddTransient<IKhoRepository, KhoRepository>();
builder.Services.AddTransient<ITonKhoRepository, TonKhoRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IDonHangRepository, DonHangRepository>();

builder.Services.AddScoped<INhaCungCapRepository, NhaCungCapRepository>();
builder.Services.AddScoped<IYeuCauNguyenVatLieuRepository, YeuCauNguyenVatLieuRepository>();

// Register Service to DI
builder.Services.AddTransient<IBaoCaoSanXuatService, BaoCaoSanXuatService>();
builder.Services.AddTransient<IBaoTriService, BaoTriService>();
builder.Services.AddTransient<IChiPhiSanXuatService, ChiPhiSanXuatService>();
builder.Services.AddTransient<IChiTietHoatDongSanXuatService, ChiTietHoatDongSanXuatService>();

builder.Services.AddTransient<IDinhMucNguyenVatLieuService, DinhMucNguyenVatLieuService>();
builder.Services.AddTransient<IKeHoachSanXuatService, KeHoachSanXuatService>();
builder.Services.AddTransient<ILenhGoBoService, LenhGoBoService>();

builder.Services.AddTransient<ILenhSanXuatService, LenhSanXuatService>();
builder.Services.AddTransient<INguyenVatLieuService, NguyenVatLieuService>();
builder.Services.AddTransient<INhaMayService, NhaMayService>();
builder.Services.AddTransient<INhapKhoService, NhapKhoService>();
builder.Services.AddTransient<IQuyTrinhSanXuatService, QuyTrinhSanXuatService>();
builder.Services.AddTransient<ISanPhamService, SanPhamService>();
builder.Services.AddTransient<ISanPhamImgService, SanPhamImgService>();

builder.Services.AddTransient<IKhoService, KhoService>();
builder.Services.AddTransient<ITonKhoService, TonKhoService>();
builder.Services.AddTransient<IDonHangService, DonHangService>();
builder.Services.AddScoped<INhaCungCapService, NhaCungCapService>();
builder.Services.AddScoped<IYeuCauNguyenVatLieuService, YeuCauNguyenVatLieuService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddHttpContextAccessor();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);
builder.Services.AddAuthentication(options => {

	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

	options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
}).AddCookie().AddGoogle(
	GoogleDefaults.AuthenticationScheme,options =>
	{
		options.ClientId = builder.Configuration["GoogleKeys:ClientId"];
		options.ClientSecret = builder.Configuration["GoogleKeys:ClientSecret"];
		options.CallbackPath = "/signin-google";

		options.CorrelationCookie.SameSite = SameSiteMode.Lax;
		options.CorrelationCookie.SecurePolicy = CookieSecurePolicy.Always;

		options.Events.OnRemoteFailure = context =>
		{
			Console.WriteLine($"Google authentication failed: {context.Failure?.Message}");
			if (context.Failure != null)
			{
				Console.WriteLine($"StackTrace: {context.Failure.StackTrace}");
				Console.WriteLine($"InnerException: {context.Failure.InnerException}");
			}
			context.HandleResponse();
			context.Response.Redirect("/api/auth/error?message=GoogleAuthFailed");
			return Task.CompletedTask;
		};
	}).AddJwtBearer(options => {
	options.SaveToken = true;
	options.RequireHttpsMetadata = false;	
	options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidAudience = builder.Configuration["JWT:ValidAudience"],
		ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
	};
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
	.AddEntityFrameworkStores<QlySanXuatErpContext>()
	.AddDefaultTokenProviders();

builder.Services.AddDbContext<QlySanXuatErpContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddSwaggerGen(option =>
{
	option.SwaggerDoc("v1", new OpenApiInfo { Title = "QLSX API", Version = "v1" });
	option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		In = ParameterLocation.Header,
		Description = "Please enter a valid token",
		Name = "Authorization",
		Type = SecuritySchemeType.Http,
		BearerFormat = "JWT",
		Scheme = "Bearer"
	});
	option.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type=ReferenceType.SecurityScheme,
					Id="Bearer"
				}
			},
			new string[]{}
		}
	});
});
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll",
		builder => builder.AllowAnyOrigin()
						  .AllowAnyMethod()
						  .AllowAnyHeader());
});


builder.Services.ConfigureApplicationCookie(options =>
{
	options.Cookie.SameSite = SameSiteMode.Lax; // hoặc None nếu dùng HTTPS
	options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Bắt buộc HTTPS
});
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseCookiePolicy(new CookiePolicyOptions
{
	MinimumSameSitePolicy = SameSiteMode.Lax 
});
app.UseStaticFiles(new StaticFileOptions
{
	FileProvider = new PhysicalFileProvider(
		Path.Combine(builder.Environment.WebRootPath, "Uploads")),
	RequestPath = "/Uploads"
});
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
