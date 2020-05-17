using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Perfil
    {
        public List<cmDeudaViajeros> fnlsRecuperaInfo(string sUsuario)
        {
            List<cmDeudaViajeros> lsDeudaViaje = new List<cmDeudaViajeros>();
            try
            {
                using (var contexto = new TravelOKEntitiesQA())//QA
                {
                    
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return lsDeudaViaje;
        }
    }
}
