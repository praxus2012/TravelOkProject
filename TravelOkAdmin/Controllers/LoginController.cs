using CapaDatos;
using Newtonsoft.Json.Linq;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TravelOkAdmin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            using (var client = new WebClient())
            {
                int x = 0;
                ///FileUploadSFTP(ConfigurationManager.AppSettings["ftpHost"], ConfigurationManager.AppSettings["ftpUsr"], ConfigurationManager.AppSettings["ftpPass"], "D:\\Imagenes\\Saved Pictures\\sunset.jpg");
                /*client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["ftpUsr"], ConfigurationManager.AppSettings["ftpPass"]);
                client.UploadFile("ftp://" + ConfigurationManager.AppSettings["ftpHost"] + "/travel/Img/", WebRequestMethods.Ftp.UploadFile, "D:\\Imagenes\\Saved Pictures\\sunset.jpg");*/
            }
            return View();
        }

        public void FileUploadSFTP(string sHost, string sUsr, string sPass, string sFile)
        {
            var host = sHost;
            var port = 22;
            var username = sUsr;
            var password = sPass;

            // path for file you want to upload
            var uploadFile = sFile;

            using (var client = new SftpClient(host, port, username, password))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    client.ChangeDirectory("/travel/Img");
                    using (var fileStream = new FileStream(uploadFile, FileMode.Open))
                    {

                        client.BufferSize = 4 * 1024; // bypass Payload error large files
                        
                        client.UploadFile(fileStream, Path.GetFileName(uploadFile));
                    }
                }
                else
                {
                    string valor = "";
                }
            }
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
                    Session["Nombre"] = usuarioRecuperado.nvNombre;
                    Session["Usuario"] = usuarioRecuperado.nvUsuario;
                    return Content(resultado.ToString());
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
