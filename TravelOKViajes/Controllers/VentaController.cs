﻿using CapaDatos;
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
            if (Session["UserName"] == null)
            {
                return RedirectToAction("TravelInicio", "Logueo");
            }
            else
            {
                return View();
            }
        }
        public ActionResult SeleccionVenta()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("TravelInicio", "Logueo");
            }
            else
            {
                return View();
            }
        }

        public ActionResult InicioSelecVenta()
        {
            var resultado = new JObject();
            try
            {
                CD_SelecVen cdSelVen = new CD_SelecVen();
                List<cmCostos> lsDetDes = new List<cmCostos>();
                lsDetDes = cdSelVen.fnlsObtieneDestinosDet();
                if (lsDetDes.Count > 0)
                {
                    resultado["LsDestinos"] = JToken.FromObject(lsDetDes);
                    resultado["Exito"] = true;
                }
            }
            catch (Exception x)
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());
        }

        public ActionResult InicioDetVenta(cmVentaDet oDest)
        {
            var resultado = new JObject();
            try
            {
                CD_DetVenta cdDetVen = new CD_DetVenta();
                List<cmVentaDet> lsDetSal = new List<cmVentaDet>();
                lsDetSal = cdDetVen.fnlsRecuperaSalidaDes(oDest);
                if (lsDetSal.Count > 0)
                {
                    resultado["LsSalidas"] = JToken.FromObject(lsDetSal);
                    resultado["Exito"] = true;
                }
            }
            catch (Exception x)
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());
        }

        [HttpPost]
        public ActionResult RecuperaFechasVen(cmVentaDet detVenta)
        {
            var resultado = new JObject();
            try
            {
                CD_Viajes cdViaje = new CD_Viajes();
                List<cmVentaDet> lsVentaDetFec = new List<cmVentaDet>();
                lsVentaDetFec = cdViaje.fnlsRecuperaFechaVen(detVenta);

                if (lsVentaDetFec.Count > 0)
                {
                    JToken arFecDest = new JArray(from d in lsVentaDetFec
                                                  select new JObject(
                                                     new JProperty("IdVenta", d.idVenta),
                                                     new JProperty("dtFecha", d.dtFecha)
                                                   ));
                    resultado["LsFechaVta"] = arFecDest;
                    resultado["Exito"] = true;
                }
            }
            catch (Exception x)
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());

        }

        //  [HttpPost]
        public ActionResult ConfirmaVenta()
        {
            return View();
        }
    }
}
