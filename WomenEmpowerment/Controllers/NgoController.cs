using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WomenEmpowermentAPI.models;

namespace WomenEmpowermentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NgoController : ControllerBase
    {
        WomenEmpowermentContext db = new WomenEmpowermentContext();
        //for adding username and password into the database
        [HttpPost]
        [Route("AddNgo")]
        public IActionResult PostAddNgo(Ngo ngo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Ngos.Add(ngo);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    return BadRequest("Something went wrong");
                }
            }
            return Created("Username and Password Registered Successfully",ngo);

        }

        //for login into the NGO Portal
        [HttpPost]
        [Route("LoginNgo")]
        public IActionResult PostLoginNgo(Ngo ngo)
        {
            string username = ngo.Username;
            string password = ngo.Password;
            if (ngo == null)
            {
                return BadRequest("UserId Or Password cannot be null");
            }
            var data = (from ngodata in db.Ngos where ngodata.Username ==username && ngodata.Password==password select new { NgoID=ngodata.NgoId}).FirstOrDefault();

            
            if (data == null)
            {
                return NotFound($"Username or Password not present");
            }
            else
            return Ok("Successfully LogedIn");

        }



      

        //------------------------------------------------------------------------------------------
        //==========================================================================================
      

    }
}
