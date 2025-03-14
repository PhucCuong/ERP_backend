
using Microsoft.EntityFrameworkCore;
using ERP_backend.Models;
using ERP_backend.Repositories;
using ERP_backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Register Repository to DI
builder.Services.AddTransient<IBaoCaoSanXuatRepository, BaoCaoSanXuatRepository>();
builder.Services.AddTransient<IBaoTriRepository, BaoTriRepository>();
builder.Services.AddTransient<IChiPhiSanXuatRepository, ChiPhiSanXuatRepository>();
builder.Services.AddTransient<IChiTietHoatDongSanXuatRepository, ChiTietHoatDongSanXuatRepository>();

builder.Services.AddTransient<IDinhMucNguyenVatLieuRepository, DinhMucNguyenVatLieuRepository>();
builder.Services.AddTransient<IKeHoachSanXuatRepository, KeHoachSanXuatRepository>();
builder.Services.AddTransient<IKiemTraChatLuongRepository, KiemTraChatLuongRepository>();
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

// Register Service to DI
builder.Services.AddTransient<IBaoCaoSanXuatService, BaoCaoSanXuatService>();
builder.Services.AddTransient<IBaoTriService, BaoTriService>();
builder.Services.AddTransient<IChiPhiSanXuatService, ChiPhiSanXuatService>();
builder.Services.AddTransient<IChiTietHoatDongSanXuatService, ChiTietHoatDongSanXuatService>();

builder.Services.AddTransient<IDinhMucNguyenVatLieuService, DinhMucNguyenVatLieuService>();
builder.Services.AddTransient<IKeHoachSanXuatService, KeHoachSanXuatService>();
builder.Services.AddTransient<IKiemTraChatLuongService, KiemTraChatLuongService>();
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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddAuthentication(options => {
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
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
builder.Services.AddScoped<RoleManager<IdentityRole<Guid>>>();

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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin() // Cho phép tất cả các origin (frontend)
                        .AllowAnyMethod() // Cho phép tất cả các phương thức (GET, POST, PUT, DELETE)
                        .AllowAnyHeader()); // Cho phép tất cả header
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
