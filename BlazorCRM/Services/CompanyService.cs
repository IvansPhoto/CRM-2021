using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRM.Services
{
	public class CompanyService : ICompanyService
	{
		private readonly IDbContextFactory<DataContext> _dbContextFactory;

		public CompanyService(IDbContextFactory<DataContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public Company? NewCompany { get; set; } = new(name: string.Empty);

		public async Task<List<Company>> GetCompanies()
		{
			await using var context = _dbContextFactory.CreateDbContext();
			return await context.Companies.ToListAsync();
		}

		public async Task<List<Company>> GetCompanies(int userId)
		{
			await using var context = _dbContextFactory.CreateDbContext();
			return await context.Companies
				.Where(objective => objective.ResponsibleUser.Id == userId)
				.ToListAsync();
		}
	}

	public interface ICompanyService
	{
		public Company? NewCompany  { get; set; }
		public Task<List<Company>> GetCompanies();
		public Task<List<Company>> GetCompanies(int userId);
	}
}