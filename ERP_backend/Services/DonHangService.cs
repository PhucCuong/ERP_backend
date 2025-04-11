using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;
using ERP_backend.Services;

public class DonHangService : IDonHangService
{
	private readonly IDonHangRepository _donHangRepository;

	public DonHangService(IDonHangRepository donHangRepository)
	{
		_donHangRepository = donHangRepository;
	}

	public async Task<Guid> DatHangAsync(DatHangDto datHangDTO)
	{
		return await _donHangRepository.DatHangAsync(datHangDTO);
	}

	public async Task<DonHangResponseDto> GetDonHangChiTietAsync(Guid datHangDTO)
	{
		return await _donHangRepository.GetDonHangChiTietAsync(datHangDTO);
	}
}
