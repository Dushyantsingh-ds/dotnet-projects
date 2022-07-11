using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartialView.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult view1()
        {
            return PartialView();
        }
        public PartialViewResult view2()
        {
            return PartialView();
        }
    }
}