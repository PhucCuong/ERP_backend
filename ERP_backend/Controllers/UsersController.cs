using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERP_backend.Models;
using ERP_backend.DTOs;
using ERP_backend.Repositories;
using ERP_backend.Services;

namespace ERP_backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserxController : ControllerBase
	{
		private readonly IUserService _UserService;

		public UserxController(IUserService User)
		{
			_UserService = User;
		}

		// GET: api/Userx
		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
		{
			var result = await _UserService.GetAll();
			return Ok(result);
		}

		// GET: api/Userx/5
		[HttpGet("{id}")]
		public async Task<ActionResult<UserDto>> GetUser(Guid id)
		{
			var User = await _UserService.GetById(id);

			//if (BaoCaoSanXuat == null)
			//{
			//    return NotFound();
			//}

			return User;
		}

		// PUT: api/Userx/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutUser(Guid id, UserDto User)
		{
			if (id != User.MaUser)
			{
				return BadRequest();
			}

			try
			{
				await _UserService.Update(User);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await _UserService.GetById(id) == null)
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Userx
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<UserDto>> PostUser(UserDto User)
		{

			var result = await _UserService.Add(User);

			return CreatedAtAction("GetUser", new { id = User.MaUser }, User);
		}

		// DELETE: api/Userx/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(Guid id)
		{
			var User = await _UserService.GetById(id);
			if (User == null)
			{
				return NotFound();
			}

			await _UserService.Delete(User);

			return NoContent();
		}
	}

	//private bool UserExists(Guid id)
	//{
	//    return _context.Users.Any(e => e.MaDinhMuc == id);
	//}
}
