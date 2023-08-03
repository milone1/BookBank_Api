using System;
namespace BookBank_Api.Helpers
{
	public class BcryptPassword
	{
		public string HashPassword(string password)
		{
			string hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
			return hashPassword;
		}

		public bool VerifyPassword(string passwordLogin, string hashPassword)
		{
			return BCrypt.Net.BCrypt.Verify(passwordLogin, hashPassword);
		}
	}
}

