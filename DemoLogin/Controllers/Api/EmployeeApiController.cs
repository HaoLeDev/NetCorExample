using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoLogin.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoLogin.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        //[Route("api/employee/getbyid/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(EmployeeBiz.GetById(id));
            }
            catch(Exception e)
            {
               return Ok(e.Message.ToString());
            }
        }
    }
}