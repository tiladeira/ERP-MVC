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
    
    public partial class ClientePF
    {
        public int IdClientePF { get; set; }
        public int IdTipoCliente { get; set; }
        public Nullable<int> IdProfisao { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public System.DateTime DataExpedicao { get; set; }
        public string OrgaoEmissor { get; set; }
        public string CNH { get; set; }
        public System.DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string EMail { get; set; }
        public int IdTipoEndereco { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public int IdEstado { get; set; }
        public int IdCidade { get; set; }
        public string PontoReferencia { get; set; }
        public string FoneContato { get; set; }
        public string CelContato { get; set; }
        public string FoneComlContato { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public Nullable<System.DateTime> DataAtualizacao { get; set; }
        public int Status { get; set; }
    
        public virtual Profissao Profissao { get; set; }
        public virtual TipoCliente TipoCliente { get; set; }
        public virtual TipoEndereco TipoEndereco { get; set; }
    }
}
