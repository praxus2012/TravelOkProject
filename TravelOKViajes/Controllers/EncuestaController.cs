using CapaDatos;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOKViajes.Controllers
{
    public class EncuestaController : Controller
    {
        // GET: Encuesta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InicialEncuesta()
        {
            var resultado = new JObject();
            try
            {
                CD_Destinos cdDestino = new CD_Destinos();
                List<TO_Destino> lsDestinos = new List<TO_Destino>();
                CD_Encuesta cdEncuesta = new CD_Encuesta();
                List<TO_Encuesta> lsEncuesta = new List<TO_Encuesta>();
                lsEncuesta = cdEncuesta.fnlsObtienePreguntas();
                lsDestinos = cdDestino.lsObtieneDestinos();
                if (lsDestinos.Count > 0)
                {
                    JToken arDestinos = new JArray(from d in lsDestinos
                                                   select new JObject(
                                                      new JProperty("Viaje", d.IdViaje),
                                                      new JProperty("Destino", d.Destino)
                                                    ));
                    resultado["LsDestinos"] = arDestinos;
                    resultado["LsEncuesta"] = new JArray(from p in lsEncuesta
                                                         select new JObject(
                                                             new JProperty("IdPregunta", p.IdPregunta),
                                                             new JProperty("nvPregunta", p.nvPregunta),
                                                             new JProperty("iTipoPreg", p.iTipoPreg)
                                                         ));
                    resultado["Exito"] = true;
                }
            }
            catch (Exception x)
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());
        }

        // POST: Encuesta/Create
        [HttpPost]
        public ActionResult RecibeEncuesta(List<TO_EncuestaResp> SalidaRes)
        {
            var resultado = new JObject();
            try
            {
                CD_Encuesta cdEncuesta = new CD_Encuesta();
                if (cdEncuesta.fnbInsertaEncuesta(SalidaRes))
                {
                    resultado["Exito"] = true;
                }
                else
                {
                    resultado["Exito"] = false;
                }
            }
            catch(Exception ex)
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());
        }
    }
}
