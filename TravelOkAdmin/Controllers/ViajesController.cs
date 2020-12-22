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
    public class ViajesController : Controller
    {
        // GET: Viajes
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertarViaje(List<TO_Viajes> lsViajes)
        {
            var resultado = new JObject();
            try
            {
                CD_Viajes daViajes = new CD_Viajes();
                if (daViajes.fnbInsertaViajes(lsViajes))
                {
                    resultado["Exito"] = true;
                }
                else
                {
                    resultado["False"] = true;
                }
            }
            catch (Exception x)
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());
        }
        [HttpGet]
        public ActionResult ObtieneViajElimina()
        {
            var resultado = new JObject();
            CD_Viajes cdViaj = new CD_Viajes();
            List<cmViajeElimina> lsViajElim = new List<cmViajeElimina>();
            lsViajElim = cdViaj.fnlsObtViajeElimina();
            if (lsViajElim.Any())
            {
                JToken arSalidas = new JArray(from d in lsViajElim
                                              select new JObject(
                                                 new JProperty("idViaje", d.idViaje),
                                                 new JProperty("desViaje", d.sDescViaje)
                                               ));
                resultado["LsViajeElim"] = arSalidas;
                resultado["Exito"] = true;
            }
            return Content(resultado.ToString());
        }
        [HttpGet]
        public ActionResult ObtieneViajEliminaA()
        {
            var resultado = new JObject();
            CD_Viajes cdViaj = new CD_Viajes();
            List<cmViajeElimina> lsViajElim = new List<cmViajeElimina>();
            lsViajElim = cdViaj.fnlsObtViajeEliminaA();
            if (lsViajElim.Any())
            {
                JToken arSalidas = new JArray(from d in lsViajElim
                                              select new JObject(
                                                 new JProperty("idViaje", d.idViaje),
                                                 new JProperty("desViaje", d.sDescViaje)
                                               ));
                resultado["LsViajeElim"] = arSalidas;
                resultado["Exito"] = true;
            }
            else
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());
        }

        [HttpPost]
        public ActionResult BorrarViaje(int idViaje)
        {
            var resultado = new JObject();
            CD_Viajes cdViaj = new CD_Viajes();
            List<cmViajeElimina> lsViajElim = new List<cmViajeElimina>();
            if(cdViaj.fnbBorrarViaje(idViaje))
                resultado["Exito"] = true;
            else
                resultado["Exito"] = false;
            return Content(resultado.ToString());
        }
    }
}