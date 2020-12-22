using CapaDatos;
using CapaModelo;
using Newtonsoft.Json.Linq;
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
            //if (Session["Usuario"] != null)
                return View();
            /*else
                return RedirectToAction("Login", "Index");*/
        }

        public ActionResult GeneraTabla(TO_Viajes oViaje)
        {
            JObject oResultado = new JObject();
            try
            {
                CD_Viajeros oViajeros = new CD_Viajeros();
                List<cmPersonasViaje> lsviajeros = oViajeros.ObtenerViajeros(oViaje);
                if (lsviajeros.Count > 0)
                {
                    oResultado["Exito"] = true;
                    oResultado["lsViajeros"] = JToken.FromObject(lsviajeros);
                }
                else
                {
                    oResultado["Exito"] = false;
                }
            }
            catch(Exception ex)
            {
                oResultado["Exito"] = false;
            }
            return Content(oResultado.ToString());
        }

        public ActionResult CargaInicial()
        {
            JObject oResultado = new JObject();
            try
            {
                CD_Salida cdSalida = new CD_Salida();
                List<TO_Salida> lsSalidas = new List<TO_Salida>();
                lsSalidas = cdSalida.lsObtieneSalidasViajes();
                if (lsSalidas.Count > 0)
                {
                    JToken arSalidas = new JArray(from d in lsSalidas
                                                  select new JObject(
                                                     new JProperty("Salida", d.IdSalida),
                                                     new JProperty("Ciudad", d.Ciudad)
                                                   ));
                    oResultado["LsSalidas"] = arSalidas;
                    oResultado["Exito"] = true;
                }
                else
                {
                    oResultado["Exito"] = false;
                }
            }
            catch (Exception ex)
            {
                oResultado["Exito"] = false;
            }
            return Content(oResultado.ToString());
        }
    }
}