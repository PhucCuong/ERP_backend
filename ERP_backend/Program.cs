
using Microsoft.EntityFrameworkCore;
using ERP_backend.Models;
using ERP_backend.Repositories;
using ERP_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Register Repository to DI
builder.Services.AddTransient<IBaoCaoSanXuatRepository, BaoCaoSanXuatRepository>();
builder.Services.AddTransient<IBaoTriRepository, BaoTriRepository>();
builder.Services.AddTransient<IChiPhiSanXuatRepository, ChiPhiSanXuatRepository>();
builder.Services.AddTransient<IChiTietHoatDongSanXuatRepository, ChiTietHoatDongSanXuatRepository>();
builder.Services.AddTransient<IChucVuRepository, ChucVuRespository>();
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
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<INguyenVatLieuRepository, NguyenVatLieuRepository>();
builder.Services.AddTransient<IKhoRepository, KhoRepository>();
builder.Services.AddTransient<ITonKhoRepository, TonKhoRepository>();
// Register Service to DI
builder.Services.AddTransient<IBaoCaoSanXuatService, BaoCaoSanXuatService>();
builder.Services.AddTransient<IBaoTriService, BaoTriService>();
builder.Services.AddTransient<IChiPhiSanXuatService, ChiPhiSanXuatService>();
builder.Services.AddTransient<IChiTietHoatDongSanXuatService, ChiTietHoatDongSanXuatService>();
builder.Services.AddTransient<IChucVuService, ChucVuService>();
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
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IKhoService, KhoService>();
builder.Services.AddTransient<ITonKhoService, TonKhoService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddDbContext<QlySanXuatErpContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
