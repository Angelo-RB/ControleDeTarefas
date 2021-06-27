using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ControleDeTarefas.Dominio;

namespace ControleDeTarefas.Controlador
{
    public class ControladorCompromissos
    {
        public void InserirNovoCompromisso(Compromissos compromissos)
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = con;

            string sqlInsercao =
                @"INSERT INTO TBCOMPROMISSO
                    (
                        [ASSUNTO],
                        [LOCAL],
                        [DATADOCOMPROMISSO],
                        [HORAINICIO],
                        [HORATERMINO]
                    )
                    VALUES
                    (
                        @ASSUNTO,
                        @LOCAL,
                        @DATADOCOMPROMISSO,
                        @HORAINICIO,
                        @HORATERMINO
                    );";

            sqlInsercao += @"SELECT SCOPE_IDENTITY();";

            comandoInsercao.CommandText = sqlInsercao;

            comandoInsercao.Parameters.AddWithValue("ASSUNTO", compromissos.Assunto);
            comandoInsercao.Parameters.AddWithValue("LOCAL", compromissos.Local);
            comandoInsercao.Parameters.AddWithValue("DATADOCOMPROMISSO", compromissos.DataDoCompromisso);
            comandoInsercao.Parameters.AddWithValue("HORAINICIO", compromissos.HoraInicio);
            comandoInsercao.Parameters.AddWithValue("HORATERMINO", compromissos.HoraTermino);

            object id = comandoInsercao.ExecuteScalar();

            compromissos.Id = Convert.ToInt32(id);

            con.Close();
        }

        public void AtualizarCompromisso(Compromissos compromissos)
        {

            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoAtualizacao = new SqlCommand();
            comandoAtualizacao.Connection = con;

            string sqlAtualizacao =
                @"UPDATE TBCOMPROMISSO
                    SET
                        [ASSUNTO] = @ASSUNTO,
                        [LOCAL] = @LOCAL,
                        [DATADOCOMPROMISSO] = @DATADOCOMPROMISSO,
                        [HORAINICIO] = @HORAINICIO,
                        [HORATERMINO] = @HORATERMINO
                    WHERE
                        [ID] = @ID";

            comandoAtualizacao.CommandText = sqlAtualizacao;

            comandoAtualizacao.Parameters.AddWithValue("ID", compromissos.Id);
            comandoAtualizacao.Parameters.AddWithValue("ASSUNTO", compromissos.Assunto);
            comandoAtualizacao.Parameters.AddWithValue("LOCAL", compromissos.Local);
            comandoAtualizacao.Parameters.AddWithValue("DATADOCOMPROMISSO", compromissos.DataDoCompromisso);
            comandoAtualizacao.Parameters.AddWithValue("HORAINICIO", compromissos.HoraInicio);
            comandoAtualizacao.Parameters.AddWithValue("HORATERMINO", compromissos.HoraTermino);

            comandoAtualizacao.ExecuteNonQuery();

            con.Close();
        }

        public void ExcluirCompromisso(Compromissos compromissos)
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = con;

            string sqlExclusao =
                @"DELETE FROM TBCOMPROMISSO	                
	                WHERE 
		                [ID] = @ID";

            comandoExclusao.CommandText = sqlExclusao;

            comandoExclusao.Parameters.AddWithValue("ID", compromissos.Id);

            comandoExclusao.ExecuteNonQuery();

            con.Close();
        }

        public Compromissos SelecionarCompromissoPorId(int idPesquisado)
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ID], 
                        [ASSUNTO], 
                        [LOCAL],
                        [DATADOCOMPROMISSO],
                        [HORAINICIO],
                        [HORATERMINO]
                    FROM 
                        TBCOMPROMISSO
                    WHERE 
                        ID = @ID";

            comandoSelecao.CommandText = sqlSelecao;
            comandoSelecao.Parameters.AddWithValue("ID", idPesquisado);

            SqlDataReader leitorCompromisso = comandoSelecao.ExecuteReader();

            if (leitorCompromisso.Read() == false)
                return null;

            int id = Convert.ToInt32(leitorCompromisso["ID"]);

            string assunto = Convert.ToString(leitorCompromisso["ASSUNTO"]);

            string local = Convert.ToString(leitorCompromisso["LOCAL"]);

            DateTime datadocompromisso = Convert.ToDateTime(leitorCompromisso["DATADOCOMPROMISSO"]);

            DateTime horainicio = Convert.ToDateTime(leitorCompromisso["HORAINICIO"]);

            DateTime horatermino = Convert.ToDateTime(leitorCompromisso["HORATERMINO"]);

            Compromissos c = new Compromissos(assunto, local, datadocompromisso, horainicio, horatermino);
            c.Id = id;

            con.Close();

            return c;
        }

        public List<Compromissos> SelecionarTodosOsCompromissos()
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ID], 
                        [ASSUNTO], 
                        [LOCAL], 
                        [DATADOCOMPROMISSO],
                        [HORAINICIO],
                        [HORATERMINO]
                    FROM 
                        TBCOMPROMISSO";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorCompromisso = comandoSelecao.ExecuteReader();

            List<Compromissos> compromissos = new List<Compromissos>();

            while (leitorCompromisso.Read())
            {
                int id = Convert.ToInt32(leitorCompromisso["ID"]);

                string assunto = Convert.ToString(leitorCompromisso["ASSUNTO"]);

                string local = Convert.ToString(leitorCompromisso["LOCAL"]);

                DateTime datadocompromisso = Convert.ToDateTime(leitorCompromisso["DATADOCOMPROMISSO"]);

                DateTime horainicio = Convert.ToDateTime(leitorCompromisso["HORAINICIO"]);

                DateTime horatermino = Convert.ToDateTime(leitorCompromisso["HORATERMINO"]);

                Compromissos compromisso = new Compromissos(assunto, local, datadocompromisso, horainicio, horatermino);

                compromisso.Id = id;

                compromissos.Add(compromisso);
            }

            con.Close();

            return compromissos;
        }
    }
}
