using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WomenEmpowerment.Models;

namespace WomenEmpowerment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeNgoCourseController : ControllerBase
    {
        WomenEmpowermentContext db = new WomenEmpowermentContext();

        [HttpPost]
        [Route("Add")]
        public IActionResult PostNgoCourseDetail(TraineeNgoCourse ngoCourse)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.TraineeNgoCourses.Add(ngoCourse);
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
        [Route("Delete/{id}")]
        public IActionResult DeleteNgoCourse(int id)
        {
            var data = db.TraineeNgoCourses.Find(id);
            db.TraineeNgoCourses.Remove(data);
            db.SaveChanges();
            return Ok("Record Deleted");
        }
    }
}
