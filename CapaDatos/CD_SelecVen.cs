using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_SelecVen
    {
        public List<cmCostos> fnlsObtieneDestinosDet()
        {
            using (var contexto = new TravelOKEntitiesQA())
            {
                List<cmCostos> LsDesVenta = new List<cmCostos>();
                LsDesVenta = (from destinos in contexto.spsObtieneDestinosDet1()
                              select new cmCostos
                              {
                                  IdDestino = destinos.idviaje,
                                  sDestino = destinos.Destino,
                                  dCostoLugar = destinos.costolugar
                                  
                              }).ToList();
                return LsDesVenta;
            }
        }
    }
}
