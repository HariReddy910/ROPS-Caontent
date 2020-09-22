using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantPOS.Controllers
{
    public class FrontOfficeController : Controller
    {
        // GET: FrontOffice
        public ActionResult FrontOffice()
        {
            return View();
        }
        public ActionResult WorkPeriod()
        {
            return View();
        }
        public ActionResult POS()
        {
            return View();
        }
        public ActionResult Tickets()
        {
            return View();
        }
        public ActionResult WorkPeriodReport()
        {
            return View();
        }
        public ActionResult POSReport()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
    }
}