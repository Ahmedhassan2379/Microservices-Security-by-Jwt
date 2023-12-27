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
        public List<UserAcount> users { get; set; }
        public AccountController(JwtAuthHandeler jwtAuthHandeler)
        {
            _jwtAuthHandeler = jwtAuthHandeler;
        }
        [HttpPost]
        public  IActionResult Authenticate([FromBody]AuthenticationRequest request)
        {
            var user = users.FirstOrDefault(x=>x.UserName==request.Name &&x.Password==request.Password);
            if (user == null)
                return NotFound(new { message = "User Not Found" });

            var authencationResponse = _jwtAuthHandeler.GetToken(request);
            if (authencationResponse == null)
            {
                return Unauthorized();

            }
            return Ok(request);
        }

        [HttpPost]
        public IActionResult Register([FromBody] UserAcount request)
        {
            if (request == null)
                return NotFound("this user is not found");

            users.Add(request);
            return Ok(new {message="Registered Successfully"});
        }
    }
}
