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
    
    public partial class TO_EncuestaResp
    {
        public int IdResEnc { get; set; }
        public string NombrePersona { get; set; }
        public int IdPregunta { get; set; }
        public int IdDestino { get; set; }
        public string nvRespuesta { get; set; }
        public Nullable<System.DateTime> dtFechaEncuesta { get; set; }
        public Nullable<System.DateTime> dtFechaViaje { get; set; }
    
        public virtual TO_Destino TO_Destino { get; set; }
        public virtual TO_Encuesta TO_Encuesta { get; set; }
    }
}
