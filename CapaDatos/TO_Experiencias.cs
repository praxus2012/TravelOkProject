//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class TO_Experiencias
    {
        public int IdExp { get; set; }
        public string Nombre { get; set; }
        public string Testimonio { get; set; }
        public int IdDestino { get; set; }
        public Nullable<System.DateTime> ActivityDate { get; set; }
        public Nullable<decimal> Calificacion { get; set; }
        public byte[] ImgDestino { get; set; }
    
        public virtual TO_Destino TO_Destino { get; set; }
    }
}
