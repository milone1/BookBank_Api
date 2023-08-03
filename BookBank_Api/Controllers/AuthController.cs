using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookBank_Api.Models;
using BookBank_Api.Helpers;
using BookBank_Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookBank_Api.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthService _authService;
        private readonly IJsonSettings _jsonSettings;
        Jwt _jwToken = new Jwt();

        public AuthController(AuthService authService, IJsonSettings jsonSettings)
        {
            _authService = authService;
            _jsonSettings = jsonSettings;
        }

        [HttpPost]
        public ActionResult<LoginModel> Login(LoginModel user)
        {

            UserModel usuarioBD = _authService.Login(user);

            if (usuarioBD != null)
            {
                string token = _jwToken.Generate(_jsonSettings.Key,usuarioBD, _jsonSettings.Issuer, _jsonSettings.Audience);

                var userNopassword = new
                {
                    usuarioBD.name,
                    usuarioBD.Id,
                    usuarioBD.email,
                    usuarioBD.img_photo,
                    usuarioBD.rol,
                    usuarioBD.phone,
                    usuarioBD.created_at
                };

                var result = new
                {
                    user = userNopassword,
                    token
                };

                return Ok(result);
            }

            return BadRequest("Login Incorrecto");
        }

    }
}
