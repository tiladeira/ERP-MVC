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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class Praga
    {
        public Praga()
        {
            this.ItemPedido = new HashSet<ItemPedido>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdPraga { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public int IdTipoPraga { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string NomePraga { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string ImgPraga { get; set; }
    
        public virtual ICollection<ItemPedido> ItemPedido { get; set; }
        public virtual TipoPraga TipoPraga { get; set; }
    }
}
