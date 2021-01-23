using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

		public async Task<List<User>> GetUsersDapper()
		{
			const string sqlQuery =
				"SELECT U.Id, U.Discriminator, U.Name, U.Surname, U.Access, P.Id, P.CompanyId, P.EmployeeId, P.PhoneNumber, P.Type, P.UserId, E.Id, E.CompanyId, E.EmailAddress, E.EmployeeId, E.Type, E.UserId FROM Users AS U LEFT JOIN Phones AS P ON U.Id = P.UserId LEFT JOIN Emails AS E ON U.Id = E.UserId ORDER BY U.Id, P.Id, E.Id;";
			var dictionary = new Dictionary<long, User>();
			var result = await _dapperRepo.ListOneMany<User, Phone?, Email?, dynamic>(
				connectionString: _configuration.GetConnectionString("SQLite"),
				sqlQuery: sqlQuery,
				map: (user, phone, email) =>
				{
					if (!dictionary.TryGetValue(user.Id, out var userEntry))
					{
						userEntry = user;
						dictionary.Add(userEntry.Id, userEntry);
					}
					var theUser = dictionary.GetValueOrDefault(user.Id);
					
					// Check object equality in C#.
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

		public async Task<User?> GetUser(long id)
		{
			await using var context = _dbContextFactory.CreateDbContext();
			return await context.Users
				.Include(user => user.Phones)
				.Include(user => user.Emails)
				.FirstOrDefaultAsync(user => user.Id == id);
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
		public Task<User?> GetUser(long id);
		public ValueTask<User?> GetUserEntity(long id);
		public Task<List<User>> GetUsers();
		public Task<List<User>> GetUsersDapper();
		public Task<User?> SaveUsers(User user);
	}
}