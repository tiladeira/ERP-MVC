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
    
    public partial class Perfil
    {
        public Perfil()
        {
            this.Usuario = new HashSet<Usuario>();
            this.Menu = new HashSet<Menu>();
            this.Usuario1 = new HashSet<Usuario>();
        }
    
        public int IdPerfil { get; set; }
        public string Perfil1 { get; set; }
        public string Descricao { get; set; }
    
        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
        public virtual ICollection<Usuario> Usuario1 { get; set; }
    }
}
