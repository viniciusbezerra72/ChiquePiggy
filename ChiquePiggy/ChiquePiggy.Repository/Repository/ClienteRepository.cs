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
    public class ClienteRepository : IClienteRepository
    {
        public Cliente ConsultarCliente(int id)
        {
            using (Context co = new Context())
            {
                string query = @"SELECT * FROM CLIENTE WHERE IDCLIENTE = " + id;
                var retorno = co.ExecutaComandoComRetorno(query);
                return ReaderToCliente(retorno);
            }
        }

        private Cliente ReaderToCliente(SqlDataReader reader)
        {
            var cliente = new Cliente();

            while (reader.Read())
            {
                cliente.idCliente = int.Parse(reader["idCliente"].ToString());
                cliente.nome = reader["nome"].ToString();
            }
            reader.Close();
            return cliente;
        }

        private void Insert(Cliente cliente)
        {
            var Query = "";
            Query += "INSERT INTO Cliente(Nome)";
            Query += string.Format("VALUES('{0}')", cliente.nome);

            using (var context = new Context()) //Apaga o objeto assim que é executado
            {
               cliente.idCliente = context.ExecutaComando(Query,true);
            }
        }


        public Cliente Salvar(Cliente cliente)
        {
            Insert(cliente);
            return cliente;
        }        
    }
}
