using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class cmComunidad
    {
        public int IdComunidad { get; set; }
        public int IdViaje { get; set; }
        public string sNombre { get; set; }
        public string sTestimonio { get; set; }
        public decimal? iCalificacion { get; set; }
        public string dtFechaRegistro { get; set; }
        public string sDestino { get; set; }
        public byte[] ImgDestino { get; set; }
    }
}
