using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class cmViajeros
    {
        public int idViaje { get; set; }
        public string sSalida { get; set; }
        public string sDestino { get; set; }
        public string idUsuario { get; set; }
        public string sNombre { get; set; }
        public string sApellido { get; set; }
        public string sCorreo { get; set; }
        public int iEdad { get; set; }
        public int iAsiento { get; set; }
        public string sTelefono { get; set; }
        public DateTime dtFechaRegistro { get; set; }
        public decimal  dCostoTotal { get; set; }
        public string sOpcionTour { get; set; }
        public decimal dPagado { get; set; }
        public decimal dDeuda { get; set; }

    }
}
