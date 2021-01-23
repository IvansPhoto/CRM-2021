using System.ComponentModel.DataAnnotations;
using WebREST_EF_50.Assistants;

namespace BlazorCRM.Models
{
	public class Email
	{
		public long Id { get; set; }
		public string EmailAddress { get; set; } = string.Empty;
		public ContactType Type { get; set; } = ContactType.Unknown;

		public Email()
		{
		}

		public Email(string emailAddress)
		{
			EmailAddress = emailAddress;
		}

		public Email(string emailAddress, ContactType contactType) : this(emailAddress)
		{
			Type = contactType;
		}

		public class Full : Email
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