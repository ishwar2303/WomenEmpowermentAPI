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
    public class AdminController : ControllerBase
    {
        WomenEmpowermentContext db = new WomenEmpowermentContext();

        //for adding admindata into the database
        [HttpPost]
        [Route("AddAdmin")]
        public IActionResult PostAddAdmin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Admins.Add(admin);
                    db.SaveChanges();
                    return Ok("Admin Added Successfully");
                }
                catch (Exception)
                {

                    return BadRequest("Something went wrong");
                }
            }
            return BadRequest("Inavlid username or password");
        }

        [HttpPost]
        [Route("AdminLogin")]
        public IActionResult GetAdminLogin(Admin admin)
        {
            if(ModelState.IsValid)
            {

                try
                {
                    string username = admin.Username;
                    string password = admin.Password;
                    var data = (from admindata in db.Admins where admindata.Username == username && admindata.Password == password select new { AdminId = admindata.AdminId }).FirstOrDefault();
                    if (data != null)
                        return Ok("AdminLogin Successfull");
                    else
                        return BadRequest("username or password does not exist");
                }
                catch (Exception)
                {

                    return BadRequest("Something Went Wrong");
                }
            }
            return BadRequest("invalid username or password");
        }
    }
}
