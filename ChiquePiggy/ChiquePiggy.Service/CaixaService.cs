using ChiquePiggy.Caching;
using ChiquePiggy.Domain;
using ChiquePiggy.Helpers.Constantes;
using ChiquePiggy.Models;
using ChiquePiggy.Repository;
using ChiquePiggy.Repository.Interfaces;
using ChiquePiggy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiquePiggy.Services
{
    public class CaixaService : ICaixaService
    {
        private readonly IClienteRepository _clienteRepository;

        private readonly IHistoricoRepository _historicoRepository;
        public CaixaService(IClienteRepository clienteRepository, IHistoricoRepository historicoRepository)
        {
            this._clienteRepository = clienteRepository;
            this._historicoRepository = historicoRepository;
        }

        public ClienteViewModel ConsultarCliente(int id)
        {
            return ClienteViewModel.MapFrom(_clienteRepository.ConsultarCliente(id));
        }
        public Cliente SalvarCliente(Cliente cliente)
        {
            return _clienteRepository.Salvar(cliente);
        }

        public Historico GerarPontuacao(CaixaViewModel model)
        {
            Historico historico = null;
            var dto = _historicoRepository.ConsultarHistorico(model.idCliente).FirstOrDefault();

            if (dto is null)
            {
                historico = new Historico(model.idCliente, model.valorDaCompra);
                historico.PontosEmDobro();
            }
            else
            {
                historico = new Historico(model.idCliente, model.valorDaCompra);
                historico.PontosEmDobro();
                historico.SomarValores(dto._pontoGanhos);
            }
                        
            _historicoRepository.Salvar(historico);
            return historico;
        }

        public int ConsultarSaldo(int id)
        {
            var historico = _historicoRepository.ConsultarHistorico(id).FirstOrDefault();
            if (historico is null)
            {
                return 0;
            }
            return historico._pontoGanhos;
        }

        public bool BaixaPontos(int id)
        {
            var historico = _historicoRepository.ConsultarHistorico(id).FirstOrDefault();
            int pontos = historico._pontoGanhos - 100;
            historico.SetarPontos(pontos);
            _historicoRepository.Update(historico);
            return true;
            
        }
    }
}
