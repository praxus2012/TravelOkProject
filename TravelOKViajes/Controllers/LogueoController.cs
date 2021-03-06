﻿using CapaDatos;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelOKViajes.Controllers
{
    public class LogueoController : Controller
    {
        // GET: Logueo
        public ActionResult TravelInicio()
        {
            if(Session["UserID"]!= null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult TravelRegistro()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult RegistrarUsuario(TO_Usuario Usr)
        {
            JObject Respuesta = new JObject();
            try
            {
                CD_Usuario cdUsuario = new CD_Usuario();
                Usr = cdUsuario.fnRegistraUsuario(Usr);
                if(Usr == null)
                {
                    Respuesta["Exito"] = false;
                    Respuesta["Mensaje"] = "El usuario ya existe, favor de loguearse";
                }
                else
                {
                    Respuesta["Exito"] = true;
                    Respuesta["oUsr"] = new JObject(
                        new JProperty("Correo", Usr.Correo),
                        new JProperty("Contra", Usr.Contra),
                        new JProperty("Nombre", Usr.Nombre),
                        new JProperty("Apellidos", Usr.Apellidos),
                        new JProperty("Genero", Usr.Genero),
                        new JProperty("Estado", Usr.Estado),
                        new JProperty("Municipio", Usr.Municipio),
                        new JProperty("Telefono", Usr.Telefono),
                        new JProperty("Activo", Usr.Activo),
                        new JProperty("TelefonoEmerg", Usr.TelefonoEmerg),
                        new JProperty("ParentescoTelEmerg", Usr.ParentescoTelEmerg));
                    Session["UserID"] = Usr.Correo;
                    Session["UserName"] = Usr.Nombre;
                }
            }
            catch(Exception ex)
            {
                Respuesta["Exito"] = false;
                Respuesta["Mensaje"] = ex.Message;
            }
            return Content(Respuesta.ToString());
        }

        public ActionResult IniciarSesion(TO_Usuario Usr)
        {
            JObject Respuesta = new JObject();
            try
            {
                CD_Usuario cdUsuario = new CD_Usuario();
                Usr = cdUsuario.fnLogueaUsuario(Usr);
                if (Usr == null)
                {
                    Respuesta["Exito"] = false;
                    Respuesta["Mensaje"] = "Usuario o contraseña incorrectos";
                }
                else
                {
                    Respuesta["Exito"] = true;
                    Respuesta["oUsr"] = new JObject(
                       new JProperty("Correo", Usr.Correo),
                       new JProperty("Contra", Usr.Contra),
                       new JProperty("Nombre", Usr.Nombre),
                       new JProperty("Apellidos", Usr.Apellidos),
                       new JProperty("Genero", Usr.Genero),
                       new JProperty("Estado", Usr.Estado),
                       new JProperty("Municipio", Usr.Municipio),
                       new JProperty("Telefono", Usr.Telefono),
                       new JProperty("Activo", Usr.Activo));
                    Session["UserID"] = Usr.Correo;
                    Session["UserName"] = Usr.Nombre;
                }
            }
            catch (Exception ex)
            {
                Respuesta["Exito"] = false;
                Respuesta["Mensaje"] = ex.Message;
            }
            return Content(Respuesta.ToString());
        }
    }
}
