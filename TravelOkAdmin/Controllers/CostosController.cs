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

        [HttpPost]
        public ActionResult ObtieneDestinosCost(cmVentaDet detVenta)      
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


        [HttpGet]
        public ActionResult ObtieneSalidasCost()
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
        [HttpPost]
        public ActionResult ObtieneHabitacionesCost(cmCostos CCosto)
        {
            var resultado = new JObject();
            CDA_Costos cdaCostos = new CDA_Costos();
            List<TO_Habitaciones> lsHabitacion = new List<TO_Habitaciones>();
            lsHabitacion = cdaCostos.lsObtieneHabitacCostos(CCosto);
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

        public ActionResult EliminaCosto(cmCostos CCosto)
        {
            var resultado = new JObject();
            CDA_Costos cdaCosto = new CDA_Costos();
            if (cdaCosto.bEliminaCosto(CCosto))
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





    }
}