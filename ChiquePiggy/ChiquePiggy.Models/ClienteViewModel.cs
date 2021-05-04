using ChiquePiggy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiquePiggy.Models
{
    public class ClienteViewModel
    {
        public int idCliente { get; set; }

        public string nome { get; set; }

        public static ClienteViewModel MapFrom(Cliente cliente)
        {
            ClienteViewModel model = new ClienteViewModel
            {
                idCliente = cliente.idCliente,
                nome = cliente.nome

            };
            return model;
        }
    }

}
