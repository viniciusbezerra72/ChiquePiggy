using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiquePiggy.Repository
{
    public class Context : IDisposable
    {
        private readonly SqlConnection sql;

        public Context()
        {
            sql = new SqlConnection(ConfigurationManager.ConnectionStrings["chiquePiggyConfig"].ConnectionString);
            sql.Open();
        }

        public int ExecutaComando(string Query, bool Insert = false)
        {
            SqlCommand comando = new SqlCommand
            {
                CommandText = Query,
                CommandType = CommandType.Text,
                Connection = sql
            };
            comando.ExecuteNonQuery();
            if (Insert)
            {
                string query = "SELECT SCOPE_IDENTITY() AS ID";
                var reader = ExecutaComandoComRetorno(query);
                while (reader.Read())
                {
                    return int.Parse(reader["ID"].ToString());
                }
            }            
            return 0;
        }
        public SqlDataReader ExecutaComandoComRetorno(string Query) //SQLDATAREADER tudo que retorna algum valor do BD
        {
            SqlCommand comando = new SqlCommand(Query, sql);
            return comando.ExecuteReader();
        }
        public void Dispose()
        {
            if(sql.State == System.Data.ConnectionState.Open)
            {
                sql.Close();
            }
            
        }
    }
}
