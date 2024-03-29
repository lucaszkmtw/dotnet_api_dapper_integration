﻿using BusinessLogic.ApiRequest;
using BusinessLogic.ApiResponse;
using BusinessLogic.DTO;
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
    public class TestController : ControllerBase
    {
        //WE GET THE TEST SERVICE WITH INDEPENDENCY INJECTION 
        //TESTSERVICE MAKE REFER TO ALL THE FUNCTION THAT ARE IN THE MIDDLE OF THE COMUNNINCATION WITH DATABASE (BUSINNES LOGIC)
        private readonly TestService _service;
        private readonly IConfiguration _config;

        public TestController(TestService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }


        // here use the access to database with the business logic files, look that we use DTO's /(data transfer object for more adaptability)
        [HttpGet("Actividad")]
        public List<ActividadDTO> Actividades()
        {
           return _service.GetAllActividades();   

        }
        [HttpGet("Actividad/{id:long}")]
        public ActividadDTO GetById(long id)
        {
            return _service.GetById(id);

        }
        [HttpGet("Actividad/{usuario}")]
        public List<ActividadDTO> GetBySearch(string usuario)
        {
            return _service.GetByElement(usuario);

        }


    }
}
