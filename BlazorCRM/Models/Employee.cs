using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorCRM.Models
{
	public class Employee
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; } = string.Empty;
		public User? ResponsibleUser { get; set; }
		public List<Phone> Phones { get; set; } = new();
		public List<Email> Emails { get; set; } = new();
		public Company? Company { get; set; }
		
		public Employee(string name)
		{
			Name = name;
		}
	}
}