namespace BlazorCRM.Assistants
{
	public static class SqLiteQueries
	{
		public const string ListUsersPhonesEmails =
			"SELECT U.Id, U.Discriminator, U.Name, U.Surname, U.Access, P.Id, P.CompanyId, P.EmployeeId, P.PhoneNumber, P.Type, P.UserId, E.Id, E.CompanyId, E.EmailAddress, E.EmployeeId, E.Type, E.UserId FROM Users AS U LEFT JOIN Phones AS P ON U.Id = P.UserId LEFT JOIN Emails AS E ON U.Id = E.UserId ORDER BY U.Id, P.Id, E.Id;";

		public const string OneUsersPhonesEmails =
			"SELECT U.Id, U.Discriminator, U.Name, U.Surname, U.Access, P.Id, P.CompanyId, P.EmployeeId, P.PhoneNumber, P.Type, P.UserId, E.Id, E.CompanyId, E.EmailAddress, E.EmployeeId, E.Type, E.UserId FROM (SELECT u.Id, u.Discriminator, u.Name, u.Surname, u.Access FROM Users AS u WHERE u.Id = @UserId LIMIT 1) AS U LEFT JOIN Phones AS P ON U.Id = P.UserId LEFT JOIN Emails AS E ON U.Id = E.UserId ORDER BY U.Id, P.Id, E.Id;";
	}
}