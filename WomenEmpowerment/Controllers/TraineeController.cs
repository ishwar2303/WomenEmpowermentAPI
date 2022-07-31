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
            string errorMessage = "";
            
            try
            {
                if(trainee != null)
                {
                    trainee.Username = trainee.Username.ToLower();
                    string username = trainee.Username;

                    var data = db.Trainees.ToList();
                    var traineeExists = (from d in data where d.Username == username select d).FirstOrDefault();

                    if(traineeExists != null)
                    {
                        errorMessage = "Username already registered";
                        return BadRequest(new { error = errorMessage });
                    }
                    else
                    {
                        // Register New Trainee
                        db.Trainees.Add(trainee);
                        db.SaveChanges();
                    }

                }
            }
            catch(Exception e)
            {
                return BadRequest(new { error = "Something went wrong while registration", exceptionMessage = e.Message });
            }
            return Ok(new { success = "Trainee registration successfull", data = trainee });

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