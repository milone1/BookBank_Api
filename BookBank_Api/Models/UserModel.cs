using System;
using MongoDB.Bson.Serialization.Attributes;
namespace BookBank_Api.Models
{
	public class UserModel
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

		public string? Id { get; set; }

		[BsonElement("name")]
		public string name { get; set; } = null!;

        [BsonElement("email")]
        public string email { get; set; } = null!;

        [BsonElement("img_photo")]
        public string img_photo { get; set; } = null!;

        [BsonElement("rol")]
        public string rol { get; set; } = null!;

        [BsonElement("phone")]
        public string phone { get; set; } = null!;

        [BsonElement("password")]
        public string password { get; set; } = null!;

        [BsonElement("created_at")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)] // O puedes usar Kind = DateTimeKind.Utc si prefieres guardar la fecha en UTC.
        public DateTime? created_at { get; set; } = DateTime.Now;

    }
}

