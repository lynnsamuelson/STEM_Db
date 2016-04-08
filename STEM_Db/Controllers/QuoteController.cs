using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STEM_Db.Controllers
{
    public class QuoteController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Quote Page";

            return View();
        }
    }
}
