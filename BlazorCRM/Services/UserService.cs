using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCRM.Assistants;
using BlazorCRM.Data;
using BlazorCRM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

namespace BlazorCRM.Services
{
	public class UserService : IUserService
	{
		private readonly IDbContextFactory<DataContext> _dbContextFactory;
		private readonly IDapperRepo _dapperRepo;
		private readonly IConfiguration _configuration;

		public UserService(IDbContextFactory<DataContext> dbContextFactory, IDapperRepo dapperRepo, IConfiguration configuration)
		{
			_dbContextFactory = dbContextFactory;
			_dapperRepo = dapperRepo;
			_configuration = configuration;
		}

		public User? NewUser { get; set; } = new();

		public async Task<List<User>> GetListUsers()
		{
			var dictionary = new Dictionary<long, User>();
			var result = await _dapperRepo.ListOneMany<User, Phone?, Email?, dynamic>(
				connectionString: _configuration.GetConnectionString("SQLite"),
				sqlQuery: SqLiteQueries.ListUsersPhonesEmails,
				map: (user, phone, email) =>
				{
					if (!dictionary.TryGetValue(user.Id, out var userEntry))
					{
						userEntry = user;
						dictionary.Add(userEntry.Id, userEntry);
					}
					var theUser = dictionary.GetValueOrDefault(user.Id);
					
					// TODO: Check object equality in C#.
					// if(phone != null && !theUser.Phones.Contains(phone)) userEntry.Phones.Add(phone);
					
					if(phone != null && theUser != null)
					{
						var phoneIsExist = theUser.Phones.Any(userPhone => userPhone.Id == phone.Id);
						if (!phoneIsExist) userEntry.Phones.Add(phone);
					}
					
					if(email != null && theUser != null)
					{
						var phoneIsExist = theUser.Emails.Any(userEmail => userEmail.Id == email.Id);
						if (!phoneIsExist) userEntry.Emails.Add(email);
					}
					
					return userEntry;
				},
				parameters: new {},
				split: "Id"
			);
			return result;
		}
		
		public async Task<List<User>> GetUsers()
		{
			await using var context = _dbContextFactory.CreateDbContext();
			return await context.Users
				.Include(user => user.Phones)
				.Include(user => user.Emails)
				.ToListAsync();
		}

		public async Task<User?> GetOneUser(long id)
		{
			var dictionary = new Dictionary<long, User>();
			var result = await _dapperRepo.ListOneMany<User, Phone?, Email?, dynamic>(
				connectionString: _configuration.GetConnectionString("SQLite"),
				sqlQuery: SqLiteQueries.OneUsersPhonesEmails,
				map: (user, phone, email) =>
				{
					if (!dictionary.TryGetValue(user.Id, out var userEntry))
					{
						userEntry = user;
						dictionary.Add(userEntry.Id, userEntry);
					}
					var theUser = dictionary.GetValueOrDefault(user.Id);
					
					// TODO: Check object equality in C#.
					// if(phone != null && !theUser.Phones.Contains(phone)) userEntry.Phones.Add(phone);
					
					if(phone != null && theUser != null)
					{
						var phoneIsExist = theUser.Phones.Any(userPhone => userPhone.Id == phone.Id);
						if (!phoneIsExist) userEntry.Phones.Add(phone);
					}
					
					if(email != null && theUser != null)
					{
						var phoneIsExist = theUser.Emails.Any(userEmail => userEmail.Id == email.Id);
						if (!phoneIsExist) userEntry.Emails.Add(email);
					}
					
					return userEntry;
				},
				parameters: new {},
				split: "Id"
			);
			return result[0];
		}

		public async ValueTask<User?> GetUserEntity(long id)
		{
			await using var context = _dbContextFactory.CreateDbContext();
			return await context.Users.FindAsync(id);
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
		public Task<User?> GetOneUser(long id);
		// public Task<User?> GetFullUser(long id);
		public ValueTask<User?> GetUserEntity(long id);
		public Task<List<User>> GetUsers();
		public Task<List<User>> GetListUsers();
		public Task<User?> SaveUsers(User user);
	}
}