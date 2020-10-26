using CapaDatos;
using CapaModelo;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MercadoPago;
using MercadoPago.Resources;
using MercadoPago.DataStructures.Preference;
using MercadoPago.Common;

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
            if (Session["UserName"] == null)
            {
                return RedirectToAction("TravelInicio", "Logueo");
            }
            /*return View();*/
            /*return RedirectToAction("SeleccionVenta");*/
            var resultado = new JObject();
            CD_Transporte cdTran = new CD_Transporte();
            cmTransporte oTran = cdTran.fnoObtieneTransporte(detVenta);
            if (oTran != null)
            {
                resultado["lsOcupados"] = JToken.FromObject(cdTran.fnlsObtieneOcupados(detVenta.idVenta));
                resultado["oTransporte"] = JToken.FromObject(oTran);
                resultado["Exito"] = true;
            }
            else
            {
                resultado["Exito"] = false;
            }
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
            if (Session["UserName"] == null)
            {
                return RedirectToAction("TravelInicio", "Logueo");
            }
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
            if (Session["UserName"] == null)
            {
                return RedirectToAction("TravelInicio", "Logueo");
            }
            var resultado = new JObject();
            try
            {
                CD_DetVenta odVenta = new CD_DetVenta();
                List<cmVentaDet> lsDetSal = new List<cmVentaDet>();
                lsDetSal = odVenta.fnlsRecuperaSalidaDes(oDest);
                
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
        public ActionResult ObtienePropuestas(cmHabitacion oHabitacion)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("TravelInicio", "Logueo");
            }
            var resultado = new JObject();
            try
            {
                CD_DetVenta odVenta = new CD_DetVenta();
                List<cmHabitacion> lsHabitaciones = new List<cmHabitacion>();
                int count = 0;
                if (oHabitacion.iPasajeros > 2)
                {
                    while (count < 3)
                    {
                        oHabitacion.iDecremento = count;
                        lsHabitaciones = odVenta.fnlsRecuperaOpciones(oHabitacion);
                        decimal tot = 0;
                        foreach(cmHabitacion hab in lsHabitaciones)
                        {
                            tot += hab.dCosto;
                        }
                        if (count == 0)
                        {
                            resultado["Opcion0"] = JToken.FromObject(lsHabitaciones);
                            resultado["Total0"] = tot;
                        }
                        if (count == 1)
                        {
                            resultado["Opcion1"] = JToken.FromObject(lsHabitaciones);
                            resultado["Total1"] = tot;
                        }
                        if (count == 2)
                        {
                            resultado["Opcion2"] = JToken.FromObject(lsHabitaciones);
                            resultado["Total2"] = tot;
                        }
                        count++;
                    }
                }
                else
                {
                    oHabitacion.iDecremento = 0;
                    lsHabitaciones = odVenta.fnlsRecuperaOpciones(oHabitacion);
                    decimal tot = 0;
                    foreach (cmHabitacion hab in lsHabitaciones)
                    {
                        tot += hab.dCosto;
                    }
                    resultado["Opcion"] = JToken.FromObject(lsHabitaciones);
                    resultado["Total"] = tot;
                }
                if (lsHabitaciones.Count > 0)
                {
                    resultado["Exito"] = true;
                }

                /*lsHabitaciones = odVenta.fnlsRecuperaOpciones(new cmHabitacion
                {
                    iPasajeros = 10,
                    idViaje = 2,
                    iDecremento = 0
                });*/

            }
            catch(Exception ex)
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());
        }

        [HttpPost]
        public ActionResult RecuperaFechasVen(cmVentaDet detVenta)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("TravelInicio", "Logueo");
            }
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

        public ActionResult RegistraUsuarios()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("TravelInicio", "Logueo");
            }
            return View();
        }
        [HttpPost]
        public ActionResult InsertaViajeros(List<cmViajeros> oUsrViajeros)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("TravelInicio", "Logueo");
            }
            JObject resultado = new JObject();
            if (oUsrViajeros.Count > 0)
            {
                CD_Viajeros cdViajeros = new CD_Viajeros();
                oUsrViajeros.ToList().ForEach(cc => cc.idUsuario = Session["UserID"].ToString());
                cmHabitacion oHabitacion = new cmHabitacion
                {
                    iPasajeros = oUsrViajeros.Count,
                    idViaje = oUsrViajeros[0].idViaje
                };
                CD_DetVenta odVenta = new CD_DetVenta();
                decimal tot = 0;                
                switch (oUsrViajeros[0].sOpcionTour)
                {
                    case "btnOp-0":
                        oHabitacion.iDecremento = 0;
                        foreach (cmHabitacion hab in odVenta.fnlsRecuperaOpciones(oHabitacion))
                        {
                            tot += hab.dCosto;
                        }
                        oUsrViajeros.ToList().ForEach(cc => cc.dCostoTotal = tot);
                        break;
                    case "btnOp-1":
                        oHabitacion.iDecremento = 1;
                        foreach (cmHabitacion hab in odVenta.fnlsRecuperaOpciones(oHabitacion))
                        {
                            tot += hab.dCosto;
                        }
                        oUsrViajeros.ToList().ForEach(cc => cc.dCostoTotal = tot);
                        break;
                    case "btnOp-2":
                        oHabitacion.iDecremento = 2;
                        foreach (cmHabitacion hab in odVenta.fnlsRecuperaOpciones(oHabitacion))
                        {
                            tot += hab.dCosto;
                        }
                        oUsrViajeros.ToList().ForEach(cc => cc.dCostoTotal = tot);
                        break;
                    case "btnOp-3":
                        oHabitacion.iDecremento = 0;
                        foreach (cmHabitacion hab in odVenta.fnlsRecuperaOpciones(oHabitacion))
                        {
                            tot += hab.dCosto;
                        }
                        oUsrViajeros.ToList().ForEach(cc => cc.dCostoTotal = tot);
                        break;
                }

                if (cdViajeros.InsertaViajeros(oUsrViajeros))
                {
                    resultado["Exito"] = true;
                    Session["UserID"] = Session["UserID"];
                    Session["UserName"] = Session["UserName"];
                    Session["dCosto"] = tot;
                }                    
                else
                    resultado["Exito"] = false;
            }
            else
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());
        }

        [HttpPost]
        public ActionResult ConfirmaVenta()
        {
            return View();
        }

        public ActionResult Pago()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("TravelInicio", "Logueo");
            }
            decimal dCosto = Decimal.Parse(Session["dCosto"].ToString());

                ViewData["dCosto"] = dCosto;
               
            return View();
        }

        [HttpGet]
        public ActionResult ConfirmarPago()
        {
            JObject resultado = new JObject();
            try
            {
                CD_Viajeros cdViajeros = new CD_Viajeros();
                if (cdViajeros.ConfirmarViaje(Session["UserID"].ToString()))
                {                   
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
        public ActionResult ConfirmarPago2()
        {
            JObject resultado = new JObject();
            try
            {
                CD_Viajeros cdViajeros = new CD_Viajeros();
                if (cdViajeros.ConfirmarViaje(Session["UserID"].ToString(), decimal.Parse(Session["dCosto"].ToString())))
                {
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
