using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WomenEmpowerment.Models;

namespace WomenEmpowerment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        WomenEmpowermentContext db = new WomenEmpowermentContext();

        [HttpGet]
        public IActionResult GetHome()
        {
            string EmployeeId = HttpContext.Session.GetString("EmployeeId");
            if (EmployeeId == null)
                return BadRequest("Please login");

            var data = new {
                Name = "Ishwar",
                Email = "ishwar2303@gmail.com",
                EmployeeId = EmployeeId
            };

            return Ok(data);
        }

    }
}