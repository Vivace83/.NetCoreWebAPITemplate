using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using asp.Services;
using CoreApi.Models;
using System.Collections;
using System;
using CoreApi.Helpers;

namespace asp.Controllers
{

    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService _userService)
        {
            this._userService = _userService;
        }

        [AllowAnonymous]
        [HttpPost("/token")]
        public IActionResult Authenticate([FromBody]WebUsers userParam)
        {
            try
            {
                if (userParam == null)
                    return BadRequest(new { message = "Bad Request Data" });
                var user = _userService.Authenticate(userParam.Username, userParam.Password);

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
           
        }

        [HttpGet("/token")]
        public string ReturnUserData()
        {
            return _userService.GetRole(Convert.ToInt32(User.Identity.Name));
        }

        [HttpGet("/api/users")]
        public IActionResult GetAll()
        {
            if (_userService.GetRole(Convert.ToInt32(User.Identity.Name)) == "Admin")
            {
                var users = _userService.GetAll();
                return Ok(users);
            }

            else return Unauthorized();
        }

        
    }
}