using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Services;
using Project.Database.Dtos.Request;

namespace Project.API.Controllers
{
    public class UsersController : BaseController
    {
        private UsersService usersService { get; set; }

        public UsersController(UsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpPost("/register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterRequest payload)
        {
            usersService.Register(payload);
            return Ok("Registration successful");
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public IActionResult Login(LoginRequest payload)
        {
            var jwtToken = usersService.Login(payload);

            return Ok(new { token = jwtToken });
        }

        [HttpPost("/login/admin")]
        [AllowAnonymous]
        public IActionResult LoginAdmin(LoginRequest payload)
        {
            var jwtToken = usersService.LoginAdmin(payload);

            return Ok(new { token = jwtToken });
        }
    }
}
