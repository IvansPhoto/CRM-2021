﻿using System.ComponentModel.DataAnnotations;
using WebREST_EF_50.Assistants;

namespace BlazorCRM.Models
{
	public class Phone
	{
		public long Id { get; set; }
		public string PhoneNumber { get; set; }
		public ContactType Type { get; set; } = ContactType.Unknown;
		
		public Phone(string phoneNumber)
		{
			PhoneNumber = phoneNumber;
		}
	}
}