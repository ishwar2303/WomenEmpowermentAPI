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
    public class TraineePersonalDetailsController : ControllerBase
    {
        WomenEmpowermentContext db = new WomenEmpowermentContext();

        [HttpPost]
        [Route("Add")]
        public IActionResult PostTraineePersonalDetails(TraineePersonalDetail personalDetails)
        {
            try
            {
                db.TraineePersonalDetails.Add(personalDetails);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest(new { error = "Something went wrong while adding personal details", errorMessage = e.Message});
            }

            return Ok(new { success = "Trainee Personal Details Added Successfully", data = personalDetails });
        }

        [HttpGet]
        [Route("Get/{traineeId}")]
        public IActionResult GetTraineePersonalDetails(int traineeId)
        {
            var personalDetails = new TraineePersonalDetail();
            try
            {
                var data = db.TraineePersonalDetails.ToList();
                personalDetails = (from d in data where d.TraineeId == traineeId select d).FirstOrDefault();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(personalDetails);
        }
    }
}