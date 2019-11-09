using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Administrador
{
    public class CDA_CarruselDestino
    {
        public bool bInsertaCarruselDestino(cmCarruselDestino CaDestino)
        {
            using (var contexto = new TravelOKViajesEntities())//local
            //using (var contexto = new TravelOKEntitiesQA())//QA
            {
                try
                {
                    if (contexto.spiInsertaDetalleDestino(CaDestino.iDestino, CaDestino.sRutaImg, CaDestino.sDescripcion, CaDestino.bActivo) == -1)
                        return true;
                    return false;
                }
                catch (Exception x)
                {
                    return false;
                }
            }
        }
    }
}
