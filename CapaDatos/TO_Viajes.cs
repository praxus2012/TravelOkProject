//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class TO_Viajes
    {
        public int IdViaje { get; set; }
        public int Id_Destino { get; set; }
        public int Id_Salida { get; set; }
        public Nullable<System.DateTime> dtFechaSalida { get; set; }
        public Nullable<int> IdTransporte { get; set; }
    
        public virtual TO_Destino TO_Destino { get; set; }
        public virtual TO_Salida TO_Salida { get; set; }
        public virtual TO_Transporte TO_Transporte { get; set; }
    }
}
