using CapaModelo;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public bool fnbInsertaViajes(List<TO_Viajes> lsViajes)
        {
            using (var Contexto = new TravelOKEntitiesQA())
            {
                try
                {
                    if (lsViajes.Count > 0)
                    {
                        if (Contexto.TO_Viajes.Where(v => v.iRelacion != null).Count() > 0 && lsViajes.Count>1)
                            lsViajes = lsViajes.Select(lv => { lv.iRelacion = (Contexto.TO_Viajes.Max(v => v.iRelacion+1)); return lv; }).ToList();
                        else
                            lsViajes = lsViajes.Select(lv => { lv.iRelacion = 1; return lv; }).ToList();
                    }
                    Contexto.TO_Viajes.AddRange(lsViajes);
                    Contexto.SaveChanges();
                    return true;
                }catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public List<cmViajeElimina> fnlsObtViajeElimina()
        {
            List<cmViajeElimina> lsViajE = new List<cmViajeElimina>();
            using (var contexto = new TravelOKEntitiesQA())
                lsViajE = (from TO_Viajes vi in contexto.TO_Viajes
                        join TO_Destino des in contexto.TO_Destino on vi.Id_Destino equals des.IdViaje
                        join TO_Salida sal in contexto.TO_Salida on vi.Id_Salida equals sal.IdSalida
                        select new cmViajeElimina
                        {
                            idViaje = vi.IdViaje,
                            sDestT = des.Destino,
                            sSalT = sal.Ciudad,
                            sFReT = vi.dtFechaLleg,
                            sFSaT = vi.dtFechaSalida
                        }).ToList();
            return lsViajE.Select(via =>
            {
                via.sDescViaje = "Destino: " + via.sDestT + " - Salida: " + via.sSalT + " - FecSal: " +
                ((DateTime)via.sFSaT).ToString("g", CultureInfo.CreateSpecificCulture("fr-FR")) + " - FecReg: " + ((DateTime)via.sFReT).ToString("g", CultureInfo.CreateSpecificCulture("fr-FR"));
                return via;
            }).ToList();
        }

        public List<cmViajeElimina> fnlsObtViajeEliminaA()
        {
            List<cmViajeElimina> lsViajE = new List<cmViajeElimina>();
            using (var contexto = new TravelOKEntitiesQA())
                lsViajE = (from TO_Viajes vi in contexto.TO_Viajes
                           join TO_Destino des in contexto.TO_Destino on vi.Id_Destino equals des.IdViaje
                           join TO_Salida sal in contexto.TO_Salida on vi.Id_Salida equals sal.IdSalida
                           where 
                           vi.dtFechaSalida>DateTime.Now
                           select new cmViajeElimina
                           {
                               idViaje = vi.IdViaje,
                               sDestT = des.Destino,
                               sSalT = sal.Ciudad,
                               sFReT = vi.dtFechaLleg,
                               sFSaT = vi.dtFechaSalida
                           }).ToList();
            return lsViajE.Select(via =>
            {
                via.sDescViaje = "Destino: " + via.sDestT + " - Salida: " + via.sSalT + " - FecSal: " +
                ((DateTime)via.sFSaT).ToString("g", CultureInfo.CreateSpecificCulture("fr-FR")) + " - FecReg: " + ((DateTime)via.sFReT).ToString("g", CultureInfo.CreateSpecificCulture("fr-FR"));
                return via;
            }).ToList();
        }

        public bool fnbBorrarViaje(int idViaje)
        {
            try
            {
                using (var contexto = new TravelOKEntitiesQA())
                {
                    TO_Viajes viaj = contexto.TO_Viajes.Where(vi => vi.IdViaje == idViaje).FirstOrDefault();
                    contexto.TO_Viajes.Remove(viaj);
                    contexto.SaveChanges();
                    return true;
                }
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
