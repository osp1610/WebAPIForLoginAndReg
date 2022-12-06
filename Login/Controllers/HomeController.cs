using Login.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult OwnerLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> OwnerLogin(ownerLogin ol)
        {
            using (var httpClient = new HttpClient())
            {
               
                JsonContent content = JsonContent.Create(ol);

                using (var apiResponse = await httpClient.PostAsync("https://localhost:44311/api/OwnerAPI/Ownerlogin", content))
                
                {
                   if(apiResponse.StatusCode==System.Net.HttpStatusCode.OK) {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("OwnerLogin");
                    }
                }
            }
        }

        public ActionResult UserLogin()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> UserLogin(userLogin ul)
        {
            using (var httpClient = new HttpClient())
            {

                JsonContent content = JsonContent.Create(ul);

                using (var apiResponse = await httpClient.PostAsync("https://localhost:44311/api/OwnerAPI/Userlogin", content))
                {
                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("UserLogin");
                    }
                }
            }
        }
    }
}