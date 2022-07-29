using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WomenEmpowerment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLogin()
        {
            string id = "10709385";
            HttpContext.Session.SetString("EmployeeId", id);
            return Ok("Id fetched from database and set in session " + id);
        }

        
    }
}