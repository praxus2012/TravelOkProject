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
using TravelOKViajes.General;

namespace TravelOKViajes.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Prueba de Git hub
        /// </summary>Modificas
        /// <returns></returns>
        public ActionResult Index()
        {
            CD_Viajeros oViajeros = new CD_Viajeros();
            oViajeros.LimpiaViajeros();

/*            string correo = "irdevelo@gmail.com";



            clsCorreo test = new clsCorreo();
            test.pruebaCorreo(correo);*/
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
            catch(Exception x)
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());

        }
        //Termina HOME

        //Inicial Home
        [HttpPost]
        public ActionResult RecuperaDestinosVen(cmVentaDet detVenta)
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
        public ActionResult RecuperaFechasVen(cmVentaDet detVenta)
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

        public ActionResult Contact()
        {

            return View();
        }

        //
        public ActionResult Destinos()
        {
            CD_Viajeros oViajeros = new CD_Viajeros();
            oViajeros.LimpiaViajeros();
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
            CD_Viajeros oViajeros = new CD_Viajeros();
            oViajeros.LimpiaViajeros();
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
                                new JProperty("FR", c.dtFechaRegistro),
                                new JProperty("Img", String.Format("data:image/gif;base64,{0}", (Convert.ToBase64String(c.ImgDestino))))
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
                            new JProperty("FR", c.dtFechaRegistro),
                            new JProperty("Img", Convert.ToBase64String(c.ImgDestino))
                    ));
            }
            else
                resultado["Exito"] = false;
            return Content(resultado.ToString());
        }

        [HttpGet]
        public JsonResult obtenerPublicaciones()
        {
           List<cmBlog> listaPublicaciones = new List<cmBlog>();
            
           CD_Blog blog = new CD_Blog();
            listaPublicaciones = blog.lsObtenerListaBlog();



            //COMIENZA EL ENVÍO DEL CORREO

            //            TO_Usuario usuarioObtenido = new TO_Usuario();
            //            CD_Usuario objetoUsuario = new CD_Usuario();

            //usuarioObtenido = objetoUsuario.fnObtenerDatosUsuario(Session["UserID"].ToString());

            //clsCorreo test = new clsCorreo();
            //test.pruebaCorreo(Session["UserID"].ToString(), usuarioObtenido.Nombre,usuarioObtenido.Apellidos,usuarioObtenido.Telefono);


            //TERMINA EL ENVÍO DEL CORREO

            //            System.Diagnostics.Debug.WriteLine(Session["UserID"].ToString() + "-----***************************");

            return Json(new { publicaciones = listaPublicaciones }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult obtenerDetallePublicacion(cmBlog Publicacion)
        {

            cmBlog publicacion = new cmBlog();

            CD_Blog pub = new CD_Blog();
            publicacion = pub.cmObtenerPublicacion(Publicacion.idBlog);
            
            return Json(new { publicacion = publicacion }, JsonRequestBehavior.AllowGet);
            /*List<cmBlog> listaPublicaciones = new List<cmBlog>();

            CD_Blog blog = new CD_Blog();
            listaPublicaciones = blog.lsObtenerListaBlog();

            return Json(new { publicaciones = listaPublicaciones }, JsonRequestBehavior.AllowGet);*/

        }






        /*Fin comunidad travel ok*/

        public ActionResult Blog()
        {
            return View();
        }

    }
}