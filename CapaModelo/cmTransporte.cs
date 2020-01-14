using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class cmTransporte
    {
        public int IdTransporte { get; set; }
        public int? NumAsientos { get; set; }
        public bool? FilaTrasera { get; set; }
        public int? NumAsTrasera { get; set; }
        public int? NumColPrin { get; set; }
        public int? NumColUno { get; set; }
        public int? NumFilColUno { get; set; }
        public bool? PrimFilColUnoDif { get; set; }
        public int? NumAsFilCUnoDif { get; set; }
        public int? NumColDos { get; set; }
        public int? NumFilcolDos { get; set; }
        public bool? PrimFilColDosDif { get; set; }
        public int? NumAsFilCDosDif { get; set; }
        public int? NumSani { get; set; }
        public bool? SaniTrasero { get; set; }
        public bool? SanMedio { get; set; }
        public int? NumFilSanM { get; set; }
    }
}
