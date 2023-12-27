using BusinessLogic.ApiRequest;
using BussinessLogic.API_Pagos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Pagos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class _LoginController : ControllerBase
    {
        private readonly LoginService _service;
        private readonly IConfiguration _config;

        public _LoginController(LoginService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> Login(RequestUsuario usuario)
        {
            bool CheckPassword = await _service.VerifyPassword(usuario);
            if (!_config.GetSection("AllowedApplicattions").Get<string[]>().Contains(usuario.Aplicacion)) {return BadRequest(new { message = "Credenciales invalidas" });}
            if (CheckPassword is false) return BadRequest(new { message = "Credenciales invalidas" });

            // Generar token
            string jwt = GenerarToken(usuario);
            
            return Ok(new { token = jwt });

        }



        private string GenerarToken(RequestUsuario usuario)
        {
            var claims = new[]
            {

                new Claim("Aplicacion", usuario.Aplicacion),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JWT:Key").Value));
            var session = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: session
            );

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }

    }
}
