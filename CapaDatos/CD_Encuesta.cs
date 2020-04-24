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

        public bool fnbInsertaEncuesta(List<TO_EncuestaResp> lsEncuestaRes)
        {
            try
            {
                using (var context = new TravelOKEntitiesQA())
                {
                    foreach (TO_EncuestaResp oEncRes in lsEncuestaRes)
                    {
                        context.TO_EncuestaResp.Add(oEncRes);
                    }
                    context.SaveChanges();
                    return true;
                }
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
