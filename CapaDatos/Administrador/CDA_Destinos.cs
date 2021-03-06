﻿using CapaModelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Administrador
{
    public class CDA_Destinos
    {

        public bool bInsertaDestino(cmDestinos CDestino)
        {
            //using (var contexto = new TravelOKEntities())//local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["ftpUsr"], ConfigurationManager.AppSettings["ftpPass"]);
                        client.UploadFile("ftp://"+ ConfigurationManager.AppSettings["ftpHost"] + "/travel/Img/", WebRequestMethods.Ftp.UploadFile, "D:\\Imagenes\\Saved Pictures\\sunset.jpg");
                    }

                    if (contexto.spiInsertaDestino(CDestino.sDestino, CDestino.sTitulo, CDestino.sSubTit, CDestino.sDescrip,CDestino.sRutaRec,CDestino.sRutaItin,CDestino.sRutaGuia, CDestino.bPrincipal) == -1)
                        return true;
                    return false;
                }
                catch (Exception x)
                {
                    x.GetHashCode();
                    return false;
                }
            }
        }


        public bool bEliminaDestino_Id(int idDestino)
        {
            //using (var contexto = new TravelOKEntities())//local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                try
                {
                    if (contexto.spdEliminaDestinoId(idDestino) == -1)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception x)
                {
                    throw x;
                }
            }
        }
    }
}
