using ERP_backend.DTOs;

namespace ERP_backend.Services
{
	public interface IDonHangService
	{
		Task<Guid> DatHangAsync(DatHangDto datHangDTO);
		Task<DonHangResponseDto> GetDonHangChiTietAsync(Guid datHangDTO);
	}
}
