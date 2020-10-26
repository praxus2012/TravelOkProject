using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Viajeros
    {
        public bool InsertaViajeros(List<cmViajeros> oViajeros)
        {
            bool bCorrecto = true;
            using (var contexto = new TravelOKEntitiesQA())
            {
                try
                {
                    foreach (cmViajeros oViajero in oViajeros)
                    {
                        contexto.TO_Viajeros.Add(new TO_Viajeros
                        {
                            IdUsuario = oViajero.idUsuario,
                            IdViaje = oViajero.idViaje,
                            NombreAsistente = oViajero.sNombre,
                            ApAsistente = oViajero.sApellido,
                            Asiento = oViajero.iAsiento,
                            Correo = oViajero.sCorreo,
                            CostoTotal = oViajero.dCostoTotal,
                            Edad = oViajero.iEdad,
                            FechaRegistro = DateTime.Now,
                            Telefono = oViajero.sTelefono,
                            Pagado = 0,
                            Confirmado = false
                        });
                    }
                    contexto.SaveChanges();
                }catch(Exception ex)
                {
                    bCorrecto = false;
                }
            }
            return bCorrecto;
        }

        public bool ConfirmarViaje(string sUsuario)
        {
            bool bCorrecto = true;
            using (var contexto = new TravelOKEntitiesQA())
            {
                try
                {
                    List<TO_Viajeros> lsViajeros = contexto.TO_Viajeros.Where(via => via.IdUsuario.Equals(sUsuario)
                     && via.Confirmado == false).ToList();
                    foreach(TO_Viajeros viajero in lsViajeros)
                    {
                        viajero.Confirmado = true;
                    }
                    contexto.SaveChanges();
                }
                catch (Exception ex)
                {
                    bCorrecto = false;
                }
            }
            return bCorrecto;
        }
        public bool ConfirmarViaje(string sUsuario, decimal dPago)
        {
            bool bCorrecto = true;
            using (var contexto = new TravelOKEntitiesQA())
            {
                try
                {
                    List<TO_Viajeros> lsViajeros = contexto.TO_Viajeros.Where(via => via.IdUsuario.Equals(sUsuario)
                     && via.Confirmado == false).ToList();
                    foreach (TO_Viajeros viajero in lsViajeros)
                    {
                        viajero.Pagado = dPago;
                        viajero.Confirmado = true;
                    }
                    contexto.SaveChanges();
                }
                catch (Exception ex)
                {
                    bCorrecto = false;
                }
            }
            return bCorrecto;
        }

        public void LimpiaViajeros()
        {
            using (var contexto = new TravelOKEntitiesQA())
            {
                try
                {
                    List<TO_Viajeros> lsViajeros = contexto.TO_Viajeros.Where(via => via.Confirmado == false).ToList();
                    contexto.TO_Viajeros.RemoveRange(lsViajeros);
                    contexto.SaveChanges();
                }
                catch (Exception ex)
                {
                }
            }
        }

        public List<cmPersonasViaje> ObtenerViajeros(TO_Viajes oViajes)
        {
            List<cmPersonasViaje> oLsViajeros = new List<cmPersonasViaje>();
            using (var contexto = new TravelOKEntitiesQA())
            {
                try
                {
                    oLsViajeros = contexto.spsObtieneViajeros(oViajes.IdViaje).Select(v => new cmPersonasViaje
                    {
                        Folio = v.Folio,
                        Nombre = v.Nombre,
                        Asiento = v.Asiento,
                        Ciudad = v.Ciudad,
                        Correo = v.Correo,
                        Destino=v.Destino,
                        Telefono = v.Telefono,
                        Usuario=v.IdUsuario,
                        Abonado=v.Pagado,
                        Deuda=v.Deuda,
                        Costo=v.CostoTotal,
                        sFechaReg=v.FechaRegistro.ToString()
                    }).ToList();
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return oLsViajeros;
        }
    }
}
