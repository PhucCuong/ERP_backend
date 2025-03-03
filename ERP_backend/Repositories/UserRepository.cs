
using ERP_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly QlySanXuatErpContext _context;

		public UserRepository(QlySanXuatErpContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<User>> GetAll()
		{
			return await _context.Users.ToListAsync();
		}

		public async Task<User> GetById(Guid id)
		{
			return await _context.Users.FindAsync(id);
		}

		public async Task<User> Update(User input)
		{
			var result = _context.Users.Update(input).Entity;

			await _context.SaveChangesAsync();
			return result;
		}
		public async Task<User> Add(User input)
		{
			var result = _context.Users.Add(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		public async Task<User> Delete(User input)
		{
			var result = _context.Users.Remove(input).Entity;
			await _context.SaveChangesAsync();
			return result;
		}

		
	}
}
