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
    public class NgoCourseController : ControllerBase
    {
        WomenEmpowermentContext db = new WomenEmpowermentContext();
        [HttpPost]
        [Route("AddNgoCourse")]
        public IActionResult PostNgoCourseDetail(NgoCourse ngoCourse)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.NgoCourses.Add(ngoCourse);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    return BadRequest("Something went wrong");
                }
                return Created("Successfully updated", ngoCourse);
            }
            return BadRequest("Invalid data");
        }

        [HttpDelete]
        [Route("DeleteNgoCourse/{id}")]
        public IActionResult DeleteNgoCourse(int id)
        {
            var data = db.NgoCourses.Find(id);
            db.NgoCourses.Remove(data);
            db.SaveChanges();
            return Ok("Record Deleted");
        }
    }
}
