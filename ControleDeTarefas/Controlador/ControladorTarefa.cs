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
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = con;

            string sqlInsercao =
                @"INSERT INTO TBLISTA
                    (
                        [TITULO],
                        [DATACRIACAO],
                        [PRIORIDADE]
                    )
                    VALUES
                    (
                        @TITULO,
                        @DATACRIACAO,
                        @PRIORIDADE
                    );";

            sqlInsercao += @"SELECT SCOPE_IDENTITY();";

            comandoInsercao.CommandText = sqlInsercao;

            comandoInsercao.Parameters.AddWithValue("TITULO", tarefa.Titulo);
            comandoInsercao.Parameters.AddWithValue("DATACRIACAO", tarefa.DataCriacao);
            comandoInsercao.Parameters.AddWithValue("PRIORIDADE", tarefa.Prioridade);

            object id = comandoInsercao.ExecuteScalar();

            tarefa.Id = Convert.ToInt32(id);

            con.Close();
        }

        public Tarefa SelecionarTarefaPorId(int idPesquisado)
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ID], 
                        [TITULO], 
                        [DATACRIACAO],
                        [DATACONCLUSAO],
                        [PRIORIDADE]
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

            DateTime dataConclusao = DateTime.MinValue;

            if (leitorTarefas["DATACONCLUSAO"] != DBNull.Value)
                dataConclusao = Convert.ToDateTime(leitorTarefas["DATACONCLUSAO"]);

            int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);

            Tarefa l = new Tarefa(titulo, dataCriacao, dataConclusao, prioridade);
            l.Id = id;

            con.Close();

            return l;
        }

        public void ExcluirTarefa(Tarefa tarefa)
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = con;

            string sqlExclusao =
                @"DELETE FROM TBLISTA	                
	                WHERE 
		                [ID] = @ID";

            comandoExclusao.CommandText = sqlExclusao;

            comandoExclusao.Parameters.AddWithValue("ID", tarefa.Id);

            comandoExclusao.ExecuteNonQuery();

            con.Close();
        }

        public void EditaTarefa(Tarefa tarefa)
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoAtualizacao = new SqlCommand();
            comandoAtualizacao.Connection = con;

            string sqlAtualizacao =
                @"UPDATE TBLISTA
                    SET
                        [TITULO] = @TITULO,
                        [DATACONCLUSAO] = @DATACONCLUSAO,
                        [PRIORIDADE] = @PRIORIDADE
                    WHERE
                        [ID] = @ID";

            comandoAtualizacao.CommandText = sqlAtualizacao;

            comandoAtualizacao.Parameters.AddWithValue("ID", tarefa.Id);
            comandoAtualizacao.Parameters.AddWithValue("TITULO", tarefa.Titulo);
            comandoAtualizacao.Parameters.AddWithValue("DATACONCLUSAO", tarefa.DataConclusao);
            comandoAtualizacao.Parameters.AddWithValue("PRIORIDADE", tarefa.Prioridade);

            comandoAtualizacao.ExecuteNonQuery();

            con.Close();
        }

        public List<Tarefa> SelecionarTodasAsTarefas()
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ID], 
                        [TITULO], 
                        [DATACRIACAO], 
                        [PRIORIDADE] 
                    FROM 
                        TBTAREFA
                    ORDER BY 
                        [PRIORIDADE] ASC";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            List<Tarefa> tarefas = new List<Tarefa>();

            while (leitorTarefas.Read())
            {
                int id = Convert.ToInt32(leitorTarefas["ID"]);

                string titulo = Convert.ToString(leitorTarefas["TITULO"]);

                DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);

                int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);

                Tarefa tarefa = new Tarefa(titulo, dataCriacao, prioridade);

                tarefa.Id = id;

                tarefas.Add(tarefa);
            }

            con.Close();

            return tarefas;
        }

        public List<Tarefa> SelecionarTodasAsTarefasEmAberto()
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ID], 
                        [TITULO], 
                        [DATACRIACAO], 
                        [PRIORIDADE] 
                    FROM 
                        TBTAREFA
                    WHERE
                        [PERCENTUAL] != '100%'
                    ORDER BY
                        [PRIORIDADE] ASC, [DATACRIACAO]";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            List<Tarefa> tarefas = new List<Tarefa>();

            while (leitorTarefas.Read())
            {
                int id = Convert.ToInt32(leitorTarefas["ID"]);

                string titulo = Convert.ToString(leitorTarefas["TITULO"]);

                DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);

                int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);

                Tarefa tarefa = new Tarefa(titulo, dataCriacao, prioridade);

                tarefa.Id = id;

                tarefas.Add(tarefa);
            }

            con.Close();

            return tarefas;
        }

        public List<Tarefa> SelecionarTodasAsTarefasConcluidas()
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ID], 
                        [TITULO], 
                        [DATACRIACAO],
                        [DATACONCLUSAO],
                        [PRIORIDADE] 
                    FROM 
                        TBTAREFA
                    WHERE
                        PERCENTUAL = '100%'
                    ORDER BY
                        [PRIORIDADE] ASC, [DATACRIACAO]";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            List<Tarefa> tarefasConcluidas = new List<Tarefa>();

            while (leitorTarefas.Read())
            {
                int id = Convert.ToInt32(leitorTarefas["ID"]);

                string titulo = Convert.ToString(leitorTarefas["TITULO"]);

                DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);

                DateTime dataConclusao = Convert.ToDateTime(leitorTarefas["DATACONCLUSAO"]);

                int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);

                Tarefa lista = new Tarefa(titulo, dataCriacao, dataConclusao, prioridade);
                lista.Id = id;

                tarefasConcluidas.Add(lista);
            }

            con.Close();

            return tarefasConcluidas;
        }
    }
    
}
