using ChiquePiggy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiquePiggy.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Cliente ConsultarCliente(int id);

        Cliente Salvar(Cliente cliente);

    }
}
