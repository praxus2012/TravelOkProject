using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Administrador
{
    public class CDA_Costos
    {

        public List<TO_Habitaciones> lsObtieneHabitacCostos(int idSalida, int idDestino)
        {
            List<TO_Habitaciones> lsHabitaciones = new List<TO_Habitaciones>();
            // using (var contexto = new TravelOKEntities())//local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                try
                {
                    //     lsHabitaciones = contexto.spsObHabitacCostos(CCostos.IdSalida, CCostos.IdDestino).Select;
                    lsHabitaciones = (from habitaciones in contexto.spsObHabitacCostos(idSalida, idDestino)
                                      select new TO_Habitaciones
                                      {
                                          IdTipoHab = habitaciones.IdTipoHab,
                                          nvDescripcion = habitaciones.nvDescripcion
                                      }).ToList();
                }
                catch (Exception x)
                {
                    x.GetHashCode();
                    return null;
                }
            }
            return lsHabitaciones;
        }


        public bool bInsertaCosto(cmCostos CCostos)
        {
            //using (var contexto = new TravelOKEntities())//local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                try
                {
                    if (contexto.spiInsertaCosto(CCostos.dCostoLugar, CCostos.IdDestino, CCostos.IdSalida, CCostos.IdHabitacion, CCostos.sTipoPersona) == -1)

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



        public bool bEliminaCosto(cmCostos CCostos)
        {
            //using (var contexto = new TravelOKEntities())//local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                try
                {
                    if (contexto.spdEliminaCosto(CCostos.IdSalida, CCostos.IdDestino, CCostos.IdHabitacion) == -1)
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

        public TO_Costo lsObtieneCosto(cmCostos CCostos)
        {
            TO_Costo tCostos = new TO_Costo();
            // using (var contexto = new TravelOKViajesEntities())//local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                try
                {                   
                    tCostos = (from costos in contexto.TO_Costo
                                where costos.IdSalida==CCostos.IdSalida
                                && costos.IdDestino==CCostos.IdDestino
                                && costos.IdHabitacion==CCostos.IdHabitacion
                                && CCostos.sTipoPersona==CCostos.sTipoPersona
                                select new TO_Costo
                                      {
                                         CostoLugar = costos.CostoLugar,                                    
                                         TipoPersona = costos.TipoPersona

                                }).FirstOrDefault();
                }
                catch (Exception x)
                {
                    x.GetHashCode();
                    return null;
                }
            }
            return tCostos;
        }


    }
}
