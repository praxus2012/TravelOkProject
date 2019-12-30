using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_DetVenta
    {
        public List<cmVentaDet> fnlsRecuperaSalidaDes(cmVentaDet oDestino)
        {
            using (var contexto = new TravelOKViajesEntities())
            {
                List<cmVentaDet> LsSalVenta = new List<cmVentaDet>();
                LsSalVenta = (from salida in contexto.spsObtLugarSalViajesDest(oDestino.idDestino)
                              select new cmVentaDet
                              {
                                  idSalida = salida.Id_salida,
                                  sSalida = salida.Ciudad
                              }).ToList();
                return LsSalVenta;
            }
        }
    }
}
