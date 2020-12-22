using CapaDatos;
using CapaDatos.Administrador;
using CapaModelo;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOkAdmin.Controllers
{
    public class SalidasController : Controller
    {
        // GET: Salidas
        public ActionResult Index()
        {
            //if (Session["Usuario"] != null)
                return View();
            /*else
                return RedirectToAction("Index", "Login");*/
        }

        public ActionResult ObtieneSaalidas()
        {
            var resultado = new JObject();
            CD_Salida cdSalida = new CD_Salida();
            List<TO_Salida> lsSalidas = new List<TO_Salida>();
            lsSalidas = cdSalida.lsObtieneSalidas();
            if (lsSalidas.Count > 0)
            {
                JToken arSalidas = new JArray(from d in lsSalidas
                                              select new JObject(
                                                 new JProperty("Salida", d.IdSalida),
                                                 new JProperty("Ciudad", d.Ciudad)
                                               ));
                resultado["LsSalidas"] = arSalidas;
                resultado["Exito"] = true;
            }
            return Content(resultado.ToString());
        }

        public ActionResult EliminaSalidaId(int idSalida)
        {
            var resultado = new JObject();
            CDA_Salidas cdaSalida = new CDA_Salidas();
            if (cdaSalida.bEliminaSalidaId(idSalida))
            {
                resultado["Exito"] = true;
            }
            else
            {
                resultado["Exito"] = false;
            }
            //resultado["Exito"] = cdaSalida.bEliminaSalidaId(idSalida) ? true : false;
            return Content(resultado.ToString());
        }

        public ActionResult EliminaSalidaCiudad(string sCiudad)
        {
            var resultado = new JObject();
            CDA_Salidas cdaSalida = new CDA_Salidas();
            if (cdaSalida.bEliminaSalidaCiudad(sCiudad))
            {
                resultado["Exito"] = true;
            }
            else
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());
        }
        public ActionResult InsertaSalida(string sSalida)
        {
            var resultado = new JObject();
            CDA_Salidas cdaDestinos = new CDA_Salidas();
            if (cdaDestinos.bInsertaSalida(sSalida))
                resultado["Exito"] = true;
            else
                resultado["Exito"] = false;
            return Content(resultado.ToString());
        }

        public ActionResult ModificarSalida(int IdSalida, string Ciudad)
        {
            var resultado = new JObject();
            CDA_Salidas cdaSalida = new CDA_Salidas();
            if (cdaSalida.bModificaSalida(IdSalida, Ciudad))
            {
                resultado["Exito"] = true;
            }
            else
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());
        }
    }
}
