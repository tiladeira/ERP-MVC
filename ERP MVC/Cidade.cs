//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP_MVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cidade
    {
        public Cidade()
        {
            this.Cliente = new HashSet<Cliente>();
        }
    
        public int IdCidade { get; set; }
        public int IdEstado { get; set; }
        public string Cidade1 { get; set; }
    
        public virtual Estado Estado { get; set; }
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
