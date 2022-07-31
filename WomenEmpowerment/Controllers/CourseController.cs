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
    public class CourseController : ControllerBase
    {

        WomenEmpowermentContext db = new WomenEmpowermentContext();

        [HttpGet]
        [Route("Courses")]
        public IActionResult GetCourses()
        {
            HttpContext.Session.SetString("Something", "Great");

            var courses = new List<Course>();
            try
            {
                courses = db.Courses.ToList();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(courses);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult PostCourse(Course course)
        {
            try
            {
                db.Courses.Add(course);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                return BadRequest(new { error = "Something went wrong while adding course", errorMessage = e.Message });
            }

            return Ok(new { success = "Course Added Successfully", data = course });
        }
    }
}