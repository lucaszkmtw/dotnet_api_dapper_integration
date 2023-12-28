using BusinessLogic.ApiRequest;
using BusinessLogic.ApiResponse;
using BusinessLogic.DTO;
using BussinessLogic.API_Pagos.Services;
using DataAccess.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Pagos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestSqlServerController : ControllerBase
    {
        //WE GET THE TEST SERVICE WITH INDEPENDENCY INJECTION 
        //TESTSERVICE MAKE REFER TO ALL THE FUNCTION THAT ARE IN THE MIDDLE OF THE COMUNNINCATION WITH DATABASE (BUSINNES LOGIC)
        private readonly TestService _service;
        private readonly IConfiguration _config;

        public TestSqlServerController(TestService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }




        [HttpGet("Actividad/")]
        public IEnumerable<ActividadServer> Test()
        {
            return _service.ActividadSqlServer();

        }
        [HttpGet("Actividad/{id:long}")]
        public ActividadDTO GetById(long id)
        {
            return _service.GetByIdSqlServer(id);

        }
        [HttpGet("Actividad/{usuario}")]
        public List<ActividadDTO> GetBySearch(string usuario)
        {
            return _service.GetByElementSqlServer(usuario);

        }

        [HttpPost("AddActividad")]
        public IActionResult Insert(ActividadServer actividad)
        {
            try
            {
                _service.InsertSqlServer(actividad);
                return Ok(actividad);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
        [HttpPost("UpdateActividad")]
        public void Update(ActividadServer actividad)
        {
            _service.UpdateSqlServer(actividad);

        }
        [HttpPost("DeleteActividad")]
        public void Delete(long id)
        {
            _service.DeleteActividadServer(id);

        }

    }
}
