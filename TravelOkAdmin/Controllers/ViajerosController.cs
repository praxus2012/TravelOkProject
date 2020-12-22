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
    public class ViajerosController : Controller
    {
        // GET: Viajeros
        public ActionResult Index()
        {
            /* if (Session["Usuario"] != null)
                return View();
            else
            */
            return View();
        }

        public ActionResult RecuperaSalida()
        {
            var resultado = new JObject();
            try
            {
                CD_Viajes cdViaje = new CD_Viajes();
                List<cmVentaDet> lsVentaDetSal = new List<cmVentaDet>();
                lsVentaDetSal = cdViaje.fnlsRecuperaSalida();

                if (lsVentaDetSal.Count > 0)
                {
                    JToken arSalidas = new JArray(from d in lsVentaDetSal
                                                  select new JObject(
                                                      new JProperty("Salida", d.idSalida),
                                                      new JProperty("Ciudad", d.sSalida)
                                                    ));
                    resultado["LsSalidas"] = arSalidas;
                    resultado["Exito"] = true;
                }
            }
            catch (Exception x)
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());

        }
        //Termina HOME

        //Inicial Home
        [HttpPost]
        public ActionResult RecuperaDestinos(cmVentaDet detVenta)
        {
            var resultado = new JObject();
            try
            {
                CD_Viajes cdViaje = new CD_Viajes();
                List<cmVentaDet> lsVentaDetDes = new List<cmVentaDet>();
                lsVentaDetDes = cdViaje.fnlsRecuperaDestino(detVenta);

                if (lsVentaDetDes.Count > 0)
                {
                    JToken arDestinos = new JArray(from d in lsVentaDetDes
                                                   select new JObject(
                                                      new JProperty("IdDest", d.idDestino),
                                                      new JProperty("Destino", d.sDestino)
                                                    ));
                    resultado["LsDestinos"] = arDestinos;
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
        public ActionResult RecuperaFechas(cmVentaDet detVenta)
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

        [HttpPost]
        public ActionResult ObtieneTablaViajeros(int idViaj)
        {
            var resultado = new JObject();
            try
            {
                CD_Viajeros cdViajeros = new CD_Viajeros();
                List<cmViajeros> lsViajeros = new List<cmViajeros>();
                lsViajeros = cdViajeros.fnlsObtieneTablaViajeros(idViaj);

                if(lsViajeros.Count()> 0)
                {
                    JToken arListViajeros = new JArray(from d in lsViajeros
                                                       select new JObject(
                                                           new JProperty("sNombre", d.sNombre),
                                                           new JProperty("sApellido", d.sApellido),
                                                           new JProperty("idUsuario", d.idUsuario),
                                                           new JProperty("iAsiento", d.iAsiento),
                                                           new JProperty("sTelefono", d.sTelefono),
                                                           new JProperty("dtFechaRegistro", d.dtFechaRegistro),
                                                           new JProperty("sDestino", d.sDestino),
                                                           new JProperty("sSalida", d.sSalida),
                                                           new JProperty("dtFechaSalida", d.dtFechaSalida)
                                                           ));
                    resultado["lsTablaViajeros"] = arListViajeros;
                    resultado["Exito"] = true;
                }
            }
            catch (Exception x)
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());
        }

    }
}