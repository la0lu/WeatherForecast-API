using APICLass.Services;
using Microsoft.AspNetCore.Mvc;

namespace APICLass.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthServices _authServices;
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpGet("get-token")]
        public IActionResult GetToken()
        {
            var token = _authServices.GenerateJWT();

            return Ok(token);
        }
    }
}
