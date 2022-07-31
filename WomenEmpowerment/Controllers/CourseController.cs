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
    public class CourseController : ControllerBase
    {
        WomenEmpowermentContext db = new WomenEmpowermentContext();

        //for adding the course details
        [HttpPost]
        [Route("AddCourse")]
        public IActionResult PostAddCourse(Course courses)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Courses.Add(courses);
                    db.SaveChanges();
                    return Created("Courses Added Successfully",courses);
                }
                catch (Exception)
                {

                    return BadRequest("Something went wrong");
                }
            }
            return BadRequest("Invalid entered data");
        }

        //for getting course details by courseid
        [HttpGet]
        [Route("Getdetails/{id}")]
        public IActionResult GetCourseDetails(int ?id)
        {
            if (id == null)
                return BadRequest("Id cannot be null");
            else
            {
                try
                {
                    var data = db.Courses.Find(id);
                    if (data == null)
                        return BadRequest($"Course Details for id {id} not available");
                    else
                        return Ok(data);
                }
                catch (Exception)
                {

                    return BadRequest("Something went wrong");
                }
            }
        }

        //for editing the course details
        [HttpPut]
        [Route("EditCourse/{id}")]
        public IActionResult PutEditCourse(int ?id,Course course)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var data = db.Courses.Find(id);
                    data.Code = course.Code;
                    data.Description = course.Description;
                    db.SaveChanges();
                    return Ok("Updated Sucessfully");

                }
                catch (Exception)
                {

                    return BadRequest("Something went wrong");
                }
            }
            return BadRequest("Invalid details");
        }

        //for deleting the course details

        [HttpDelete]
        [Route("DeleteCourse/{id}")]
        public IActionResult DeletedeleteCourse(int ?id)
        {
            if (id == null)
                return BadRequest("Id cannot be null");
            else
            {
                try
                {
                    var data = db.Courses.Find(id);
                    db.Courses.Remove(data);
                    db.SaveChanges();
                    return Ok("Deleted Successfully");
                }
                catch (Exception)
                {

                    return BadRequest("Something went wrong");
                }
            }
        }
    }
}
