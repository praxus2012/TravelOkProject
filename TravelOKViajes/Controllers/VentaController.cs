using CapaDatos;
using CapaModelo;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOKViajes.Controllers
{
    public class VentaController : Controller
    {
        // GET: Venta

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InicialVenta(cmVentaDet detVenta)
        {
            /*if (Session["Activo"] == null)
            {
                RedirectToAction("Index", "Login");
            }
            return View();*/
            /*return RedirectToAction("SeleccionVenta");*/
            var resultado = new JObject();            
            resultado["Exito"] = true;
            return Content(resultado.ToString());
        }

        public ActionResult DetalleVenta()
        {
            return View();
        }
        public ActionResult SeleccionVenta()
        {
            /*if (Session["Activo"] == null)
            {
                RedirectToAction("Index", "Login");
            }
            return View();*/
            return View();/*
            var resultado = new JObject();            
            resultado["Exito"] = true;
            return Content(resultado.ToString());*/
        }

        // GET: Venta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Venta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Venta/Create
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

        // GET: Venta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Venta/Edit/5
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

        // GET: Venta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Venta/Delete/5
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
