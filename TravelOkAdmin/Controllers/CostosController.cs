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
    public class CostosController : Controller
    {
        // GET: Costos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ObtieneHabitaciones()
        {
            var resultado = new JObject();
            CD_Costos cdCostos = new CapaDatos.CD_Costos();
            List<TO_Habitaciones> lsHabitacion = new List<TO_Habitaciones>();
            lsHabitacion = cdCostos.lsObtieneHabitaciones();
            if (lsHabitacion.Count > 0)
            {
                JToken arHabitaciones = new JArray(from d in lsHabitacion
                                             select new JObject(
                                                  new JProperty("tipoHab", d.IdTipoHab),
                                                  new JProperty("Descripcion", d.nvDescripcion)
                                                ));
                resultado["LsHabitaciones"] = arHabitaciones;
                resultado["Exito"] = true;
            }
            return Content(resultado.ToString());
        }


        public ActionResult InsertaCostos(cmCostos CCosto)
        {
            var resultado = new JObject();

            CDA_Costos cdaCostos = new CDA_Costos();
            if (cdaCostos.bInsertaCosto(CCosto))
                resultado["Exito"] = true;
            else
                resultado["Exito"] = false;
            return Content(resultado.ToString());
        }






    }
}