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
    public class TransporteController : Controller
    {
        // GET: Transporte
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ObtieneTransportes()
        {
            var resultado = new JObject();
            CD_Transporte cdTrans = new CD_Transporte();
            List<cmTranspCat> lsTransp = new List<cmTranspCat>();
            lsTransp = cdTrans.fnlsObtieneTransportes();
            if (lsTransp.Any())
            {
                JToken arSalidas = new JArray(from d in lsTransp
                                              select new JObject(
                                                 new JProperty("idTrans", d.idTransporte),
                                                 new JProperty("NombreT", d.sNomTransp),
                                                 new JProperty("NumAsi", d.iNumAsientos)
                                               ));
                resultado["LsTransportes"] = arSalidas;
                resultado["Exito"] = true;
            }
            return Content(resultado.ToString());
        }
    }
}