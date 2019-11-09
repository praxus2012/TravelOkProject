using CapaDatos.Administrador;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOkAdmin.Controllers
{
    public class SalidasController : Controller
    {
        // GET: Salidas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EliminaSalidaId(int idSalida)
        {
            var resultado = new JObject();
            CDA_Salidas cdaSalida = new CDA_Salidas();
            if (cdaSalida.bEliminaSalidaId(idSalida))
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

        public ActionResult EliminaSalidaCiudad(string sCiudad)
        {
            var resultado = new JObject();
            CDA_Salidas cdaSalida = new CDA_Salidas();
            if (cdaSalida.bEliminaSalidaCiudad(sCiudad)) {
                resultado["Exito"] = true;
            }
            else
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());
        }
        public ActionResult InsertaSalida(string sSalida)
        {
            var resultado = new JObject();
            CDA_Salidas cdaDestinos = new CDA_Salidas();
            if (cdaDestinos.bInsertaSalida(sSalida))
                resultado["Exito"] = true;
            else
                resultado["Exito"] = false;
            return Content(resultado.ToString());
        }
    }
}
