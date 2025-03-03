using ERP_backend.DTOs;
using ERP_backend.Models;
using ERP_backend.Repositories;

namespace ERP_backend.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		public async Task<UserDto> Add(UserDto input)
		{
			var convertData = ConvertDtoToUser(input);
			var result = await _userRepository.Add(convertData);
			return ConvertUserToDto(result);
		}

		public async Task<UserDto> Delete(UserDto input)
		{
			var convertData = ConvertDtoToUser(input);
			var result = await _userRepository.Delete(convertData);
			return ConvertUserToDto(result);
		}

		public async Task<IEnumerable<UserDto>> GetAll()
		{
			var result = await _userRepository.GetAll();
			return ConvertListUserToDto(result);
		}

		public async Task<UserDto> GetById(Guid id)
		{
			var result = await _userRepository.GetById(id);
			return ConvertUserToDto(result);
		}

		public async Task<UserDto> Update(UserDto input)
		{
			var convertData = ConvertDtoToUser(input);
			var result = await _userRepository.Update(convertData);
			return ConvertUserToDto(result);
		}
		private UserDto ConvertUserToDto(User input)
		{
			var result = new UserDto();
			if (input == null)
			{
				return result;
			}
			result.MaUser = input.MaUser;
			result.TenDangNhap = input.TenDangNhap;
			result.MatKhau = input.MatKhau;
			result.HoTen = input.HoTen;
			result.Email = input.Email;
			result.SoDienThoai = input.SoDienThoai;
			result.NgayTao = input.NgayTao;
			result.NgayChinhSua = input.NgayChinhSua;
			result.MaChucVu = input.MaChucVu;
			return result;
		}

		private IEnumerable<UserDto> ConvertListUserToDto(IEnumerable<User> input)
		{
			var result = new List<UserDto>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertUserToDto(item));
			}

			return result;
		}

		private User ConvertDtoToUser(UserDto input)
		{
			var result = new User();
			if (input == null)
			{
				return result;
			}
			result.MaUser = input.MaUser;
			result.TenDangNhap = input.TenDangNhap;
			result.MatKhau = input.MatKhau;
			result.HoTen = input.HoTen;
			result.Email = input.Email;
			result.SoDienThoai = input.SoDienThoai;
			result.NgayTao = input.NgayTao;
			result.NgayChinhSua = input.NgayChinhSua;
			result.MaChucVu = input.MaChucVu;
			return result;
		}
		private IEnumerable<User> ConvertListDtoToUser(IEnumerable<UserDto> input)
		{
			var result = new List<User>();

			if (input == null && !input.Any())
			{
				return result;
			}

			foreach (var item in input)
			{
				result.Add(ConvertDtoToUser(item));
			}

			return result;
		} 
	}

}
