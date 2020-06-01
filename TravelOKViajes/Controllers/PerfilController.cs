using CapaDatos;
using CapaModelo;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TravelOKViajes.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("TravelInicio", "Logueo");
            }
            return View();
        }

        [HttpGet]
        public ActionResult InicialPerfil()
        {
            string sUsuario = Session["UserID"].ToString();

            var resultado = new JObject();
            try
            {
                CD_Perfil cdPerfil = new CD_Perfil();
                List<cmDeudaViajeros> olsDeudaViaje = new List<cmDeudaViajeros>();
                olsDeudaViaje = cdPerfil.fnlsRecuperaInfo(sUsuario);
                if (olsDeudaViaje.Count > 0)
                {
                    resultado["olsDeudaViaje"] = JToken.FromObject(olsDeudaViaje);
                    resultado["Exito"] = true;
                }
                else
                {
                    resultado["Exito"] = false;
                    resultado["NoViaje"] = true;
                }
            }
            catch (Exception x)
            {
                resultado["Exito"] = false;
            }
            return Content(resultado.ToString());
        }

        [HttpPost]
        public ActionResult InsertaPago(cmInsertaPago DatosPago)
        {
            var resultado = new JObject();
            try
            {
                DatosPago.idUsuario = Session["UserID"].ToString();
                foreach (string _fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[_fileName];
                    DatosPago.sNomArch = file.FileName;
                    if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")
                    {
                        resultado["Exito"] = false;
                        resultado["Mensaje"] = "El archivo debe ser formato PDF";
                        return Content(resultado.ToString());
                    }
                    MemoryStream target = new MemoryStream();
                    file.InputStream.CopyTo(target);
                    byte[] data = target.ToArray();
                    DatosPago.Archivo = data;
                };
                CD_Perfil ocdPerf = new CD_Perfil();
                if (ocdPerf.fnbActualizaPago(DatosPago))
                    resultado["Exito"] = true;
                else
                {
                    resultado["Exito"] = false;
                    resultado["Mensaje"] = "No se pudo realizar la actualización correctamente.";
                }
                return Content(resultado.ToString());
            }
            catch (Exception ex)
            {
                resultado["Exito"] = false;
                resultado["Mensaje"] = ex.Message.ToString();
                return Content(resultado.ToString());
            }
        }
    }
}
