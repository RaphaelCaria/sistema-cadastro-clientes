using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcessoBanco;
using System.Data.SqlClient;
using System.Data;

namespace TransferenciaDados
{
    public class CadastrarDTO
    {
        public int COD_FUNC { get; set; }

        public string NOME { get; set; }

        public string ENDERECO { get; set; }

        public string CEP { get; set; }

        public string BAIRRO { get; set; }

        public string CIDADE { get; set; }

        public string ESTADO { get; set; }

        public string RG { get; set; }

        public string SALARIO { get; set; }

        public string SEXO { get; set; }

        public string FUNCAO { get; set; }

        public string mensagens { get; set; }

    }

    public class InserirCadastro
    {
        public void InserirFuncionario(CadastrarDTO dados)
        {
            try
            {
                string sql = "insert into TABFUNCIONARIOS(COD_FUNC, NOME, ENDERECO, CEP, BAIRRO, CIDADE, ESTADO,RG, SALARIO, SEXO, FUNCAO) VALUES (@COD_FUNC, @NOME, @ENDERECO, @CEP, @BAIRRO, @CIDADE, @ESTADO, @RG, @SALARIO, @SEXO, @FUNCAO)";
                SqlCommand cmd = new SqlCommand(sql, Conexao.obterConexao());
                cmd.Parameters.Add(new SqlParameter("@COD_FUNC", dados.COD_FUNC));
                cmd.Parameters.Add(new SqlParameter("@NOME", dados.NOME));
                cmd.Parameters.Add(new SqlParameter("@ENDERECO", dados.ENDERECO));
                cmd.Parameters.Add(new SqlParameter("@CEP", dados.CEP));
                cmd.Parameters.Add(new SqlParameter("@BAIRRO", dados.BAIRRO));
                cmd.Parameters.Add(new SqlParameter("@CIDADE", dados.CIDADE));
                cmd.Parameters.Add(new SqlParameter("@ESTADO", dados.ESTADO));
                cmd.Parameters.Add(new SqlParameter("@RG", dados.RG));
                cmd.Parameters.Add(new SqlParameter("@SALARIO", dados.SALARIO));
                cmd.Parameters.Add(new SqlParameter("@SEXO", dados.SEXO));
                cmd.Parameters.Add(new SqlParameter("@FUNCAO", dados.FUNCAO));

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    //Percorrer dados
                    while (dr.Read())
                    {
                        dados.mensagens = dr.GetValue(0).ToString();
                    }
                }
                dr.Close();
                Conexao.fecharConexao();
            }
            catch (SqlException e)
            {
                dados.mensagens = "Erro CadastrarFuncionarios - InserirFuncionarios -" + e.Message.ToString();


                if (e.Errors[0].Number == 2627)
                {
                    dados.mensagens = "O RG não pode ser duplicado";
                }
                else if (e.Errors[0].Number == 547)
                {
                    dados.mensagens = "O Salário não pode ser negativo";
                }
            }
        }
    }

}