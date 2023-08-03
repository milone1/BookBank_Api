using System;
using BookBank_Api.Helpers;
using BookBank_Api.Models;
using MongoDB.Driver;

namespace BookBank_Api.Services
{
	public class AuthService
	{
        private IMongoCollection<UserModel> _users;
        BcryptPassword _bcriotPassword = new BcryptPassword();

        public AuthService(IDatabaseSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _users = database.GetCollection<UserModel>(settings.Collection);
        }

        public UserModel Login(LoginModel user)
        {
            // Crea un filtro para buscar el usuario por email
            var filter = Builders<UserModel>.Filter.Eq(u => u.email, user.email);

            // retorna todos los usuarios usando el lambda y pniendolo en true
            UserModel usuarioBd = _users.Find(filter).FirstOrDefault();

            if (usuarioBd == null)
            {
                return null;
            }

            if (_bcriotPassword.VerifyPassword(user.password, usuarioBd.password) == false)
            {
                return null;
            }



            return usuarioBd;
        }
    }
}

