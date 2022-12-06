using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;



namespace WebAPIForLoginAndReg.Models
{
    public class ownerRegistration
    {
        public int hotelRegistrationNumber { get; set; }
        public string ownerName { get; set; }
        public string contactNumber { get; set; }
        public string hotelName { get; set; }
        public string hotelCity { get; set; }
        public string hotelAddress { get; set; }
        public string emailId { get; set; }
        public string password { get; set; }
        public bool verifiedStatus { get; set; }
    }

    public class ownerLogin
    {
        public string emailID { get; set; }
        public string password { get; set; }
    }
}