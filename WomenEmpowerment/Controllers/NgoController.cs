using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WomenEmpowerment.Models;

namespace WomenEmpowermentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NgoController : ControllerBase
    {
        WomenEmpowermentContext db = new WomenEmpowermentContext();
        //for adding username and password into the database
        [HttpPost]
        [Route("Register")]
        public IActionResult PostRegisterNgo(Ngo ngo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Ngos.Add(ngo);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return BadRequest(new { error = "Something went wrong while registration", exceptionMessage = e.Message });
                }
            }
            return Ok(new { success = "NGO registration successfull", data = ngo });
        }

        //for login into the NGO Portal
        [HttpPost]
        [Route("Login")]
        public IActionResult PostLoginNgo(Ngo ngoLogin)
        {
            var data = db.Ngos.ToList();

            var ngo = (from n in data where n.Username == ngoLogin.Username && n.Password == ngoLogin.Password select n).FirstOrDefault();

            if (ngo == null)
                return BadRequest(new { error = "Username or Password is incorrect" });

            var loggedInNgo = new
            {
                Username = ngo.Username,
                NgoId = ngo.NgoId
            };

            return Ok(new { success = "NGO Logged In Successfully", data = loggedInNgo });

        }

    }
}
