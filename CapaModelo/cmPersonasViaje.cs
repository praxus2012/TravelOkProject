using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class cmPersonasViaje
    {
        public int Folio { get; set; }
        public string Ciudad { get; set; }
        public string Destino { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int? Asiento { get; set; }
        public string Telefono { get; set; }
        public decimal? Costo { get; set; }
        public decimal? Abonado { get; set; }
        public decimal? Deuda { get; set; }
        public string sFechaReg { get; set; }
    }
}
