//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace blcAPI2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CONTRACTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTRACTE()
        {
            this.SERVICII_CONTRACT = new HashSet<SERVICII_CONTRACT>();
        }
    
        public int C_ID { get; set; }
        public int C_NUMAR { get; set; }
        public System.DateTime C_DATA { get; set; }
        public int C_PERSOANA_ID { get; set; }
        public Nullable<int> C_NR_PERS { get; set; }
        public Nullable<int> C_NR_ADULTI { get; set; }
        public Nullable<int> C_NR_COPII { get; set; }
        public string C_TARA { get; set; }
        public string C_ORAS { get; set; }
        public Nullable<System.DateTime> C_DE_LA_DATA { get; set; }
        public Nullable<System.DateTime> C_PANA_LA_DATA { get; set; }
        public string C_HOTEL { get; set; }
        public Nullable<int> C_HOTEL_STELE { get; set; }
        public string C_MENTIUNI { get; set; }
        public Nullable<decimal> C_PRET { get; set; }
        public Nullable<int> C_MONEDA { get; set; }
        public Nullable<decimal> C_AVANS { get; set; }
        public Nullable<System.DateTime> C_DATA_DIFERENTA { get; set; }
        public string C_FACTURA { get; set; }
        public string C_CHITANTA { get; set; }
        public Nullable<System.DateTime> C_AVANS_DATA { get; set; }
        public Nullable<System.DateTime> C_AVANS2_DATA { get; set; }
        public Nullable<decimal> C_AVANS2 { get; set; }
        public string C_FACTURA2 { get; set; }
        public string C_CHITANTA2 { get; set; }
        public Nullable<System.DateTime> C_DATA_DIFERENTA2 { get; set; }
        public Nullable<System.DateTime> C_AVANS3_DATA { get; set; }
        public Nullable<decimal> C_AVANS3 { get; set; }
        public string C_FACTURA3 { get; set; }
        public string C_CHITANTA3 { get; set; }
        public Nullable<System.DateTime> C_DATA_DIFERENTA3 { get; set; }
    
        public virtual LIBRARIE LIBRARIE { get; set; }
        public virtual PERSOANE PERSOANE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SERVICII_CONTRACT> SERVICII_CONTRACT { get; set; }
    }
}