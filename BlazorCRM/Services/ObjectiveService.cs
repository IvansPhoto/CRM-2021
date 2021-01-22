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

		public Objective? NewObjective { get; set; } = new(title: "Call") {Description = "Call to"};

		public async Task<List<Objective>> GetObjectives()
		{
			await using var context = _dbContextFactory.CreateDbContext();
			return await context.Objectives
				.Include(objective => objective.ResponsibleUser)
				.Include(objective => objective.Company)
				.Include(objective => objective.Employee)
				.ToListAsync();
		}

		public async Task<List<Objective>> GetObjectives(long companyId)
		{
			await using var context = _dbContextFactory.CreateDbContext();
			return await context.Objectives
				.Where(objective => objective.Company != null && objective.Company.Id == companyId)
				.Include(objective => objective.ResponsibleUser)
				.Include(objective => objective.Company)
				.Include(objective => objective.Employee)
				.ToListAsync();
		}

		public async Task<Objective?> SaveObjective(Objective objective)
		{
			await using var context = _dbContextFactory.CreateDbContext();
			// return context.Objectives.FromSqlInterpolated(
			// 	$"INSERT INTO Objectives (Title, Description, CreateDate, FinishDate, IsFinished, ObjectType, ResponsibleUserId) VALUES ({objective.Title}, {objective.Description}, {objective.CreateDate}, {objective.FinishDate}, {objective.IsFinished}, {objective.ObjectType}, {objective.ResponsibleUser.Id})");
			var newObjective = await context.Objectives.AddAsync(objective);
			return await context.SaveChangesAsync() > 0 ? newObjective.Entity : null;
		}
	}

	public interface IObjectiveService
	{
		public Objective? NewObjective { get; set; }
		public Task<List<Objective>> GetObjectives();
		public Task<List<Objective>> GetObjectives(long companyId);
		public Task<Objective?> SaveObjective(Objective objective);
	}
}