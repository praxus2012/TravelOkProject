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

        public List<cmTranspCat> fnlsObtieneTransportes()
        {
            using (var contexto = new TravelOKEntitiesQA())
            {
                List<cmTranspCat> lsTrans = new List<cmTranspCat>();

                lsTrans =contexto.TO_Transporte
                        .Select(tran => new cmTranspCat
                        {
                            idTransporte = tran.IdTransporte,
                            sNomTransp = tran.nvNombre,
                            iNumAsientos = (int)tran.NumAsientos
                        })
                        .ToList();
                return lsTrans;
            }
        }

        public List<int?> fnlsObtieneOcupados(int idViaje)
        {
            using (var contexto = new TravelOKEntitiesQA())
            {
                return (from TO_Viajeros vjr in contexto.TO_Viajeros
                        where vjr.IdViaje == idViaje
                        select vjr.Asiento
                        ).Union(
                            (from TO_Viajes v1 in contexto.TO_Viajes
                             join TO_Viajeros via in contexto.TO_Viajeros on v1.IdViaje equals via.IdViaje
                             where v1.iRelacion == (contexto.TO_Viajes.Where(v2=>v2.IdViaje==idViaje).Select(v2=>v2.iRelacion)).FirstOrDefault() 
                             && v1.IdViaje != idViaje select via.Asiento)).ToList();
            }
        }
    }
}
