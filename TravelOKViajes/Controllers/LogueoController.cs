using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOKViajes.Controllers
{
    public class LogueoController : Controller
    {
        // GET: Logueo
        public ActionResult TravelInicio()
        {
            return View();
        }

        public ActionResult TravelRegistro()
        {
            return View();
        }

        // GET: Logueo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Logueo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logueo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Logueo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Logueo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Logueo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Logueo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
