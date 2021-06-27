using System;
using System.Data.SqlClient;

namespace ControleDeTarefas
{
    public static class BancoDeDados
    {
        private static string enderecoDBLista =
            @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBTarefa;Integrated Security=True;Pooling=False";

        public static SqlConnection AbrirConexao()
        {
            SqlConnection conexao = new SqlConnection();
            try
            {
                conexao.ConnectionString = enderecoDBLista;
                conexao.Open();
            }
            catch (Exception ex)
            {
                conexao.Close();
                throw new Exception(ex.Message);
            }

            return conexao;
        }
    }
}
