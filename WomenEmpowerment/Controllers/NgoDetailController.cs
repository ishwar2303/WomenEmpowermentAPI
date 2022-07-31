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
    public class NgoDetailController : ControllerBase
    {
        WomenEmpowermentContext db = new WomenEmpowermentContext();
        //for adding the details about the ngo
        [HttpPost]
        [Route("AddDetails")]
        public IActionResult PostDetails(NgoDetail ngoDetail)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.NgoDetails.Add(ngoDetail);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return BadRequest("Something went wrong while adding NGO details");
                }
            }
            return Created("Record successfully added", ngoDetail);
        }
        //for editing the details about the ngo
        [HttpPut]
        [Route("EditDetails/{id}")]
        public IActionResult PutDetails(int id, NgoDetail ngoDetail)
        {
            if (ModelState.IsValid)
            {
                var oldNgoDetail = db.NgoDetails.Find(id);
                oldNgoDetail.OrganisationName = ngoDetail.OrganisationName;
                oldNgoDetail.ChairmanName = ngoDetail.ChairmanName;
                oldNgoDetail.Pan = ngoDetail.Pan;
                oldNgoDetail.SecretaryName = ngoDetail.SecretaryName;
                oldNgoDetail.Website = ngoDetail.Website;
                db.SaveChanges();
                return Ok("NGO details successfully updated");
            }
            return BadRequest("Unable to edit NGO details");
        }
        //for getting the NgoDetails

        [HttpGet]
        [Route("NgoDetails/{id}")]
        public IActionResult GetNgoDetails(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("Id cannot be null");
                }
                var data = db.NgoDetails.Find(id);
                if (data == null)
                {
                    return BadRequest($"NgoDetails Not available for id {id}");
                }
                else
                    return Ok(data);
            }
            catch (Exception)
            {

                return BadRequest("Something went wrong");
            }
        }

        //for deleting the ngo details
        [HttpDelete]
        [Route("DeleteNgo/{id}")]
        public IActionResult DeleteNgo(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id cannot be null");
            }
            else
            {
                try
                {
                    var data = db.Ngos.Find(id);
                    if (data == null)
                    {
                        return BadRequest($"Ngo with id {id} not present");
                    }
                    else
                    {
                        db.Ngos.Remove(data);
                        db.SaveChanges();
                        return Ok("Deleted Successfully");
                    }

                }
                catch (Exception)
                {

                    return BadRequest("Something went wrong");
                }
            }
        }
    }
}
