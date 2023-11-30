using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using sample_crud_base.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace sample_crud_base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration configuration)
        {
            _config = configuration;
            
        }

        private Users AuthenticateUser(Users user)
        {
            Users? _user = null;
            if(user.Username == "admin" && user.Password =="12345")
            {
                _user = new Users { Username = "Manoj Deshwal" };
            }
            return user;
         }


        private string  GenerateTokens(Users user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? ""));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt: Issuer"], _config["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login (Users user)
        {
            IActionResult response = Unauthorized();
            var user_ = AuthenticateUser(user);
            if(user_ != null)
            {
                var token = GenerateTokens(user_);
                response = Ok (new {token=token});
            }

            return response;
        }
    }
}
