 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class homController : Controller
    {
        // GET: hom
        public ActionResult Index()
        {
            ViewData["countries"] = new List<string>()
            {
                "india",
                "usa",
                "jordan",
                "ksa",
            };
            return View();
        }
    }
}