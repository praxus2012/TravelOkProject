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
    
    public partial class TO_Transporte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TO_Transporte()
        {
            this.TO_Viajes = new HashSet<TO_Viajes>();
        }
    
        public int IdTransporte { get; set; }
        public string nvNombre { get; set; }
        public Nullable<int> NumAsientos { get; set; }
        public Nullable<bool> FilaTrasera { get; set; }
        public Nullable<int> NumAsTrasera { get; set; }
        public Nullable<int> NumColPrin { get; set; }
        public Nullable<int> NumColUno { get; set; }
        public Nullable<int> NumFilColUno { get; set; }
        public Nullable<bool> PrimFilColUnoDif { get; set; }
        public Nullable<int> NumAsFilCUnoDif { get; set; }
        public Nullable<int> NumColDos { get; set; }
        public Nullable<int> NumFilcolDos { get; set; }
        public Nullable<bool> PrimFilColDosDif { get; set; }
        public Nullable<int> NumAsFilCDosDif { get; set; }
        public Nullable<int> NumSani { get; set; }
        public Nullable<bool> SaniTrasero { get; set; }
        public Nullable<bool> SanMedio { get; set; }
        public Nullable<int> NumFilSanM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TO_Viajes> TO_Viajes { get; set; }
    }
}
