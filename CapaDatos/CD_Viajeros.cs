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
                            Telefono = oViajero.sTelefono
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
    }
}
