using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Dominio
{
    public class Contato : DominioBase
    {
        public string Nome;
        public string Email;
        public string Telefone;
        public string Empresa;
        public string Cargo;

        public Contato(string nome, string email, string telefone, string empresa, string cargo)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Empresa = empresa;
            Cargo = cargo;
        }
    }
}
