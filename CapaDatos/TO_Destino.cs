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
    
    public partial class TO_Destino
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TO_Destino()
        {
            this.TO_Experiencias = new HashSet<TO_Experiencias>();
            this.TO_DetalleDestinos = new HashSet<TO_DetalleDestinos>();
            this.TO_Viajes = new HashSet<TO_Viajes>();
            this.TO_EncuestaResp = new HashSet<TO_EncuestaResp>();
        }
    
        public int IdViaje { get; set; }
        public string Destino { get; set; }
        public string nvTitulo { get; set; }
        public string nvSubt { get; set; }
        public string nvDesc { get; set; }
        public string nvRutaImg { get; set; }
        public string nvItineraDes { get; set; }
        public string nvGuia { get; set; }
        public string nvRecom { get; set; }
        public Nullable<bool> bPrincipal { get; set; }
        public Nullable<bool> bActivo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TO_Experiencias> TO_Experiencias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TO_DetalleDestinos> TO_DetalleDestinos { get; set; }
        public virtual TO_Costo TO_Costo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TO_Viajes> TO_Viajes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TO_EncuestaResp> TO_EncuestaResp { get; set; }
    }
}
