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
    public class DestinosController : Controller
    {
        // GET: Destinos
        public ActionResult Index()
        {
            //if (Session["Usuario"] != null)
                return View();
            /*else
                return RedirectToAction("Index", "Login");*/
        }

        public ActionResult Carrusel()
        {
            return View();
        }

        public ActionResult InicialDestinos()
        {
            var resultado = new JObject();
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
            return Content(resultado.ToString());
        }
        public ActionResult InsertaDestino(cmDestinos CDestino)
        {
            var resultado = new JObject();
            CDA_Destinos cdaDestinos = new CDA_Destinos();
            if (cdaDestinos.bInsertaDestino(CDestino))
                resultado["Exito"] = true;
            else
                resultado["Exito"] = false;
            return Content(resultado.ToString());
        }


        public ActionResult EliminaDestinoId(int idDestino)
        {
            var resultado = new JObject();
            CDA_Destinos cdaDestino = new CDA_Destinos();
            if (cdaDestino.bEliminaDestino_Id(idDestino))
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

        public ActionResult InsertaDetalleDestino(cmCarruselDestino CDetDestino)
        {
            var resultado = new JObject();
            CDA_CarruselDestino cdaDetDestinos = new CDA_CarruselDestino();
            if (cdaDetDestinos.bInsertaCarruselDestino(CDetDestino))
                resultado["Exito"] = true;
            else
                resultado["Exito"] = false;
            return Content(resultado.ToString());
        }

        // GET: Destinos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Destinos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destinos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Destinos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Destinos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Destinos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Destinos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
