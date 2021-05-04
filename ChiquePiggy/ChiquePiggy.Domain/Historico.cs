using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiquePiggy.Domain
{
    public class Historico
    {
        public int _idHistorico { get; set; }
        public int _idCliente { get; set; }
        public double _valorDaCompra { get; set; }
        public DateTime _dataDaTransacao { get; set; }
        public int _pontoGanhos { get; private set; }        

        public Historico()
        {

        }

        public Historico(int idCliente, double valorDaCompra)
        {
            _idCliente = idCliente;
            _valorDaCompra = valorDaCompra;
            _dataDaTransacao = DateTime.Now;            
            ArredondarValor();            
        }

        public void SomarValores(int pontosObtidos)
        {
            _pontoGanhos += pontosObtidos;
        }

        private void ArredondarValor()
        {
            _pontoGanhos = Convert.ToInt32(Math.Ceiling(_valorDaCompra));
        }

        public void PontosEmDobro()
        {
            DateTime dataAtual = DateTime.Now;            

            if (dataAtual.DayOfWeek == DayOfWeek.Monday || dataAtual.DayOfWeek == DayOfWeek.Tuesday)
            {
                _pontoGanhos = Convert.ToInt32(Math.Ceiling(_valorDaCompra)) * 2;
            }
        }

        public void SetarPontos(int pontos)
        {
            this._pontoGanhos = pontos;
        }
    }
}
