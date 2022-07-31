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
    public class NgoApplicationController : ControllerBase
    {
        WomenEmpowermentContext db = new WomenEmpowermentContext();

        //for updating the NgoApplication Status after approval from admin
        //doubt:-how can we update action date as that will be passed by admin
        [HttpPost]
        [Route("NgoStatusUpdate")]
        public IActionResult PostNgoStatusUpdate(NgoApplication ngoapplication)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.NgoApplications.Add(ngoapplication);
                    db.SaveChanges();

                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }
                return Ok(ngoapplication);
            }
            return BadRequest("Invalid Entered Data");
        }



        //for getting the ngo status
        [HttpGet]
        [Route("NgoStatus/{id}")]
        public IActionResult GetNgoStatus(int? id)
        {
            if (id == null)
            {
                return BadRequest("NgoId cannot be null");
            }
            var data = (from ngodata in db.NgoApplications where ngodata.NgoId == id select new { NgoId = ngodata.NgoId, RequestDate = ngodata.RequestDate, Status = ngodata.Status, ActionDate = ngodata.ActionDate }).FirstOrDefault();

            if (data == null)
            {
                return NotFound($"NGOID {id} not present");
            }
            return Ok(data);
        }
    }
}
