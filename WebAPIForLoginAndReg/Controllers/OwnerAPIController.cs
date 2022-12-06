using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebAPIForLoginAndReg.Models;
using WebAPIForLoginAndReg.Models.AuthModel;

namespace WebAPIForLoginAndReg.Controllers
{

    public class OwnerAPIController : ApiController
    {
        private HotelManagementSystemEntities _hotelManagementSystemEntities = new HotelManagementSystemEntities();
        //Owner Registartion API

        //public async Task<IHttpActionResult> OwnerRegistrationAPI(ownerRegistration or)
        //{
        //    if (_hotelManagementSystemEntities.OwnerRegistrations.Where(m => m.EmailId == or.emailId).FirstOrDefault() != null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        _hotelManagementSystemEntities.OwnerRegistrations.Add(new OwnerRegistration()
        //        {
        //            OwnerName = or.ownerName,
        //            HotelRegistrationNumber = or.hotelRegistrationNumber,
        //            EmailId = or.emailId,
        //            ContactNumber = or.contactNumber,
        //            HotelName = or.hotelName,
        //            HotelAddress = or.hotelAddress,
        //            HotelCity = or.hotelCity,
        //            Password = or.password,
        //            VerifiedStatus = false
        //        });
        //       await _hotelManagementSystemEntities.SaveChangesAsync();
        //        return Ok();
        //    }            

        //}



        //API for Owner Login
        public async Task<IHttpActionResult> Ownerlogin(ownerLogin ol)
        {
            if (_hotelManagementSystemEntities.OwnerRegistrations.Where(m => m.EmailId == ol.emailID).FirstOrDefault() != null)
            {
                var pwd = _hotelManagementSystemEntities.OwnerRegistrations.Where(m => m.Password == ol.password).FirstOrDefault();
                if (pwd != null)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }

            else
            {
                return Unauthorized();
            }
        }


        //User Registartion API
        //public async Task<IHttpActionResult> UserRegistrationAPI(userRegistration ur)
        //{
        //    if (_hotelManagementSystemEntities.UserRegistrations.Where(m => m.EmailId == ur.emailId).FirstOrDefault() != null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        _hotelManagementSystemEntities.UserRegistrations.Add(new UserRegistration()
        //        {
        //            UserName = ur.userName,
        //            EmailId = ur.emailId,
        //            ContactNo = ur.contactNo,
        //            Address = ur.address,
        //            Password = ur.password,
        //        });
        //        await _hotelManagementSystemEntities.SaveChangesAsync();
        //        return Ok();
        //    }
        //}



        //User Login API
        public async Task<IHttpActionResult> Userlogin([FromBody] userLogin ul)
        {
            if (_hotelManagementSystemEntities.UserRegistrations.Where(m => m.EmailId == ul.emailId).FirstOrDefault() != null)
            {
                var pwd = _hotelManagementSystemEntities.UserRegistrations.Where(m => m.Password == ul.password).FirstOrDefault();
                if (pwd != null)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }

            else
            {
                return Unauthorized();
            }
        }
    }
}
