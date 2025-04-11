using ERP_backend.DTOs;

namespace ERP_backend.Repositories
{
	public interface IDonHangRepository
	{
		Task<Guid> DatHangAsync(DatHangDto request);
		Task<DonHangResponseDto> GetDonHangChiTietAsync(Guid datHangDTO);
	}
}

