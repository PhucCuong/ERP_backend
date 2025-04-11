using ERP_backend.DTOs;
using ERP_backend.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/donhang")]
[ApiController]
public class DonHangController : ControllerBase
{
	private readonly IDonHangService _donHangService;
	public DonHangController(IDonHangService donHangService)
	{
		_donHangService = donHangService;
	}

	// API để khách hàng đặt hàng
	[HttpPost("dat-hang")]
	public async Task<IActionResult> DatHang([FromBody] DatHangDto datHangDTO)
	{
		if (datHangDTO == null || !datHangDTO.SanPhamChiTiets.Any())
			return BadRequest("Dữ liệu không hợp lệ!");

		var maDonHang = await _donHangService.DatHangAsync(datHangDTO);
		return Ok(new { MaDonHang = maDonHang, Message = "Đặt hàng thành công!" });
	}

	// API để xem chi tiết đơn hàng
	[HttpGet("{maDonHang}")]
	public async Task<IActionResult> GetDonHangChiTiet(Guid maDonHang)
	{
		var donHang = await _donHangService.GetDonHangChiTietAsync(maDonHang);
		return Ok(donHang);
	}
}
