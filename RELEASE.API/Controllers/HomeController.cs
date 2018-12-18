using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RELEASE.API.Models.dbentities;
using System.Web.Http;
using System.Web.Mvc;

namespace RELEASE.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

       

        
    }

   
}
