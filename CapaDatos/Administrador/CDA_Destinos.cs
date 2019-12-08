using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Administrador
{
    public class CDA_Destinos
    {

        public bool bInsertaDestino(cmDestinos CDestino)
        {
            //using (var contexto = new TravelOKViajesEntities())//local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                try
                {
                    if (contexto.spiInsertaDestino(CDestino.sDestino, CDestino.sTitulo, CDestino.sSubTit, CDestino.sDescrip, CDestino.bPrincipal) == -1)

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


        public bool bEliminaDestino_Id(int idDestino)
        {
            //using (var contexto = new TravelOKViajesEntities())//local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                try
                {
                    if (contexto.spdEliminaDestinoId(idDestino) == -1)
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
