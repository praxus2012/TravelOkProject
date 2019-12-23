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

		// GET: Encuesta/Details/5
		/// Ejemplo
		/// 
		public ActionResult InicialEncuesta()
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
			}
			catch (Exception x)
			{
				resultado["Exito"] = false;
			}
			return Content(resultado.ToString());
		}
		public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Encuesta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Encuesta/Create
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

        // GET: Encuesta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Encuesta/Edit/5
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

        // GET: Encuesta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Encuesta/Delete/5
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
