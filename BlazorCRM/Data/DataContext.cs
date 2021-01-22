using BlazorCRM.Models;
using BlazorCRM.Pages;
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
		// protected override void OnModelCreating(ModelBuilder modelBuilder)
		// {
		// 	modelBuilder.Entity<Users>().Property("PhoneForeignKey");
		// 	modelBuilder.Entity<Users>().Property("EmailForeignKey");
		// 	modelBuilder.Entity<Users>().Property("CompanyForeignKey");
		// 	modelBuilder.Entity<Users>().Property("EmployeeForeignKey");
		// 	modelBuilder.Entity<Users>().Property("ObjForeignKey");
		// 	modelBuilder.Entity<Users>().Property("ProjectForeignKey");
		//
		// 	modelBuilder.Entity<User>().HasOne(u => u.Emails);
		// 	modelBuilder.Entity<User>().HasOne(u => u.Phones);
		// }
	}
}