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

        public List<TO_Habitaciones> lsObtieneHabitacCostos(cmCostos CCostos)
        {
            List<TO_Habitaciones> lsHabitaciones = new List<TO_Habitaciones>();
            // using (var contexto = new TravelOKViajesEntities())//local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                try
                {                    
                        lsHabitaciones = spsObHabitacCostos(CCostos.IdDestino, CCostos.IdSalida);                   
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
            //using (var contexto = new TravelOKViajesEntities())//local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                try
                {
                    if (contexto.spiInsertaCosto(CCostos.dCostoLugar, CCostos.IdDestino, CCostos.IdSalida, CCostos.IdHabitación, CCostos.sTipoPersona) == -1)

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
            //using (var contexto = new TravelOKViajesEntities())//local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                try
                {
                    if (contexto.spdEliminaCosto(CCostos.IdSalida,CCostos.IdDestino,CCostos.IdHabitación) == -1)
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
