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
    public class AdminController : ControllerBase
    {

        WomenEmpowermentContext db = new WomenEmpowermentContext();

        //for adding username and password into the database
        [HttpPost]
        [Route("Register")]
        public IActionResult PostRegisterNgo(Admin admin)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Admins.Add(admin);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return BadRequest(new { error = "Something went wrong while registration", exceptionMessage = e.Message });
                }
            }
            return Ok(new { success = "Admin Registration Successfull", data = admin });
        }

        //for login into the Admin Portal
        [HttpPost]
        [Route("Login")]
        public IActionResult PostLoginNgo(Admin adminLogin)
        {
            var data = db.Admins.ToList();

            var admin = (from n in data where n.Username == adminLogin.Username && n.Password == adminLogin.Password select n).FirstOrDefault();

            if (admin == null)
                return BadRequest(new { error = "Username or Password is incorrect" });

            var loggedInAdmin = new
            {
                Username = admin.Username,
                AdminId = admin.AdminId
            };

            return Ok(new { success = "Trainee Logged In Successfully", data = loggedInAdmin });

        }

    }
}