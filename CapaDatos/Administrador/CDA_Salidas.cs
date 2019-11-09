using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Administrador
{
    public class CDA_Salidas
    {

        public bool bEliminaSalidaId(int idSalida)
        {
            using(var contexto= new TravelOKViajesEntities())//local
            //using (var contexto = new TravelOKEntitiesQA())//QA
            {
                try
                {
                    if (contexto.spdEliminaSalidaId(idSalida) == -1)
                    {
                        return true;
                    }
                    return false;
                }
                catch(Exception x)
                {
                    throw x;
                }
            }
        }

        public bool bEliminaSalidaCiudad(string sCiudad)
        {
            using (var contexto = new TravelOKViajesEntities())//local
            //using (var contexto = new TravelOKEntitiesQA())//QA
            {
                try
                {
                    if (contexto.spdEliminaSalida(sCiudad) == -1)
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
        public bool bInsertaSalida(string sSalida)
        {
            using (var contexto = new TravelOKViajesEntities())//local
            //using (var contexto = new TravelOKEntitiesQA())//QA
            {
                try
                {
                    if (contexto.spiInsertaSalida(sSalida) == -1)
                        return true;
                    return false;
                }
                catch (Exception x)
                {
                    return false;
                }
            }
        }


    }
}
