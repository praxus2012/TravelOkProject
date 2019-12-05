
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
            CD_Costos cdCostos = new CD_Costos();
            List<TO_Costos> lsCostos = new List<TO_Costos>();
            lsCostos = cdCostos.lsObtieneHabitaciones();
            if (lsCostos.Count > 0)
            {
                JToken arDestinos = new JArray(from d in lsDestinos
                                               select new JObject(
                                                  new JProperty("Viaje", d.IdViaje),
                                                  new JProperty("Destino", d.Destino)
                                                ));
                resultado["LsDestinos"] = arDestinos;
                resultado["Exito"] = true;
            }
            return Content(resultado.ToString());
        }
    }
}