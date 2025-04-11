using ERP_backend.DTOs;
using ERP_backend.Models;

namespace ERP_backend.Services
{
	public interface ILenhGoBoService
	{
	Task<IEnumerable<LenhGoBoDto>> GetAll();
		Task<LenhGoBoDto> GetById(int id);
		Task<LenhGoBoDto> Update(LenhGoBoDto input);
		Task<LenhGoBoDto> Add(LenhGoBoDto input);
		Task<LenhGoBoDto> Delete(LenhGoBoDto input);
	}
}
