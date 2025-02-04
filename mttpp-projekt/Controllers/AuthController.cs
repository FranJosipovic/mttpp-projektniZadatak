using Microsoft.AspNetCore.Mvc;

namespace mttpp_projekt.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtHandler _jwtHandler;

        public AuthController(JwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }

        [HttpPost]
        public IActionResult Auth()
        {
            var accessToken = _jwtHandler.GenerateToken();
            return new JsonResult(new AuthResponse { AccessToken = accessToken });
        }
    }
}
