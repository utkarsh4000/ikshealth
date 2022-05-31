using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MovieApp.Business.Services;
using MyMovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService _userServices;

        public UserController(UserService userService)
        {
            _userServices = userService;
        }

        [HttpGet("SelectUsers")]
        public IActionResult SelectUsers()
        {
            return Ok(_userServices.selectUser());
        }

        [HttpPost("Register")]
        public IActionResult Register(UserModel userModel)
        {
            return Ok(_userServices.Register(userModel));
        }

        [HttpPost("Login")]
        public IActionResult Login(UserModel userModel)
        {
            return Ok(_userServices.Login(userModel));
        }

        [HttpPut("Update")]
        public IActionResult Update(UserModel userModel)
        {
            return Ok(_userServices.Update(userModel));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_userServices.Delete(id));
        }

        [HttpGet("SelectUserById")]
        public IActionResult SelectUserById(int id)
        {
            return Ok(_userServices.SelectUserById(id));
        }
    }
}
