using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiquePiggy.Models
{
    public class CaixaViewModel
    {
             
        public int idCliente { get; set; }
        [Required(ErrorMessage ="Insira o valor da compra")]
        public double valorDaCompra { get; set; }            
        public string Nome { get; set; } 
    }
}
