using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week11_G4_API.Data;
using Week11_G4_API.Models;
using Microsoft.AspNetCore.Authorization;

namespace Week11_G4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtAuthenticationManager _jwtAuthenticationManager;

        public AuthenticationController(JwtAuthenticationManager manager)
        {
            _jwtAuthenticationManager = manager;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            string token = _jwtAuthenticationManager.Authenticate(user.username, user.password);

            if (token == "")
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }

    public class User
    {
        public string? username { get; set; }
        public string? password { get; set; }
    }
}