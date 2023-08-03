using System;

namespace BookBank_Api.Models
{
	public class DatabaseSettings: IDatabaseSettings
    {
		
		public string Server { get; set; } = null!;
		public string Database { get; set; } = null!;
		public string Collection { get; set; } = null!;

    }

    public interface IDatabaseSettings
    {
        string Server { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
    }
}

