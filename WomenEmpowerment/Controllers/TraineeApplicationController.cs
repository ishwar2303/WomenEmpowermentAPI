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

        [HttpPost]
        [Route("Request")]
        public IActionResult PostTraineeApplicationRequest()
        {
            TraineeApplication application = new TraineeApplication();
            application.RequestDate = DateTime.Now;
            application.Status = 0;
            application.TraineeId = 1; // retrieve from session

            try
            {
                db.TraineeApplications.Add(application);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(application);
        }
    }
}