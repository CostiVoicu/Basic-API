using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Project.API.Controllers
{
    [ApiController]
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        protected int GetUserId()
        {
            var rawToken = HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            var token = rawToken.Substring("Bearer ".Length).Trim();
            var parsedToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            var userIdRaw = parsedToken.Claims.First(c => c.Type == "userId").Value;
            var userId = Int32.Parse(userIdRaw);

            return userId;
        }
    }
}
