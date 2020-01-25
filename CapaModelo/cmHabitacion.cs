using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class cmHabitacion
    {
        public int idTipoHab { get; set; }
        public string nvDescripcion { get; set; }
        public int icapMax { get; set; }
        public int inumHab { get; set; }
        public decimal dCosto { get; set; }
        public int idViaje { get; set; }
        public int iPasajeros { get; set; }
        public int iDecremento { get; set; }

    }
}
