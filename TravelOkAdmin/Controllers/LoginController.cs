using CapaDatos;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOkAdmin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logeo(TOA_Usuario datosUsuario)
        {
            var resultado = new JObject();
            var baseDatos = new CD_Usuario();
            TOA_Usuario usuarioRecuperado = baseDatos.tusChecarUsuario(datosUsuario);

            if (usuarioRecuperado != null)
            {
                if (usuarioRecuperado.nvUsuario == "Error")
                {
                    resultado["Error"] = true;
                }
                else
                {
                    resultado["Exito"] = true;
                    DateTime horaActual = DateTime.Now;
                    Session["Activo"] = true;
                    Session["Usuario"] = usuarioRecuperado;
                }
            }
            else
            {
                resultado["Advertencia"] = true;
            }
            return Content(resultado.ToString());
        }
    }
}
