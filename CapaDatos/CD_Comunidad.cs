using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Comunidad
    {
        public bool bInsertaComunidad(cmComunidad datosCom)
        {
            bool bInsertado = false;
            //using (var contexto = new TravelOKViajesEntities())//local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                try
                {
                    if (contexto.spInsertaComunidad(datosCom.sNombre, datosCom.sTestimonio, datosCom.IdViaje, datosCom.iCalificacion, datosCom.ImgDestino) == -1)
                        bInsertado = true;
                }catch(Exception x)
                {
                    bInsertado = false;
                }
            }
            return bInsertado;
        }

        public List<cmComunidad> lsObtieneComunidad()
        {
            List<cmComunidad> lsComunidad = new List<cmComunidad>();
            //using(var contexto = new TravelOKViajesEntities())//Local
            using (var contexto = new TravelOKEntitiesQA())//QA
            {
                lsComunidad = (from tblComunidad in contexto.spObtieneComunidad()
                               select new cmComunidad
                               {
                                   IdComunidad = tblComunidad.IdExp,
                                   sNombre = tblComunidad.Nombre,
                                   sTestimonio = tblComunidad.Testimonio,
                                   iCalificacion = tblComunidad.Calificacion,
                                   IdViaje = tblComunidad.IdDestino,
                                   sDestino = tblComunidad.Destino,
                                   dtFechaRegistro = tblComunidad.ActivityDate
                               }
                               ).ToList();
            }
            return lsComunidad;
        }
    }
}
