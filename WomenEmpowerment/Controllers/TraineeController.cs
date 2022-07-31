using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WomenEmpowerment.Models;
using WomenEmpowerment.ViewModels;

namespace WomenEmpowerment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeController : ControllerBase
    {
        WomenEmpowermentContext db = new WomenEmpowermentContext();


        [HttpPost]
        [Route("Register")]
        public IActionResult PostTrainee(Trainee trainee)
        {
            db.Trainees.Add(trainee);
            int changes = db.SaveChanges();

            if (changes == 1)
                return Ok("Trainee registration successfull");
            else return BadRequest("Something went wrong while registration");

        }

        [HttpPost]
        [Route("Login")]
        public IActionResult PostLogin(TraineeLogin traineeLogin)
        {
            // if already logged in
            var traineeId = HttpContext.Session.GetInt32("TraineeId");
            if (traineeId != null)
            {
                
                return Ok(new {
                        FullName = HttpContext.Session.GetString("FullName"),
                        Username = HttpContext.Session.GetInt32("TraineeId")
                    }
                );
            }

            var data = db.Trainees.ToList();

            var trainee = (from t in data where t.Username == traineeLogin.Username && t.Password == traineeLogin.Password select t).FirstOrDefault();

            if (trainee == null)
                return Ok(new {
                   Error = "Username or Password is incorrect"
                });

            HttpContext.Session.SetInt32("TraineeId", trainee.TraineeId);
            HttpContext.Session.SetString("FullName", trainee.FullName);

            var loggedInTrainee = new
            {
                FullName = trainee.FullName,
                Username = trainee.Username
            };

            return Ok(loggedInTrainee);
        }

    }

}