using JwtAuth;
using JwtAuth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthenticateWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtAuthHandeler _jwtAuthHandeler;
        public AccountController(JwtAuthHandeler jwtAuthHandeler)
        {
            _jwtAuthHandeler = jwtAuthHandeler;
        }
        [HttpPost]
        public  ActionResult<AuthenticationResponse> Authenticate([FromBody]AuthenticationRequest request)
        {
            var authencationResponse = _jwtAuthHandeler.GetToken(request);
            if (authencationResponse == null)
            {
                return Unauthorized();

            }
            return authencationResponse;
        }
    }
}
