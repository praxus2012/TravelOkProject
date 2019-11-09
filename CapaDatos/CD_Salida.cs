using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Salida
    {
        public List<TO_Salida> lsObtieneSalidas()
        {
            List<TO_Salida> lsSalidas = new List<TO_Salida>();
            using(var contexto = new TravelOKViajesEntities())//Local
            //using (var contexto = new TravelOKEntitiesQA())//QA
            {
                lsSalidas = contexto.TO_Salida.ToList();
            }
            return lsSalidas;
        }
    }
}
