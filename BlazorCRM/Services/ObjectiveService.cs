using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRM.Services
{
	public class ObjectiveService : IObjectiveService
	{
		private readonly IDbContextFactory<DataContext> _dbContextFactory;

		public ObjectiveService(IDbContextFactory<DataContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public Objective? NewObjective { get; set; } = new(title: string.Empty);

		public async Task<List<Objective>> GetObjectives()
		{
			await using var context = _dbContextFactory.CreateDbContext();
			return await context.Objectives.ToListAsync();
		}

		public async Task<List<Objective>> GetObjectives(int companyId)
		{
			await using var context = _dbContextFactory.CreateDbContext();
			return await context.Objectives
				.Where(objective => objective.Company != null && objective.Company.Id == companyId)
				.ToListAsync();
		}

		public async Task<Objective?> SaveObjective(Objective objective)
		{
			await using var context = _dbContextFactory.CreateDbContext();
			var newObjective = await context.Objectives.AddAsync(objective);
			return await context.SaveChangesAsync() > 0 ? newObjective.Entity : null;
		}
	}

	public interface IObjectiveService
	{
		public Objective? NewObjective { get; set; }
		public Task<List<Objective>> GetObjectives();
		public Task<List<Objective>> GetObjectives(int companyId);
		public Task<Objective?> SaveObjective(Objective objective);
	}
}