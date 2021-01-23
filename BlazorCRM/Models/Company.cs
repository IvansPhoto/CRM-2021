using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlazorCRM.Pages;

namespace BlazorCRM.Models
{
	public class Company
	{
		public long Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public List<Phone> Phones { get; set; } = new();
		public List<Email> Emails { get; set; } = new();
		public User? ResponsibleUser { get; set; }
		public Company? HqCompany { get; set; }

		public override string ToString()
		{
			return $"Id: {Id}, Name: {Address}, ResponsibleUser: {ResponsibleUser?.Id}-{ResponsibleUser?.Name}-{ResponsibleUser?.Surname}";
		}

		public Company()
		{
		}

		public Company(string name)
		{
			Name = name;
		}

		public Company(string name, string address) : this(name)
		{
			Address = address;
		}

		public class Full : Company
		{
			public List<Objectives> Objectives { get; set; } = new();
			public List<Employee> Employees { get; set; } = new();
			public List<Project> Projects { get; set; } = new();

			public Full()
			{
			}
		}
	}
}