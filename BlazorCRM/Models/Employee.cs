using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlazorCRM.Pages;

namespace BlazorCRM.Models
{
	public class Employee
	{
		public long Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public User? ResponsibleUser { get; set; }
		public List<Phone> Phones { get; set; } = new();
		public List<Email> Emails { get; set; } = new();
		public Company? Company { get; set; }

		public Employee()
		{
		}

		public Employee(string name)
		{
			Name = name;
		}

		public Employee(string name, string surname) : this(name)
		{
			Surname = surname;
		}

		public class Full : Employee
		{
			public List<Objectives> Objectives { get; set; } = new();
			public List<Project> Projects { get; set; } = new();
		}
	}
}