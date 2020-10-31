using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Viajes
    {
        public List<cmVentaDet> fnlsRecuperaSalida()
        {
            using(var contexto = new TravelOKEntitiesQA())
            {
                List<cmVentaDet> LsSalVenta = new List<cmVentaDet>();
                LsSalVenta = (from salida in contexto.spsObtLugarSalidaViajes()
                              select new cmVentaDet
                              {
                                  idSalida = salida.Id_salida,
                                  sSalida = salida.Ciudad
                              }).ToList();
                return LsSalVenta;
            }
        }

        public List<cmVentaDet> fnlsRecuperaDestino(cmVentaDet oVenSal)
        {
            using (var contexto = new TravelOKEntitiesQA())
            {
                List<cmVentaDet> LsDesVenta = new List<cmVentaDet>();
                LsDesVenta = (from salida in contexto.spsObtLugarDestinoViajes(oVenSal.idSalida)
                              select new cmVentaDet
                              {
                                  idDestino = salida.Id_Destino,
                                  sDestino = salida.Destino
                              }).ToList();
                return LsDesVenta;
            }
        }

        public List<cmVentaDet> fnlsRecuperaFechaVen(cmVentaDet oVenSal)
        {
            using (var contexto = new TravelOKEntitiesQA())
            {
                List<cmVentaDet> LsDesVenta = new List<cmVentaDet>();
                LsDesVenta = (from salida in contexto.spsObtFechaViajes(oVenSal.idSalida,oVenSal.idDestino)
                              select new cmVentaDet
                              {
                                  idVenta = salida.IdViaje,
                                  dtFecha = salida.dtFechaSalida
                              }).ToList();
                return LsDesVenta;
            }
        }


        public TO_Viajes obtenerViaje(int idViaje)
        {

            TO_Viajes viaje = null;

            using (var Contexto = new TravelOKEntitiesQA())
            {

                var viajeEncontrado = Contexto.TO_Viajes.First(p => p.IdViaje == idViaje);

                viaje = new TO_Viajes()
                {
                    Id_Destino = viajeEncontrado.Id_Destino,
                    dtFechaSalida = viajeEncontrado.dtFechaSalida

                };



            }

            return viaje;

        }


    }
}
