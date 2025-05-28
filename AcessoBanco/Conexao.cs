using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcessoBanco.Properties;
using System.Data.SqlClient;

namespace AcessoBanco
{
    public class Conexao
    {
        //RECEBER MENSAGEM DE CONEXAO
        public static string mensagem = string.Empty;


        //Criar Conexão
        private static string strConn = Settings.Default.strConexao;

        // representa a conexão com o banco
        private static SqlConnection conn = null;

        // método que permite obter a conexão
        public static SqlConnection obterConexao()
        {
            // vamos criar a conexão
            //Instanciar
            conn = new SqlConnection(strConn);
            //Tratamento de exceções
            try
            {
                // abre a conexão e a devolve ao chamador do método
                conn.Open();
            }
            catch (SqlException e)
            {
                // retorna a variável como nulo
                conn = null;
                // apresentar a mensagem de exceção
                // throw e;
                mensagem = e.ToString();
            }
            return conn;
        }
        public static SqlConnection fecharConexao()
        {
            // vamos criar a conexão
            //Instanciar
            conn = new SqlConnection(strConn);
            //Tratamento de exceções
            try
            {
                conn.Close();
            }
            catch (SqlException e)
            {
                // retorna a variável como nulo
                conn = null;
                // apresentar a mensagem de exceção
                // throw e;
                mensagem = e.ToString();
            }
            return conn;
        }
    }
}
