using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class cmDeudaViajeros
    {
        public int? idViaje { get; set; }
        public string sUsuario { get; set; }
        public string sDestino { get; set; }
        public DateTime? dtFechaSalida { get; set; }
        public decimal? dCostoViajero { get; set; }
        public decimal? dTotal { get; set; }
        public decimal? dAdeudo { get; set; }
    }
}
