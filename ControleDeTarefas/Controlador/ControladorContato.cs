using ControleDeTarefas.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Controlador
{
    public class ControladorContato
    {
        public void InserirContato(Contato contato)
        {
            string enderecoDBEmpresa =
                @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBTarefa;Integrated Security=True;Pooling=False";

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoDBEmpresa;
            conexaoComBanco.Open();

            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = conexaoComBanco;

            string sqlInsercao =
                @"INSERT INTO Contato 
	                (
		                [NOME], 
		                [EMAIL], 
		                [TELEFONE],
                        [EMPRESA],
                        [CARGO]
	                ) 
	                VALUES
	                (
                        @NOME, 
		                @EMAIL, 
		                @TELEFONE,
                        @EMPRESA,
                        @CARGO
	                );";

            sqlInsercao +=
                @"SELECT SCOPE_IDENTITY();";

            comandoInsercao.CommandText = sqlInsercao;

            comandoInsercao.Parameters.AddWithValue("NOME", contato.Nome);
            comandoInsercao.Parameters.AddWithValue("EMAIL", contato.Email);
            comandoInsercao.Parameters.AddWithValue("TELEFONE", contato.Telefone);
            comandoInsercao.Parameters.AddWithValue("EMPRESA", contato.Empresa);
            comandoInsercao.Parameters.AddWithValue("CARGO", contato.Cargo);

            object id = comandoInsercao.ExecuteScalar();

            contato.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();
        }

        public Contato SelecionarContatoPorId(int idPesquisado)
        {
            string enderecoDBEmpresa =
              @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBTarefa;Integrated Security=True;Pooling=False";

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoDBEmpresa;
            conexaoComBanco.Open();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;

            string sqlSelecao =
                @"SELECT 
                    [ID], 
                    [NOME], 
                    [EMAIL], 
                    [TELEFONE], 
                    [EMPRESA],
                    [CARGO]
                FROM 
                    CONTATO
                WHERE 
                    ID = @ID";

            comandoSelecao.CommandText = sqlSelecao;
            comandoSelecao.Parameters.AddWithValue("ID", idPesquisado);

            SqlDataReader leitorContatos = comandoSelecao.ExecuteReader();

            if (leitorContatos.Read() == false)
                return null;

            int id = Convert.ToInt32(leitorContatos["ID"]);
            string nome = Convert.ToString(leitorContatos["NOME"]);
            string email = Convert.ToString(leitorContatos["EMAIL"]);
            int telefone = Convert.ToInt32(leitorContatos["TELEFONE"]);
            string empresa = Convert.ToString(leitorContatos["EMPRESA"]);
            string cargo = Convert.ToString(leitorContatos["CARGO"]);

            Contato f = new Contato(nome, email, telefone, empresa, cargo);
            f.Id = id;

            conexaoComBanco.Close();

            return f;
        }

        public void ExcluirContato(Contato contato)
        {
            string enderecoDBEmpresa =
               @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBTarefa;Integrated Security=True;Pooling=False";

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoDBEmpresa;
            conexaoComBanco.Open();

            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = conexaoComBanco;

            string sqlExclusao =
                @"DELETE FROM CONTATO 	                
                 WHERE 
                  [ID] = @ID";

            comandoExclusao.CommandText = sqlExclusao;

            comandoExclusao.Parameters.AddWithValue("ID", contato.Id);

            comandoExclusao.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public void EditarContato(Contato contato)
        {
            string enderecoDBEmpresa =
               @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBTarefa;Integrated Security=True;Pooling=False";

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoDBEmpresa;
            conexaoComBanco.Open();

            SqlCommand comandoAtualizacao = new SqlCommand();
            comandoAtualizacao.Connection = conexaoComBanco;

            string sqlAtualizacao =
                @"UPDATE CONTATO 
                 SET	
                  [NOME] = @NOME, 
                  [EMAIL]=@EMAIL, 
                  [TELEFONE] = @TELEFONE,
                  [EMPRESA] = @EMPRESA,
                  [CARGO] = @CARGO
                 WHERE 
                  [ID] = @ID";

            comandoAtualizacao.CommandText = sqlAtualizacao;

            comandoAtualizacao.Parameters.AddWithValue("ID", contato.Id);
            comandoAtualizacao.Parameters.AddWithValue("NOME", contato.Nome);
            comandoAtualizacao.Parameters.AddWithValue("EMAIL", contato.Email);
            comandoAtualizacao.Parameters.AddWithValue("TELEFONE", contato.Telefone);
            comandoAtualizacao.Parameters.AddWithValue("EMPRESA", contato.Empresa);
            comandoAtualizacao.Parameters.AddWithValue("CARGO", contato.Cargo);

            comandoAtualizacao.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public List<Contato> SelecionarTodosOsContatos()
        {
            string enderecoDBEmpresa =
              @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBTarefa;Integrated Security=True;Pooling=False";

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoDBEmpresa;
            conexaoComBanco.Open();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;

            string sqlSelecao =
                     @"SELECT 
                        [ID], 
                        [NOME], 
                        [EMAIL], 
                        [TELEFONE], 
                        [EMPRESA],
                        [CARGO] 
                    FROM 
                        CONTATO";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorContatos = comandoSelecao.ExecuteReader();

            List<Contato> contatos = new List<Contato>();

            while (leitorContatos.Read())
            {
                int id = Convert.ToInt32(leitorContatos["ID"]);
                string nome = Convert.ToString(leitorContatos["NOME"]);
                string email = Convert.ToString(leitorContatos["EMAIL"]);
                int telefone = Convert.ToInt32(leitorContatos["TELEFONE"]);
                string empresa = Convert.ToString(leitorContatos["EMPRESA"]);
                string cargo = Convert.ToString(leitorContatos["CARGO"]);

                Contato f = new Contato(nome, email, telefone, empresa, cargo);
                f.Id = id;

                contatos.Add(f);
            }

            conexaoComBanco.Close();
            return contatos;
        }
    }
}
