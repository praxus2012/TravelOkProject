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
           // using(var contexto = new TravelOKEntities())//Local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                lsSalidas = contexto.TO_Salida.Where(sal => sal.bActivo==true).ToList();
            }
            return lsSalidas;
        }
        public List<TO_Salida> lsObtieneSalidasViajes()
        {
            List<TO_Salida> lsSalidas = new List<TO_Salida>();
            // using(var contexto = new TravelOKEntities())//Local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                lsSalidas = (from sal in contexto.TO_Salida
                             join via in contexto.TO_Viajes on sal.IdSalida equals via.Id_Salida
                             select sal).ToList();
            }
            return lsSalidas;
        }
        public List<TO_Salida> lsObtieneSalidasTodo()
        {
            List<TO_Salida> lsSalidas = new List<TO_Salida>();
            // using(var contexto = new TravelOKEntities())//Local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                lsSalidas = contexto.TO_Salida.ToList();
            }
            return lsSalidas;
        }
    }
}
