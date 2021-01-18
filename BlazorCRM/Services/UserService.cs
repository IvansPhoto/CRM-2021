using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRM.Services
{
	public class UserService : IUserService
	{
		private readonly IDbContextFactory<DataContext> _dbContextFactory;

		public UserService(IDbContextFactory<DataContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public User? NewUser { get; set; } = new();

		public async Task<List<User>> GetUsers()
		{
			await using var context = _dbContextFactory.CreateDbContext();
			return await context.Users.ToListAsync();
		}

		public async Task<List<User>> GetUsers(int id)
		{
			await using var context = _dbContextFactory.CreateDbContext();
			return await context.Users
				.Where(user => user.Id == id)
				.ToListAsync();
		}
		
		public async Task<User?> GetUser(int id)
		{
			await using var context = _dbContextFactory.CreateDbContext();
			return await context.Users.FirstOrDefaultAsync(user => user.Id == id);
		}
		
		public async Task<User?> SaveUsers(User user)
		{
			await using var context = _dbContextFactory.CreateDbContext();
			var newUser = await context.Users.AddAsync(user);
			return await context.SaveChangesAsync() > 0 ? newUser.Entity : null;
		}
	}

	public interface IUserService
	{
		public User? NewUser { get; set; }
		public Task<User?> GetUser(int id);
		public Task<List<User>> GetUsers();
		public Task<List<User>> GetUsers(int id);
		public Task<User?> SaveUsers(User user);
	}
}