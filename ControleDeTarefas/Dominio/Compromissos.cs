using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Dominio
{
    public class Compromissos : DominioBase
    {
        public string Assunto;
        public string Local;
        public DateTime DataDoCompromisso;
        public DateTime HoraInicio;
        public DateTime HoraTermino;

        public Compromissos(string assunto, string local, DateTime dataDoCompromisso, DateTime horaInicio, DateTime horaTermino)
        {
            Assunto = assunto;
            Local = local;
            DataDoCompromisso = dataDoCompromisso;
            HoraInicio = horaInicio;
            HoraTermino = horaTermino;
        }
    }
}
