using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebAPIForLoginAndReg.Models;
using WebAPIForLoginAndReg.Models.AuthModel;
using System.Net.Http.Json;
using System.Runtime.Remoting.Contexts;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace WebAPIForLoginAndReg.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient _httpclient = new HttpClient();

        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult OwnerRegistrationPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> OwnerRegistration(ownerRegistration or)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _httpclient.BaseAddress = new Uri("https://localhost:44311/api/OwnerAPI");
                    var regOwner = _httpclient.PostAsJsonAsync<ownerRegistration>("OwnerAPI", or);
                    regOwner.Wait();
                    var saveRecord = regOwner.Result;
                    if (saveRecord.IsSuccessStatusCode)
                    {
                        return RedirectToAction("OwnerLogin");
                    }
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult OwnerLogin()
        { 
         return View();
        }


        [HttpPost]
        public async Task<ActionResult> OwnerLogin(ownerLogin ol)
        {
            var jsonconvert= JsonConvert.SerializeObject(ol);
            var content = new StringContent(jsonconvert, Encoding.UTF8, "application/json");
            var httpResponse = await _httpclient.PostAsync("https://localhost:44311/api/OwnerAPI/Ownerlogin", content);

            if (httpResponse.StatusCode==System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("Index");

                // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
            }


            return View();
        }

        
        public ActionResult UserRegistration()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UserRegistration(userRegistration ur)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _httpclient.BaseAddress = new Uri("https://localhost:44311/api/OwnerAPI");
                    var loginUser = _httpclient.PostAsJsonAsync<userRegistration>("OwnerAPI", ur);
                    loginUser.Wait();
                    var saveRecord = loginUser.Result;
                    if (saveRecord.IsSuccessStatusCode)
                    {
                        return RedirectToAction("UserLogin");
                    }
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult UserLogin()
        {

            return View();
        }
    
    }
}
