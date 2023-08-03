using System;
using BookBank_Api.Models;
using MongoDB.Driver;

namespace BookBank_Api.Services
{
	public class AuthService
	{
        private IMongoCollection<UserModel> _users;

        public AuthService(IDatabaseSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _users = database.GetCollection<UserModel>(settings.Collection);
        }

        public List<UserModel> Get()
        {
            // retorna todos los usuarios usando el lambda y pniendolo en true
            return _users.Find(d => true).ToList();
        }

        public UserModel Create(UserModel user)
        {
            // Check for duplicate email
            var existingUser = _users.Find(u => u.email == user.email).FirstOrDefault();
            if (existingUser != null)
            {
                // If a user with the same email already exists, return false to indicate a conflict
                return null;
            }

            // Insert the new user
            _users.InsertOne(user);

            // Return the newly created user
            return user;
        }

        public void Uodate(string id, UserModel user)
        {
            _users.ReplaceOne(user => user.Id == id, user);
        }

        public void Delete(string id)
        {
            _users.DeleteOne(d => d.Id == id);
        }

    }
}

