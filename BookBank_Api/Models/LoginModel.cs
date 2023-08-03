using System;
namespace BookBank_Api.Models
{
	public class LoginModel
	{
		public string email { get; set; } = null!;
		public string password { get; set; } = null!;
	}
}

