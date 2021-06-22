using ControleDeTarefas.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Controlador
{
    public class ControladorTarefa
    {
        public void InserirTarefa(Tarefa tarefa)
        {
            string enderecoDBTarefas =
                @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBTarefa;Integrated Security=True;Pooling=False";

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoDBTarefas;
            conexaoComBanco.Open();

            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = conexaoComBanco;

            string sqlInsercao =
                @"INSERT INTO TBTAREFA 
	                (
		                [TITULO], 
		                [DATACRIACAO], 
		                [DATACONCLUSAO],
                        [PRIORIDADE],
                        [PERCENTUAL]
	                ) 
	                VALUES
	                (
                        @TITULO, 
		                @DATACRIACAO, 
		                @DATACONCLUSAO,
                        @PRIORIDADE,
                        @PERCENTUAL
	                );";

            sqlInsercao +=
                @"SELECT SCOPE_IDENTITY();";

            comandoInsercao.CommandText = sqlInsercao;

            comandoInsercao.Parameters.AddWithValue("TITULO", tarefa.Titulo);
            comandoInsercao.Parameters.AddWithValue("DATACRIACAO", tarefa.DataCriacao);
            comandoInsercao.Parameters.AddWithValue("DATACONCLUSAO", tarefa.DataConclusao);
            comandoInsercao.Parameters.AddWithValue("PRIORIDADE", tarefa.Prioridade);
            comandoInsercao.Parameters.AddWithValue("PERCENTUAL", tarefa.Percentual);

            //object id = comandoInsercao.ExecuteScalar();

            //tarefa.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();
        }

        public Tarefa SelecionarTarefaPorId(int idPesquisado)
        {
            string enderecoDBTarefas =
              @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBTarefa;Integrated Security=True;Pooling=False";

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoDBTarefas;
            conexaoComBanco.Open();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;

            string sqlSelecao =
                @"SELECT 
                    [ID], 
                    [TITULO], 
                    [DATACRIACAO], 
                    [DATACONCLUSAO], 
                    [PRIORIDADE],
                    [PERCENTUAL]
                FROM 
                    TBTAREFA
                WHERE 
                    ID = @ID";

            comandoSelecao.CommandText = sqlSelecao;
            comandoSelecao.Parameters.AddWithValue("ID", idPesquisado);

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            if (leitorTarefas.Read() == false)
                return null;

            int id = Convert.ToInt32(leitorTarefas["ID"]);
            string titulo = Convert.ToString(leitorTarefas["TITULO"]);
            DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);
            DateTime dataConclusao = Convert.ToDateTime(leitorTarefas["DATACONCLUSAO"]);
            int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);
            string percentual = Convert.ToString(leitorTarefas["PERCENTUAL"]);

            Tarefa f = new Tarefa(titulo, dataCriacao, dataConclusao, prioridade, percentual);
            f.Id = id;

            conexaoComBanco.Close();

            return f;
        }

        public void ExcluirTarefa(Tarefa tarefa)
        {
            string enderecoDBTarefas =
               @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBTarefa;Integrated Security=True;Pooling=False";

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoDBTarefas;
            conexaoComBanco.Open();

            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = conexaoComBanco;

            string sqlExclusao =
                @"DELETE FROM TBTAREFA 	                
                 WHERE 
                  [ID] = @ID";

            comandoExclusao.CommandText = sqlExclusao;

            comandoExclusao.Parameters.AddWithValue("ID", tarefa.Id);

            comandoExclusao.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public void EditaTarefa(Tarefa tarefa)
        {
            string enderecoDBTarefas =
               @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBTarefa;Integrated Security=True;Pooling=False";

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoDBTarefas;
            conexaoComBanco.Open();

            SqlCommand comandoAtualizacao = new SqlCommand();
            comandoAtualizacao.Connection = conexaoComBanco;

            string sqlAtualizacao =
                @"UPDATE TBTAREFA 
                 SET	
                  [TITULO] = @TITULO, 
                  [DATACRIACAO]=@DATACRIACAO, 
                  [DATACONCLUSAO]=@DATACONCLUSAO, 
                  [PRIORIDADE]=@PRIORIDADE,
                  [PERCENTUAL]=@PERCENTUAL
                 WHERE 
                  [ID] = @ID";

            comandoAtualizacao.CommandText = sqlAtualizacao;

            comandoAtualizacao.Parameters.AddWithValue("ID", tarefa.Id);
            comandoAtualizacao.Parameters.AddWithValue("TITULO", tarefa.Titulo);
            comandoAtualizacao.Parameters.AddWithValue("DATACRIACAO", tarefa.DataCriacao);
            comandoAtualizacao.Parameters.AddWithValue("DATACONCLUSAO", tarefa.DataConclusao);
            comandoAtualizacao.Parameters.AddWithValue("PRIORIDADE", tarefa.Prioridade);
            comandoAtualizacao.Parameters.AddWithValue("PERCENTUAL", tarefa.Percentual);

            comandoAtualizacao.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public List<Tarefa> SelecionarTodasAsTarefas()
        {
            string enderecoDBTarefas =
              @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBTarefa;Integrated Security=True;Pooling=False";

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoDBTarefas;
            conexaoComBanco.Open();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;

            string sqlSelecao =
                     @"SELECT 
                        [ID], 
                        [TITULO], 
                        [DATACRIACAO], 
                        [DATACONCLUSAO], 
                        [PRIORIDADE],
                        [PERCENTUAL] 
                    FROM 
                        TBTAREFA";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            List<Tarefa> tarefas = new List<Tarefa>();

            while (leitorTarefas.Read())
            {
                int id = Convert.ToInt32(leitorTarefas["ID"]);
                string titulo = Convert.ToString(leitorTarefas["TITULO"]);
                DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);
                DateTime dataConclusao = Convert.ToDateTime(leitorTarefas["DATACONCLUSAO"]);
                int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);
                string percentual = Convert.ToString(leitorTarefas["PERCENTUAL"]);

                Tarefa f = new Tarefa(titulo, dataCriacao, dataConclusao, prioridade, percentual);
                f.Id = id;

                tarefas.Add(f);
            }

            conexaoComBanco.Close();
            return tarefas;
        }
    }
    
}
