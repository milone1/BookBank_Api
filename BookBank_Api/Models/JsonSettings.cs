using System;
namespace BookBank_Api.Models
{
    public class JsonSettings : IJsonSettings
    {

        public string Key { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;

    }

    public interface IJsonSettings
    {
        string Key { get; set; }
        string Issuer { get; set; }
        string Audience { get; set; }
    }
}

