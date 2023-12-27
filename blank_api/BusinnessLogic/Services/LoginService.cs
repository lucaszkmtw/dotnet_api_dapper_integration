
using BusinessLogic.ApiRequest;
using BussinessLogic.API_Pagos.Data.Encrypt;
using Microsoft.Extensions.Configuration;

namespace BussinessLogic.API_Pagos.Services
{
    public class LoginService
    {
        private readonly IConfiguration _config;
        public LoginService(IConfiguration config) { 
            _config = config;           

        }

        public async Task<bool> VerifyPassword(RequestUsuario usuario)
        {

            string pass = _config.GetSection("KeyEncript:Key").Value;
            if (pass == usuario.Password )
            {
                return true;
            }
            else
            {
                return false;
            }
       


        }



    }
}
