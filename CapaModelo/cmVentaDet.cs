using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class cmVentaDet
    {
        public int idVenta { get; set; }
        public int idSalida { get; set; }
        public string sSalida { get; set; }
        public int idDestino { get; set; }
        public string sDestino { get; set; }
        public DateTime? dtFecha { get; set; }
        public int? idTransporte { get; set; }
    }
}
