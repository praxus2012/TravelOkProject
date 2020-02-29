using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOkAdmin.Controllers
{
    public class VentasController : Controller
    {
        // GET: Ventas
        public ActionResult Index()
        {
            if (Session["Usuario"] != null)
                return View();
            else
                return RedirectToAction("Login", "Index");
        }
    }
}