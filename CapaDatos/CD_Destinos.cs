using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Destinos
    {
        public List<TO_Destino> lsObtieneDestinos()
        {
            List<TO_Destino> lsDestinos = new List<TO_Destino>();
           // using (var contexto = new TravelOKEntities())//local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                lsDestinos = contexto.TO_Destino.Where(Des => Des.bActivo==true).ToList();
            }
            return lsDestinos;
        }
        public List<TO_Destino> lsObtieneDestinosTodo()
        {
            List<TO_Destino> lsDestinos = new List<TO_Destino>();
            // using (var contexto = new TravelOKEntities())//local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                lsDestinos = contexto.TO_Destino.ToList();
            }
            return lsDestinos;
        }

        public List<cmDestinos> lsObtieneImgDestinos()
        {
            List<cmDestinos> lsDestinosImg = new List<cmDestinos>();
            //using (var contexto = new TravelOKEntities())//local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                lsDestinosImg = (from des in contexto.spsObtieneDestinosImg()
                                 select
new cmDestinos
{
idViaje = des.idViaje,
sDescrip = des.sDescrip,
sRutaImg = des.sRutaImg,
sSubTit = des.sSubTit,
sTitulo = des.sTitulo
}).ToList();
            }
            return lsDestinosImg;
        }

        /* */
        public List<cmCarruselDestino> cmObtieneCarrDestino(cmDestinos Destino)
        {
            List<cmCarruselDestino> CarrDest = null;
            //using (var contexto = new TravelOKEntities())
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                CarrDest = (from sp in contexto.spsObtieneCarrusel(Destino.idViaje)
                            select new cmCarruselDestino
                            {
                                iDestino = sp.Id_Detalle,
                                sDescripcion = sp.Destino,
                                sRutaImg = sp.nvRutaArchivo
                            }).ToList();
            }
            return CarrDest;
        }
        public cmDestinos cmObtieneImgDestinos(cmDestinos Destino)
        {
            //using (var contexto = new TravelOKEntities())//local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                Destino = (from des in contexto.spsObtieneDestinoDet(Destino.idViaje)
                           select
                              new cmDestinos
                              {
                                  idViaje = des.idViaje,
                                  sDescrip = des.sDescrip,
                                  sRutaImg = des.sRutaImg,
                                  sSubTit = des.sSubTit,
                                  sTitulo = des.sTitulo,
                                  sRutaItin = des.sIntin,
                                  sRutaGuia = des.sGuia,
                                  sRutaRec = des.sRec
                              }).FirstOrDefault();
            }
            return Destino;
        }
    }
}
