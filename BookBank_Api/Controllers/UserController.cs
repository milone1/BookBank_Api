using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookBank_Api.Models;
using BookBank_Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookBank_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public AuthService _authService;

        public UserController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public ActionResult<List<UserModel>> Get()
        {
            return _authService.Get();
        }

        [HttpPost]
        public ActionResult<UserModel> Create(UserModel user)
        {
            

            if (_authService.Create(user) == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [HttpPut]
        public ActionResult Update(UserModel user)
        {
            _authService.Uodate(user.Id, user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _authService.Delete(id);
            var response = new
            {
                msg = $"Eliminado Correctamente el usuario con el ID: {id}!!!!"
            };

            return Ok(response);
        }
    }
}