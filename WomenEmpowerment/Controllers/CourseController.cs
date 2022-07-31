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

            var courses = new List<Course>();
            try
            {
                courses = db.Courses.ToList();
            }
            catch (Exception e)
            {
                return BadRequest(new { error = "Something went wrong while fetching courses", errorMessage = e.Message});
            }
            return Ok(new { success = "Courses fetched successfully", data = courses});
        }

        [HttpGet]
        [Route("Courses/{courseId}")]
        public IActionResult GetCourse(int courseId)
        {
            string error = "";
            Course course = null;
            try
            {
                course = db.Courses.Find(courseId);
                if (course == null)
                    error = "No course exist with this course id";
            }
            catch(Exception e)
            {
                return BadRequest(new { error = "Something went wrong while adding course", errorMessage = e.Message });

            }
            return Ok(new { success = "Course Fetched Successfully", data = course });
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult PutCourse(Course newCourse)
        {
            string error = "";
            Course oldCourse = null;
            try
            {
                oldCourse = db.Courses.Find(newCourse.CourseId);
                if (oldCourse == null)
                    error = "No course exist with this course id";
                else
                {
                    oldCourse.Code = newCourse.Code;
                    oldCourse.Description = newCourse.Description;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { error = "Something went wrong while updating course", errorMessage = e.Message });

            }
            return Ok(new { success = "Course Updated Successfully", data = newCourse });
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

        [HttpDelete]
        [Route("Delete/{courseId}")]
        public IActionResult DeleteCourse(int courseId)
        {
            Console.WriteLine("Course Id for deletion: " + courseId);
            string error = "";
            Course course = null;
            try
            {
                course = db.Courses.Find(courseId);
                if(course != null)
                {
                    db.Courses.Remove(course);
                    db.SaveChanges();
                }
                else
                {
                    error = "No course exist with this course id";
                    return BadRequest(new { error = error });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { error = "Something went wrong while deleting course", errorMessage = e.Message });
            }

            return Ok(new { success = "Course Deleted Successfully", data = course });
        }
    }
}