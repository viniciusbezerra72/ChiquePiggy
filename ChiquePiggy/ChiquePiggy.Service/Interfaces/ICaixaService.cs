using ChiquePiggy.Domain;
using ChiquePiggy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiquePiggy.Services.Interfaces
{
    public interface ICaixaService

    {
        ClienteViewModel ConsultarCliente(int id);
        Historico GerarPontuacao(CaixaViewModel model);
        int ConsultarSaldo(int id);
        Cliente SalvarCliente(Cliente cliente);
        bool BaixaPontos(int id);




    }

}
