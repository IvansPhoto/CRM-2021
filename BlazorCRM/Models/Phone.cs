using System.ComponentModel.DataAnnotations;
using WebREST_EF_50.Assistants;

namespace BlazorCRM.Models
{
	public class Phone
	{
		public long Id { get; set; }
		public string PhoneNumber { get; set; } = string.Empty;
		public ContactType Type { get; set; } = ContactType.Unknown;

		public override string ToString()
		{
			return $"Id: {Id}, PhoneNumber: {PhoneNumber}, ContactType: {Type}";
		}

		public Phone()
		{
		}

		public Phone(string phoneNumber)
		{
			PhoneNumber = phoneNumber;
		}

		public Phone(string phoneNumber, ContactType contactType) : this(phoneNumber)
		{
			Type = contactType;
		}
		public class Full : Phone
		{
			public User? RelatedUser { get; set; }
			public Company? RelatedCompany { get; set; }
			public Employee? RelatedEmployee { get; set; }

			public Full()
			{
				
			}
		}
	}
}