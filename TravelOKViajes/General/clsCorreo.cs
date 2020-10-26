using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace TravelOKViajes.General
{
    public class clsCorreo
    {
        public void pruebaCorreo()
        {
            string valor = "test";
            string texto = "";
            texto = "<html>";
            texto = texto + "<body><style>body{min-width: 1308px;}#dvimg{background-image:url(https://scontent.fjal2-1.fna.fbcdn.net/v/t1.0-9/69538116_2184383068525054_5218256411326152704_n.png?_nc_cat=100&ccb=2&_nc_sid=09cbfe&_nc_eui2=AeEvcxU1mPyZatD-6Kd2PmQn5Kv2i40-TZXkq_aLjT5NlZmZ19YuRnGODSEnNjrqrH8&_nc_ohc=qNN1SOdeDpAAX8PUpJu&_nc_ht=scontent.fjal2-1.fna&oh=f9ca4560a5e454501d8366be7aafb354&oe=5FBCCE74);";
            texto = texto + "background-size: cover;background-repeat: no-repeat;width: 143px;height: 64px;border-top-right-radius: 0.5em;border-bottom-right-radius: 0.5em;float: right;background-position-y: -2rem;}";
            texto = texto + "#dvtb>ul>li{display: block;width: 970px;}#seRecibo{width: 80%;margin: 0 auto;}#dvTit{width: 100%;text-align: center;margin: 0 auto;height: 4em;border-radius: 0.5em;";
            texto = texto + "background-color: #007bff!important;color: #fff;opacity: 0.7;}#dvTit>#tit{float: left;margin-left: 2%;}#dvfec{width: 7rem;border-style: groove;}";
            texto = texto + "#dvfec>li{display: block;width: 80%;}#dvtb>ul>li>ul>li{display: inline;}.un{width: 200px;padding-left: 2rem;line-height: 2rem;height: 2rem;float: left;font-weight: bold;";
            texto = texto + "background-color: #787878;margin-bottom: 10px;color: #ffffff;}.dos{width: 650px;height: 2rem;text-align: center;line-height: 2rem;float: right;background-color: #D7D7D7;";
            texto = texto + "margin-bottom: 10px;}p{clear: both;}#dvFoot{margin-top: 2rem;text-align: center;}#dvFoot>ul>li{display: block;}#dvIz{float: left;font-weight: bold; margin-left: 8%;}";
            texto = texto + "#dvDer{float: right;margin-right: 15%;}#x_dvDer{float: right;margin-right: 15%;}#dvFoot{margin-top: 2rem;text-align: center;}#x_dvFoot>ul>li{display: block;}#x_dvIz{float: left;font-weight: bold;}";
            texto = texto + "#x_dvimg{background-image:url(https://scontent.fjal2-1.fna.fbcdn.net/v/t1.0-9/69538116_2184383068525054_5218256411326152704_n.png?_nc_cat=100&ccb=2&_nc_sid=09cbfe&_nc_eui2=AeEvcxU1mPyZatD-6Kd2PmQn5Kv2i40-TZXkq_aLjT5NlZmZ19YuRnGODSEnNjrqrH8&_nc_ohc=qNN1SOdeDpAAX8PUpJu&_nc_ht=scontent.fjal2-1.fna&oh=f9ca4560a5e454501d8366be7aafb354&oe=5FBCCE74);";
            texto = texto + "background-size: cover;background-repeat: no-repeat;width: 143px;height: 64px;border-top-right-radius: 0.5em;border-bottom-right-radius: 0.5em;float: right;background-position-y: -2rem;}";
            texto = texto + "#x_dvtb>ul>li{display: block;width: 970px;}#x_seRecibo{width: 80%;margin: 0 auto;}#x_dvTit{width: 100%;text-align: center;margin: 0 auto;height: 4em;border-radius: 0.5em;";
            texto = texto + "background-color: #007bff!important;color: #fff;opacity: 0.7;}#x_dvTit>#x_tit{float: left;margin-left: 2%;}#dvfec{width: 7rem;border-style: groove;}";
            texto = texto + "#x_dvfec>li{display: block;width: 80%;}#x_dvtb>ul>li>ul>li{display: inline;}.x_un{width: 200px;padding-left: 2rem;line-height: 2rem;height: 2rem;float: left;font-weight: bold;";
            texto = texto + "background-color: #787878;margin-bottom: 10px;color: #ffffff;}.x_dos{width: 650px;height: 2rem;text-align: center;line-height: 2rem;float: right;background-color: #D7D7D7;";
            texto = texto + "margin-bottom: 10px;}p{clear: both;}#x_dvFoot{margin-top: 2rem;text-align: center;}#x_dvFoot>ul>li{display: block;}#x_dvIz{float: left;font-weight: bold; margin-left: 8%;}";
            texto = texto + "</style><section id=seRecibo style=width:1000px><div id=dvTit><div id=tit><h2>Recibo de pago Travel ok</h2></div><div id=dvimg style=background-image:url(https://scontent.fjal2-1.fna.fbcdn.net/v/t1.0-9/69538116_2184383068525054_5218256411326152704_n.png?_nc_cat=100&ccb=2&_nc_sid=09cbfe&_nc_eui2=AeEvcxU1mPyZatD-6Kd2PmQn5Kv2i40-TZXkq_aLjT5NlZmZ19YuRnGODSEnNjrqrH8&_nc_ohc=qNN1SOdeDpAAX8PUpJu&_nc_ht=scontent.fjal2-1.fna&oh=f9ca4560a5e454501d8366be7aafb354&oe=5FBCCE74)></div></div><div><div><ul id=dvfec><li>Fecha</li><li>21/10/2020</li></ul></div>";
            texto = texto + "<div id=dvtb><ul><li><ul><li><div class=un>Cliente</div></li><li><div class=dos>" + valor + "</div></li></ul>";
            texto = texto + "</li><li><ul><li><div class=un>Concepto</div></li><li><div class=dos>Pago de viaje</div></li></ul></li><li><ul><li><div class=un>Celular de contacto</div>";
            texto = texto + "</li><li><div class=dos>" + valor + "</div></li></ul></li><li><ul><li><div class=un>Email</div></li><li><div class=dos>" + valor + "</div></li></ul></li>";
            texto = texto + "<li><ul><li><div class=un>Tour</div></li><li><div class=dos>" + valor + "</div></li></ul></li><li><ul><li><div class=un>Número de viajeros</div></li><li>";
            texto = texto + "<div class=dos>" + valor + "</div></li></ul></li><li><ul><li><div class=un>Fecha de Salida</div></li><li><div class=dos>" + valor + "</div></li></ul></li><li><ul><li>";
            texto = texto + "<div class=un>Lugar de Salida</div></li><li><div class=dos>" + valor + "</div></li></ul></li><li><ul><li><div class=un>Monto de la operación</div></li><li>";
            texto = texto + "<div class=dos>" + valor + "</div></li></ul></li><li><ul><li><div class=un>Monto con letra</div></li><li><div class=dos>" + valor + "</div></li></ul></li></ul></div>";
            texto = texto + "<p></p><div id=dvFoot><ul id=dvIz><li>Delfino Valenzuela 430</li><li>Col. Rafael Lucio, Xalapa, Ver.</li><li>Servicio.travelok@outlook.com</li><li>Telefono 228 290 0192</li>";
            texto = texto + "<li>Facebook: traveelok</li></ul><ul id=dvDer><li>Muchas gracias por su pago.</li><li id=dvFirm></li><li><u>Antony Alan García García</u></li><li>Gerente General</li>";
            texto = texto + "</ul></div></section></body></html>";
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            var mail = new MailMessage();
            mail.From = new MailAddress("a.066@hotmail.com");
            mail.To.Add("ecolio@uv.mx");
            mail.Subject = "Test Mail - 1";
            mail.IsBodyHtml = true;
            mail.Body = texto;
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("a.066@hotmail.com", "MustangGT_500705");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
    }
}