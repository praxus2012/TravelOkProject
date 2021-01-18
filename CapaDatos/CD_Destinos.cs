using CapaModelo;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos
{
    public class CD_Destinos
    {
        private TravelOKEntitiesQA travelContext = new TravelOKEntitiesQA();
        //private TravelOKEntities travelContext = new TravelOKEntities();
        public List<TO_Destino> lsObtieneDestinos()
        {
            return travelContext.TO_Destino.Where(Des => Des.bActivo == true).ToList();
        }

        public List<TO_Destino> lsObtieneDestinosTodo()
        {
            return travelContext.TO_Destino.ToList();
        }

        public List<cmDestinos> lsObtieneImgDestinos()
        {
            return (from des in travelContext.spsObtieneDestinosImg()
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

        public List<cmCarruselDestino> cmObtieneCarrDestino(cmDestinos Destino)
        {
            return (from sp in travelContext.spsObtieneCarrusel(Destino.idViaje)
                    select new cmCarruselDestino
                    {
                        iDestino = sp.Id_Detalle,
                        sDescripcion = sp.Destino,
                        sRutaImg = sp.nvRutaArchivo
                    }).ToList();
        }
        public cmDestinos cmObtieneImgDestinos(cmDestinos Destino)
        {
            return (from des in travelContext.spsObtieneDestinoDet(Destino.idViaje)
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
        public TO_Destino obtenerNombreDestino(int idDestino)
        {
            return new TO_Destino()
            {
                Destino = travelContext.TO_Destino.First(p => p.IdViaje == idDestino).Destino
            };
        }

        public string obtenerNombreDestino2(int idDestino)
        {
            return travelContext.TO_Destino.First(p => p.IdViaje == idDestino).Destino;
        }
    }
}
