using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIForLoginAndReg.Models
{
    public class userRegistration
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string contactNo { get; set; }
        public string address { get; set; }
        public string emailId { get; set; }
        public string password { get; set; }
    }

    public class userLogin
    {
        public string emailId { get; set; }
        public string password { get; set; }
    }
}