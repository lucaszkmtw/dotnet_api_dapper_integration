# API PROJECT

## Install NUGGETS

```bash
Update-Package -reinstall -ProjectName 

```

## ADD CONNECTION STRING

```bash
Use the appsettings to make the connection to the dataBase  


"ConnectionStrings": {
    "OracleConnection": "{HERE GOES THE DATA}"
  }
```

## Steps- Based on layer models (CONTROLLER - BUSINESSLOGIC - DATAACESS)
- make sure to make your owns mapping , on first you need to add an id, the table and schema to have access to the DataAccess 


``` EXAMPLE OF MAPPING 
using DataAccess.CustomAttributes;
using DataAccess.Mapper;

namespace DataAccess.Mapping {

    public class Actividad: ClassMap<Actividad>
    {
        public virtual long Id { get; set; }
        public virtual string DDescripcion { get; set; }
        public virtual DateTime FechaAlta { get; set; }
        public virtual string Usuario { get; set; }
        public virtual DateTime FechaActualizacion { get; set; }
        public virtual string Url { get; set; }
        public virtual string DDestinoGdeba { get; set; }
        public virtual bool mPaseGdeba { get; set; }
        public virtual int idWorkflow { get; set; }
        public virtual bool mActivo { get; set; }

        public Actividad()
        {
            Table("WF_ACTIVIDAD");
            Schema("WF");
            Id(x => x.Id, "C_ID", "WF_ACTIVIDAD_SQ");
            Map(x => x.DDescripcion, "D_DESCRIPCION");
            Map(x => x.FechaAlta, "FH_ALTA");
            Map(x => x.Usuario, "C_USUARIO");
            Map(x => x.FechaActualizacion, "FHU_ACTUALIZ");
            Map(x => x.Url, "URL_PANTALLA");
            Map(x => x.DDestinoGdeba, "D_DESTINO_GDEBA");
            Map(x => x.mPaseGdeba, "M_PASE_GDEBA");
            Map(x => x.idWorkflow, "C_ID_WORKFLOW");
            Map(x => x.mActivo, "M_ACTIVO");

        }
    }
}


## BusinnesLogic

``` Create your own services , to request the data from data Base
``` Example of LoginService
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

## Controller

``` example of creating a controller,  it's based in every structure of API IN .NET see documentation
``` https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-8.0&tabs=visual-studio

Create your own controller
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


## Make Querys with the orm 
``` Examples - aclaration you need to add the IRepositoryAccess in all your services.
like this :
 public class TestService
    {
        
        private readonly IRepositoryAccess repo;
        protected API_SIEP.ORM.DataAccess service = API_SIEP.ORM.DataAccess.Instance;
}


``` Query Examples - adding The actividad Mapping as Example
-Get All the element in a table
  List<Actividad> documentos = service.GetAll<Actividad>(repo).ToList();

-Searching By Id
  Actividad documentos = service.GetById<Actividad>({some_id}, repo).ToList();

-Example of searchin with a value in a register of database
  Search search = new Search(typeof(Actividad));
                search.AddAlias(new KeyValuePair<string, object>("{D_DESCRIPCION}", "{description}" ));

                DocumentoLiquidacion documentoInfo = service.GetBySearch<Actividad>(search, repo).FirstOrDefault();


