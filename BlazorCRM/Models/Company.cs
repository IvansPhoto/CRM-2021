using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorCRM.Models
{
	public class Company
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; } = string.Empty;
		public User ResponsibleUser { get; set; }
		public List<Phone> Phones { get; set; } = new();
		public List<Email> Emails { get; set; } = new();
		public Company? HqCompany { get; set; }

		public Company(string name)
		{
			Name = name;
		}
	}
}