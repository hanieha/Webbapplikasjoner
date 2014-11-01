using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Inlogging()
        {
            if ( Session["Innlogget"] == null )
            {
                Session["InnLogget"] = false;
                ViewBag.Innlogget = false;
            }
            return View();
        }
    }
}