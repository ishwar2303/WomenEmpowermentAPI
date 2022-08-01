using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WomenEmpowerment.Models;

namespace WomenEmpowermentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NgoApplicationController : ControllerBase
    {
        WomenEmpowermentContext db = new WomenEmpowermentContext();

        //for updating the NgoApplication Status after approval from admin
        //doubt:-how can we update action date as that will be passed by admin

        [HttpGet]
        [Route("Request/{ngoId}")]
        public IActionResult PostNgoStatusUpdate(int ngoId)
        {
            // retrieve traineeId from session

            NgoApplication application = new NgoApplication();
            application.RequestDate = DateTime.Now;
            application.Status = 0;
            application.NgoId = ngoId;
            string error = "";
            bool valid = true;

            try
            {
                var data = db.NgoApplications.ToList();
                NgoApplication oldApplication = (from app in data where app.NgoId == ngoId select app).FirstOrDefault();
                if (oldApplication != null)
                {
                    return BadRequest(new { error = "Application already requested" });
                }
                else
                {
                    var ngoDetails = db.NgoDetails.ToList();
                    NgoDetail ngoDetail = (from d in ngoDetails where d.NgoId == ngoId select d).FirstOrDefault();

                    if (ngoDetail == null)
                    {
                        error = "Fill Organization Details";
                        valid = false;
                    }

                    var contactDetails = db.NgoContactDetails.ToList();
                    NgoContactDetail ngoContactDetail = (from d in contactDetails where d.NgoId== ngoId select d).FirstOrDefault();

                    if (ngoContactDetail == null)
                    {
                        if (!valid)
                            error += ", ";
                        error += "Fill Contact Details";
                        valid = false;
                    }

                    
                    if (valid)
                    {
                        // create application
                        db.NgoApplications.Add(application);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { error = "Something went wrong while creating application request", errorMessage = e.Message });
            }

            if (valid)
                return Ok(new { success = "NGO Application Requested Successfully", data = application });

            return BadRequest(new { error = error });

        }


        [HttpGet]
        [Route("Get/{ngoId}")]
        public IActionResult GetTraineeApplicationStatus(int ngoId)
        {
            NgoApplication application = new NgoApplication();
            try
            {
                var data = db.NgoApplications.ToList();
                application = (from d in data where d.NgoId == ngoId select d).FirstOrDefault();
                if (application == null)
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
