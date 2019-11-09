﻿
using CapaDatos;
using CapaModelo;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOKViajes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }
        //Inicial Home
        [HttpGet]
        public ActionResult InicialHome()
        {
            var resultado = new JObject();
            try
            {
                CD_Destinos cdDestino = new CD_Destinos();
                List<TO_Destino> lsDestinos = new List<TO_Destino>();
                lsDestinos = cdDestino.lsObtieneDestinos();
                if (lsDestinos.Count > 0)
                {
                    JToken arDestinos = new JArray(from d in lsDestinos
                                                   select new JObject(
                                                      new JProperty("Viaje", d.IdViaje),
                                                      new JProperty("Destino", d.Destino)
                                                    ));
                    resultado["LsDestinos"] = arDestinos;
                    resultado["Exito"] = true;
                }
                CD_Salida cdSalida = new CD_Salida();
                List<TO_Salida> lsSalida = new List<TO_Salida>();
                lsSalida = cdSalida.lsObtieneSalidas();
                if (lsSalida.Count > 0)
                {
                    JToken arSalidas = new JArray(from d in lsSalida
                                                  select new JObject(
                                                      new JProperty("Salida", d.IdSalida),
                                                      new JProperty("Ciudad", d.Ciudad)
                                                    ));
                    resultado["LsSalidas"] = arSalidas;
                }
            }
            catch(Exception x)
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());

        }
        //Termina HOME

        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult Destinos()
        {
            return View();
        }

        public ActionResult Terminos()
        {
            return View();
        }

        public ActionResult QuienesSomos()
        {
            return View();
        }

        public ActionResult Comunidad()
        {
            return View();
        }
        /*Destinos*/
        [HttpGet]
        public ActionResult InicioDestinos()
        {
            var resultado = new JObject();
            try
            {
                CD_Destinos cDes = new CD_Destinos();
                List<cmDestinos> lsDestinos = new List<cmDestinos>();
                lsDestinos = cDes.lsObtieneImgDestinos();
                if (lsDestinos.Count() > 0)
                {
                    resultado["Exito"] = true;
                    resultado["lsDestinosImg"] = JToken.FromObject(lsDestinos);
                }else
                    resultado["Exito"] = false;
            }
            catch(Exception x)
            {

            }
            return Content(resultado.ToString());
        }

        [HttpPost]
        public ActionResult ObtieneCarrDestino(cmDestinos Destino)
        {
            var resultado = new JObject();
            try
            {
                CD_Destinos cDes = new CD_Destinos();
                Destino = cDes.cmObtieneImgDestinos(Destino);
                if (Destino.sTitulo != null)
                {
                    resultado["Exito"] = true;
                    resultado["DestinoDet"] = JToken.FromObject(Destino);
                    List<cmCarruselDestino> carrDest = new List<cmCarruselDestino>();
                    carrDest = cDes.cmObtieneCarrDestino(Destino);
                    resultado["LsCarrDestinos"] = JToken.FromObject(carrDest);
                }
                else
                    resultado["Exito"] = false;
            }
            catch (Exception x)
            {

            }
            return Content(resultado.ToString());
        }




        /*Fin Destinos*/
        /*Comunidad Travel ok*/
        [HttpGet]
        public ActionResult InicioComunidad()
        {
            var resultado = new JObject();
            try
            {
                CD_Destinos cdDestino = new CD_Destinos();
                List<TO_Destino> lsDestinos = new List<TO_Destino>();
                CD_Comunidad ComunidadTravel = new CD_Comunidad();
                List<cmComunidad> ComunidadT = new List<cmComunidad>();
                lsDestinos = cdDestino.lsObtieneDestinos();
                if (lsDestinos.Count > 0)
                {
                    JToken arDestinos = new JArray(from d in lsDestinos
                                              select new JObject(
                                                 new JProperty("Viaje", d.IdViaje),
                                                 new JProperty("Destino", d.Destino)
                                               ));
                    resultado["LsDestinos"] = arDestinos;
                    resultado["Exito"] = true;
                    ComunidadT = ComunidadTravel.lsObtieneComunidad();
                    resultado["LsComunidad"] =
                        new JArray(
                            from c in ComunidadT
                            select new JObject(
                                new JProperty("Nom", c.sNombre),
                                new JProperty("Tes", c.sTestimonio),
                                new JProperty("Cal", c.iCalificacion),
                                new JProperty("IDes", c.IdViaje),
                                new JProperty("Des", c.sDestino),
                                new JProperty("FR", c.dtFechaRegistro)
                        ));
                }
            }
            catch (Exception x)
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());
        }

        [HttpPost]
        public ActionResult InsertaComunidad(
            HttpPostedFileBase ImgDestino,
            int IdViaje,
            string sNombre,
            string sTestimonio,
            int iCalificacion
            )
        {
            byte[] baImagen = null;
            if (ImgDestino != null && ImgDestino.ContentLength > 0)
            {
                BinaryReader rdrImagen = new BinaryReader(ImgDestino.InputStream);
                baImagen = rdrImagen.ReadBytes((int)ImgDestino.ContentLength);
            }
            cmComunidad Comunidad =
                new cmComunidad
                {
                    IdViaje = IdViaje,
                    sNombre = sNombre,
                    sTestimonio = sTestimonio,
                    iCalificacion = iCalificacion,
                    ImgDestino = baImagen
                };
            var resultado = new JObject();
            CD_Comunidad ComunidadTravel = new CD_Comunidad();
            List<cmComunidad> ComunidadT = new List<cmComunidad>();
            if (ComunidadTravel.bInsertaComunidad(Comunidad))
            {
                resultado["Exito"] = true;
                ComunidadT = ComunidadTravel.lsObtieneComunidad();
                resultado["LsComunidad"] =
                    new JArray(
                        from c in ComunidadT
                        select new JObject(
                            new JProperty("Nom", c.sNombre),
                            new JProperty("Tes",c.sTestimonio),
                            new JProperty("Cal",c.iCalificacion),
                            new JProperty("IDes", c.IdViaje),
                            new JProperty("Des", c.sDestino),
                            new JProperty("FR", c.dtFechaRegistro)
                    ));
            }
            else
                resultado["Exito"] = false;
            return Content(resultado.ToString());
        }




        /*Fin comunidad travel ok*/

        public ActionResult Blog()
        {
            return View();
        }

    }
}