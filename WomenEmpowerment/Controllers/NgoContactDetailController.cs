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
    public class NgoContactDetailController : ControllerBase
    {
        WomenEmpowermentContext db = new WomenEmpowermentContext();
        //for entering ngo contact details into the database

        [HttpPost]
        [Route("Add")]
        public IActionResult PostNgoContactDetails(NgoContactDetail ngocontactdetail)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.NgoContactDetails.Add(ngocontactdetail);
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                    return BadRequest(new { error = "Something went wrong while adding NGO contact details", exceptionMessage = e.Message });
                }
                return Ok(new { success = "Ngo Contact Details Added Successfully", data = ngocontactdetail});
            }
            return BadRequest(new { error = "Ngo contact details required" });
        }

        //for getting ngo contact details
        [HttpGet]
        [Route("NgoContactDetails/{id}")]

        public IActionResult GetNgoContactDetails(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id Cannot be Null");
            }
            else
            {
                try
                {
                    var data = from ngocd in db.NgoContactDetails where ngocd.NgoId == id select new { NgoId = ngocd.NgoId, State = ngocd.State, City = ngocd.City, District = ngocd.District, PIN = ngocd.Pin, Address = ngocd.Address, ContactNumber = ngocd.ContactNo };
                    if (data == null)
                    {
                        return BadRequest($"Data Not available for Id {id}");
                    }
                    return Ok(data);


                }
                catch (Exception)
                {

                    return BadRequest("Something error occured");
                }
            }
            //return BadRequest("Invalid Data");
        }

        //for editing the ngo contact details

        [HttpPut]
        [Route("NgoContactDetails/{id}")]

        public IActionResult PostNgoContactDetails(int? id, NgoContactDetail ngocontactdetail)
        {
            if (id == null)
            {
                return BadRequest("Id cannot be Null");
            }

            try
            {
                NgoContactDetail ncd = db.NgoContactDetails.Find(id);
                if (ncd == null)
                {
                    return BadRequest("NgoId not available");
                }
                ncd.State = ngocontactdetail.State;
                ncd.City = ngocontactdetail.City;
                ncd.District = ngocontactdetail.District;
                ncd.Pin = ngocontactdetail.Pin;
                ncd.Address = ngocontactdetail.Address;
                ncd.ContactNo = ngocontactdetail.ContactNo;
                db.SaveChanges();
                return Ok("Successfully updated");
            }
            catch (Exception)
            {

                return BadRequest("Something gone wrong");
            }
        }
    }
}
