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
    
    public partial class SERVICII_CONTRACT
    {
        public int SC_ID { get; set; }
        public int SC_C_ID { get; set; }
        public int SC_S_ID { get; set; }
    
        public virtual CONTRACTE CONTRACTE { get; set; }
        public virtual LIBRARIE LIBRARIE { get; set; }
    }
}