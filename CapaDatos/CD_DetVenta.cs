using CapaModelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_DetVenta
    {
        public List<cmVentaDet> fnlsRecuperaSalidaDes(cmVentaDet oDestino)
        {
            using (var contexto = new TravelOKEntities())
            {
                List<cmVentaDet> LsSalVenta = new List<cmVentaDet>();
                LsSalVenta = (from salida in contexto.spsObtLugarSalViajesDest(oDestino.idDestino)
                              select new cmVentaDet
                              {
                                  idSalida = salida.Id_salida,
                                  sSalida = salida.Ciudad
                              }).ToList();
                return LsSalVenta;
            }
        }

        public List<cmHabitacion> fnlsRecuperaOpciones(cmHabitacion oHabitacion)
        {
            List<cmHabitacion> LsOpcioHab = new List<cmHabitacion>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SQLConn"]))
            {
                using (SqlCommand cmd = new SqlCommand("spsObtPropuestas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IdViaje", SqlDbType.VarChar).Value = oHabitacion.idViaje;
                    cmd.Parameters.Add("@Total", SqlDbType.VarChar).Value = oHabitacion.iPasajeros;
                    cmd.Parameters.Add("@Decremento", SqlDbType.VarChar).Value = oHabitacion.iDecremento;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        LsOpcioHab.Add(new cmHabitacion
                        {
                            idTipoHab = rdr.GetInt32(0),
                            nvDescripcion = rdr.GetString(1),
                            icapMax = rdr.GetInt32(2),
                            inumHab = rdr.GetInt32(3),
                            dCosto = rdr.GetDecimal(4)
                        });
                    }
                }
            }
            return LsOpcioHab;


           /* using (var contexto = new TravelOKEntitiesQAModelEntities())
            {
                List<cmHabitacion> LsOpcioHab = new List<cmHabitacion>();
                //LsOpcioHab = (from salida in contexto.spsObtPropuestas(oHabitacion.idViaje,oHabitacion.iPasajeros,oHabitacion.iDecremento)).ToList();
            }*/
        }
    }
}
