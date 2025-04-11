using System;
using System.Linq;
using System.Threading.Tasks;
using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;
using Microsoft.EntityFrameworkCore;

public class DonHangRepository : IDonHangRepository
{
	private readonly QlySanXuatErpContext _context;

	public DonHangRepository(QlySanXuatErpContext context)
	{
		_context = context;
	}

	public async Task<Guid> DatHangAsync(DatHangDto datHangDTO)
	{
		using var transaction = await _context.Database.BeginTransactionAsync();
		try
		{
			// 1️⃣ Tạo đơn hàng mới
			var donHang = new DonHang
			{
				MaDonHang = Guid.NewGuid(),
				MaKhachHang = datHangDTO.MaKhachHang,
				NgayDatHang = DateTime.UtcNow,
				TrangThai = "Pending",
				TongTien = 0
			};
			_context.DonHangs.Add(donHang);
			await _context.SaveChangesAsync();

			// 2️⃣ Lưu chi tiết đơn hàng
			var chiTietList = new List<ChiTietDonHang>();
			decimal tongTien = 0;

			foreach (var item in datHangDTO.SanPhamChiTiets)
			{
				var sanPham = await _context.SanPhams.FindAsync(item.MaSanPham);
				if (sanPham == null)
					throw new Exception("Sản phẩm không tồn tại");

				var chiTiet = new ChiTietDonHang
				{
					MaDonHang = donHang.MaDonHang,
					MaSanPham = item.MaSanPham,
					SoLuong = item.SoLuong,
					GiaSanPham = sanPham.GiaBan
				};
				tongTien += (decimal)(chiTiet.SoLuong * chiTiet.GiaSanPham.GetValueOrDefault());
				chiTietList.Add(chiTiet);
			}

			_context.ChiTietDonHangs.AddRange(chiTietList);
			donHang.TongTien = tongTien;
			await _context.SaveChangesAsync();

			await transaction.CommitAsync();
			return donHang.MaDonHang;
		}
		catch
		{
			await transaction.RollbackAsync();
			throw;
		}
	}
	public async Task<DonHangResponseDto> GetDonHangChiTietAsync(Guid maDonHang)
	{
		var donHang = await _context.DonHangs
			.Where(d => d.MaDonHang == maDonHang)
			.Select(d => new DonHangResponseDto
			{
				MaDonHang = d.MaDonHang,
				TongTien = d.TongTien.GetValueOrDefault(),
				NgayDatHang = d.NgayDatHang.GetValueOrDefault(),
				TrangThai = d.TrangThai
			})
			.FirstOrDefaultAsync();

		if (donHang == null)
			throw new Exception("Đơn hàng không tồn tại");

		return donHang;
	}
}
