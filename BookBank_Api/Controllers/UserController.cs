using System;
using BookBank_Api.Models;
using BookBank_Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookBank_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        // esto es apra proteger un ruta en base al token
        //[Authorize]
        // revisa el token y el Rol del usaurio.

        [Authorize(Roles = ("Admin"))]

        public ActionResult<List<UserModel>> Get()
        {
            return _userService.Get();
        }

        [HttpPost]
        public ActionResult<UserModel> Create(UserModel user)
        {

            if (_userService.Create(user) == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [HttpPut]
        public ActionResult Update(UserModel user)
        {
            _userService.Uodate(user.Id!, user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _userService.Delete(id);
            var response = new
            {
                msg = $"Eliminado Correctamente el usuario con el ID: {id}!!!!"
            };

            return Ok(response);
        }
    }
}