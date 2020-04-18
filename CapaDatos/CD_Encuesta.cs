using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Encuesta
    {
        public List<TO_Encuesta> fnlsObtienePreguntas()
        {
            using (var context = new TravelOKEntitiesQA())
            {
                return context.TO_Encuesta.ToList();
            }
        }
    }
}
