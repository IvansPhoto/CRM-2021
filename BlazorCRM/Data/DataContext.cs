using BlazorCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRM.Services
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<User.Admin> Admins { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Objective> Objectives { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Phone> Phones { get; set; }
		public DbSet<Email> Emails { get; set; }
	}
}