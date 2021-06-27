using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Dominio
{
    public class Tarefa : DominioBase
    {
        public string Titulo;
        public DateTime DataCriacao;
        public DateTime DataConclusao;
        public int Prioridade;

        public Tarefa(string titulo, DateTime dataCriacao, int prioridade)
        {
            Titulo = titulo;
            DataCriacao = dataCriacao;
            Prioridade = prioridade;
        }

        public Tarefa(string titulo, DateTime dataCriacao, DateTime dataConclusao,
            int prioridade)
        {
            Titulo = titulo;
            DataCriacao = dataCriacao;
            DataConclusao = dataConclusao;
            Prioridade = prioridade;
        }

    }   

        

}
