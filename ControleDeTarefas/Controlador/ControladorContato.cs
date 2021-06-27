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
        public void InserirContato(Contato contatos)
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = con;

            string sqlInsercao =
                @"INSERT INTO TBCONTATO
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

            sqlInsercao += @"SELECT SCOPE_IDENTITY();";

            comandoInsercao.CommandText = sqlInsercao;

            comandoInsercao.Parameters.AddWithValue("NOME", contatos.Nome);
            comandoInsercao.Parameters.AddWithValue("EMAIL", contatos.Email);
            comandoInsercao.Parameters.AddWithValue("TELEFONE", contatos.Telefone);
            comandoInsercao.Parameters.AddWithValue("EMPRESA", contatos.Empresa);
            comandoInsercao.Parameters.AddWithValue("CARGO", contatos.Cargo);

            object id = comandoInsercao.ExecuteScalar();

            contatos.Id = Convert.ToInt32(id);

            con.Close();
        }

        public void AtualizarContato(Contato contatos)
        {

            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoAtualizacao = new SqlCommand();
            comandoAtualizacao.Connection = con;

            string sqlAtualizacao =
                @"UPDATE TBCONTATO
                    SET
                        [NOME] = @NOME,
                        [EMAIL] = @EMAIL,
                        [TELEFONE] = @TELEFONE,
                        [EMPRESA] = @EMPRESA,
                        [CARGO] = @CARGO
                    WHERE
                        [ID] = @ID";

            comandoAtualizacao.CommandText = sqlAtualizacao;

            comandoAtualizacao.Parameters.AddWithValue("ID", contatos.Id);
            comandoAtualizacao.Parameters.AddWithValue("NOME", contatos.Nome);
            comandoAtualizacao.Parameters.AddWithValue("EMAIL", contatos.Email);
            comandoAtualizacao.Parameters.AddWithValue("TELEFONE", contatos.Telefone);
            comandoAtualizacao.Parameters.AddWithValue("EMPRESA", contatos.Empresa);
            comandoAtualizacao.Parameters.AddWithValue("CARGO", contatos.Cargo);

            comandoAtualizacao.ExecuteNonQuery();

            con.Close();
        }

        public void ExcluirContato(Contato contatos)
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = con;

            string sqlExclusao =
                @"DELETE FROM TBCONTATO	                
	                WHERE 
		                [ID] = @ID";

            comandoExclusao.CommandText = sqlExclusao;

            comandoExclusao.Parameters.AddWithValue("ID", contatos.Id);

            comandoExclusao.ExecuteNonQuery();

            con.Close();
        }

        public Contato SelecionarContatoPorId(int idPesquisado)
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ID], 
                        [NOME], 
                        [EMAIL],
                        [TELEFONE],
                        [EMPRESA],
                        [CARGO]
                    FROM 
                        TBCONTATO
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

            string telefone = Convert.ToString(leitorContatos["TELEFONE"]);

            string empresa = Convert.ToString(leitorContatos["EMPRESA"]);

            string cargo = Convert.ToString(leitorContatos["CARGO"]);

            Contato c = new Contato(nome, email, telefone, empresa, cargo);
            c.Id = id;

            con.Close();

            return c;
        }

        public List<Contato> SelecionarTodosOsContatos()
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ID], 
                        [NOME], 
                        [EMAIL], 
                        [TELEFONE],
                        [EMPRESA],
                        [CARGO]
                    FROM 
                        TBCONTATO";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorContatos = comandoSelecao.ExecuteReader();

            List<Contato> contatos = new List<Contato>();

            while (leitorContatos.Read())
            {
                int id = Convert.ToInt32(leitorContatos["ID"]);

                string nome = Convert.ToString(leitorContatos["NOME"]);

                string email = Convert.ToString(leitorContatos["EMAIL"]);

                string telefone = Convert.ToString(leitorContatos["TELEFONE"]);

                string empresa = Convert.ToString(leitorContatos["EMPRESA"]);

                string cargo = Convert.ToString(leitorContatos["CARGO"]);

                Contato contato = new Contato(nome, email, telefone, empresa, cargo);

                contato.Id = id;

                contatos.Add(contato);
            }

            con.Close();

            return contatos;
        }
    }
}
