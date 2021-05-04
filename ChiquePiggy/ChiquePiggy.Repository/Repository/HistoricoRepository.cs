using ChiquePiggy.Domain;
using ChiquePiggy.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiquePiggy.Repository.Repository
{
    public class HistoricoRepository : IHistoricoRepository
    {
        private void Insert(Historico historico)
        {
            var Query = "";
            Query += "INSERT INTO HISTORICO(idCliente, valorDaCompra, dataDaTransacao, pontoGanhos)";
            Query += string.Format("VALUES('{0}','{1}','{2}','{3}')", historico._idCliente, historico._valorDaCompra, historico._dataDaTransacao, historico._pontoGanhos);

            using (var context = new Context()) //Apaga o objeto assim que é executado
            {
                context.ExecutaComando(Query,true);
            }
        }

        public void Update(Historico historico)
        {
            var Query = "";
            Query += string.Format("UPDATE HISTORICO SET PONTOGANHOS = {0} WHERE IDCLIENTE ={1}", historico._pontoGanhos, historico._idCliente);

            using (var context = new Context()) //Apaga o objeto assim que é executado
            {
                context.ExecutaComando(Query);
            }
        }

        public List<Historico> ConsultarHistorico(int id)
        {
            using (Context CH = new Context())
            {
                string query = @"SELECT * FROM HISTORICO WHERE IDCLIENTE = " + id + "ORDER BY DATADATRANSACAO DESC";
                var retorno = CH.ExecutaComandoComRetorno(query);
                return ReaderToHistorico(retorno);
            }


        }
        private List<Historico> ReaderToHistorico(SqlDataReader reader)
        {
            var historico = new List<Historico>();

            while (reader.Read())
            {
                var obj = new Historico();           
                obj._idCliente = int.Parse(reader["idCliente"].ToString());
                obj._valorDaCompra = double.Parse(reader["valorDaCompra"].ToString());
                obj._idHistorico = int.Parse(reader["idHistorico"].ToString());
                obj._dataDaTransacao = DateTime.Parse(reader["dataDaTransacao"].ToString());
                obj.SetarPontos(int.Parse(reader["pontoGanhos"].ToString()));
                
                historico.Add(obj);
            }
            reader.Close();
            return historico;
        }
        public void Salvar(Historico historico)
        {
            Insert(historico);
        }


    }
}
