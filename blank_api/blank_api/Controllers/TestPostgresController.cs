﻿using BusinessLogic.ApiRequest;
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
        public IEnumerable<ActividadPostgres> Test()
        {
            return  _service.Prueba();

        }
      

    }
}
