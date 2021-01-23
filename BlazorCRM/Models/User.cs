﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BlazorCRM.Pages;
using WebREST_EF_50.Assistants;

namespace BlazorCRM.Models
{
	public class User
	{
		public long Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public List<Phone> Phones { get; set; } = new();
		public List<Email> Emails { get; set; } = new();

		public override string ToString()
		{
			return $"Id: {Id}, Name: {Name}, Surname: {Surname}, Phones: {Phones.Count}";
		}

		public User()
		{
		}

		public class Full : User
		{
			public List<Objectives> Objectives { get; set; } = new();
			public List<Project> Projects { get; set; } = new();
			public List<Company> Companies { get; set; } = new();
			public List<Employee> Employees { get; set; } = new();

			public Full()
			{
			}
		}

		/// <summary>
		/// Admin is a User with extended rights to manipulate with data of all users.
		/// </summary>
		public class Admin : User
		{
			public AccessLevel Access { get; set; } = AccessLevel.LocalAdmin;

			public enum AccessLevel
			{
				LocalAdmin = 0,
				SuperVisor = 1
			}

			public Admin()
			{
			}
		}
	}
}