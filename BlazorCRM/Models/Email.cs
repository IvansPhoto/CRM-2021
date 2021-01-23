using System.ComponentModel.DataAnnotations;
using WebREST_EF_50.Assistants;

namespace BlazorCRM.Models
{
	public class Email
	{
		public long Id { get; set; }
		public string EmailAddress { get; set; }
		public ContactType Type { get; set; } = ContactType.Unknown;

		public Email()
		{
			
		}
		public Email(string emailAddress)
		{
			EmailAddress = emailAddress;
		}
	}
}