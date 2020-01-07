using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Transporte
    {
        public cmTransporte fnoObtieneTransporte(cmVentaDet oVenTrans)
        {
            using(var contexto = new TravelOKEntitiesQA())
            {
                oVenTrans.idTransporte = 0;
                oVenTrans = contexto.TO_Viajes.Where(ven => ven.IdViaje == oVenTrans.idVenta).Select(
                    ven => new cmVentaDet
                    {
                        idVenta = ven.IdViaje,
                        idTransporte = ven.IdTransporte
                    }
                    ).FirstOrDefault();
                if(oVenTrans.idTransporte!= 0)
                {
                    return contexto.TO_Transporte
                        .Where(tran => tran.IdTransporte == oVenTrans.idTransporte)
                        .Select(tran => new cmTransporte
                        {
                            IdTransporte = tran.IdTransporte,
                            FilaTrasera = tran.FilaTrasera,
                            NumAsFilCDosDif = tran.NumAsFilCDosDif,
                            NumAsFilCUnoDif = tran.NumAsFilCUnoDif,
                            NumAsientos = tran.NumAsientos,
                            NumAsTrasera = tran.NumAsTrasera,
                            NumColDos = tran.NumColDos,
                            NumColPrin = tran.NumColPrin,
                            NumColUno = tran.NumColUno,
                            NumFilcolDos = tran.NumFilcolDos,
                            NumFilColUno = tran.NumFilColUno,
                            NumFilSanM = tran.NumFilSanM,
                            NumSani = tran.NumSani,
                            PrimFilColDosDif = tran.PrimFilColDosDif,
                            PrimFilColUnoDif = tran.PrimFilColUnoDif,
                            SaniTrasero = tran.SaniTrasero,
                            SanMedio = tran.SanMedio
                        })
                        .FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
