//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChiquePiggy.MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class historico
    {
        public int idHistorico { get; set; }
        public int idCliente { get; set; }
        public double valorDaCompra { get; set; }
        public System.DateTime dataDaTransacao { get; set; }
        public int pontoGanhos { get; set; }
    
        public virtual cliente cliente { get; set; }
    }
}
