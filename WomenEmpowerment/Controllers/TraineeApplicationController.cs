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
    public class TraineeApplicationController : ControllerBase
    {
        WomenEmpowermentContext db = new WomenEmpowermentContext();

        [HttpGet]
        [Route("Request/{traineeId}")]
        public IActionResult PostTraineeApplicationRequest(int traineeId)
        {
             // retrieve traineeId from session

            TraineeApplication application = new TraineeApplication();
            application.RequestDate = DateTime.Now;
            application.Status = 0;
            application.TraineeId = traineeId;
            string error = "";
            bool valid = true;

            try
            {
                var data = db.TraineeApplications.ToList();
                TraineeApplication oldApplication = (from app in data where app.TraineeId == traineeId select app).FirstOrDefault();
                if(oldApplication != null)
                {
                    return BadRequest(new { error = "Application already requested" });
                }
                else
                {
                    var personalDetails = db.TraineePersonalDetails.ToList();
                    TraineePersonalDetail traineePersonalDetail = (from d in personalDetails where d.TraineeId == traineeId select d).FirstOrDefault();

                    if (traineePersonalDetail == null)
                    {
                        error = "Fill Personal Details";
                        valid = false;
                    }

                    var familyDetails = db.TraineeFamilyDetails.ToList();
                    TraineeFamilyDetail traineeFamilyDetail = (from d in familyDetails where d.TraineeId == traineeId select d).FirstOrDefault();

                    if (traineeFamilyDetail == null)
                    {
                        if (!valid)
                            error += ", ";
                        error += "Fill Family Details";
                        valid = false;
                    }

                    var addressDetails = db.TraineeAddressDetails.ToList();
                    TraineeAddressDetail traineeAddressDetail = (from d in addressDetails where d.TraineeId == traineeId select d).FirstOrDefault();

                    if (traineeAddressDetail == null)
                    {
                        if (!valid)
                            error += ", ";
                        error += "Fill Address Details";
                        valid = false;
                    }
                    if (valid)
                    {
                        // create application
                        db.TraineeApplications.Add(application);
                        db.SaveChanges();
                    }
                }
            }
            catch(Exception e)
            {
                return BadRequest(new { error = "Something went wrong while creating application request", errorMessage = e.Message });
            }

            if(valid)
                return Ok(new { success = "Trainee Application Requested Successfully", data = application });

            return BadRequest(new { error = error });
        }

        [HttpGet]
        [Route("Get/{traineeId}")]
        public IActionResult GetTraineeApplicationStatus(int traineeId)
        {
            TraineeApplication application = new TraineeApplication();
            try
            {
                var data = db.TraineeApplications.ToList();
                application = (from d in data where d.TraineeId == traineeId select d).FirstOrDefault();
                if(application == null)
                    return BadRequest(new { error = "Application not requested yet" });
            }
            catch (Exception e)
            {
                return BadRequest(new { error = "Something went wrong while fetching application request", errorMessage = e.Message });
            }

            return Ok(new { success = "Trainee Application Fetched Successfully", data = application });
        }
    }
}