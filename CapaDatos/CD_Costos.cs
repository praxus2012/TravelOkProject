using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class CD_Costos 
    {
        public List<TO_Habitaciones> lsObtieneHabitaciones()
        {
            List<TO_Habitaciones> lsHabitaciones = new List<TO_Habitaciones>();
            //using (var contexto = new TravelOKViajesEntities())//local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                lsHabitaciones = contexto.TO_Habitaciones.ToList();
            }
            return lsHabitaciones;
        }
    }
}
