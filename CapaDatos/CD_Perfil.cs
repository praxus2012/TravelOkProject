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
                    lsDeudaViaje = contexto.spsObtInfoDeudaViajero(sUsuario).Select(
                        deuda => new cmDeudaViajeros
                        {
                            sUsuario = sUsuario,
                            dAdeudo = deuda.Adeudo,
                            dCostoViajero = deuda.CostoPorViajero,
                            dtFechaSalida = deuda.dtFechaSalida,
                            dTotal = deuda.Total,
                            idViaje = deuda.IdViaje,
                            sDestino = deuda.Destino
                        }).ToList();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return lsDeudaViaje;
        }

        public bool fnbActualizaPago(cmInsertaPago oPago)
        {
            List<TO_Viajeros> lsViajeros = new List<TO_Viajeros>();
            try
            {
                using (var contexto = new TravelOKEntitiesQA())//QA
                {
                    lsViajeros = contexto.TO_Viajeros.Where(vi => vi.IdViaje == oPago.idViaje && vi.IdUsuario == oPago.idUsuario).ToList();
                    foreach (TO_Viajeros oVia in lsViajeros)
                    {
                        oVia.Pago = oPago.Archivo;
                    }
                    contexto.SaveChanges();
                }
                return true;
            }catch(Exception ex)
            {
                string esx = ex.Message;
                string inner = ex.InnerException.Message;
                return false;
                throw ex;
            }
        }
    }
}
