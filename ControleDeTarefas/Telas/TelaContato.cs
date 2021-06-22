using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Telas
{
    public class TelaContato
    {
        public string ObterOpcaoMenuContato()
        {
            Console.WriteLine("    ╔═════════Menu Contato═════════╗    ");
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║                                      ║");
            Console.WriteLine("║               Digite:                ║");
            Console.WriteLine("║                                      ║");
            Console.WriteLine("║     1: Inserir novo Contato          ║");
            Console.WriteLine("║     2: Visualizar todos os Contatos  ║");
            Console.WriteLine("║     3: Editar um Contato             ║");
            Console.WriteLine("║     4: Excluir um Contato            ║");
            Console.WriteLine("║                                      ║");
            Console.WriteLine("║══════════════════════════════════════║");
            Console.WriteLine("║            S: Sair                   ║");
            Console.WriteLine("╚══════════════════════════════════════╝");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public bool OpcaoInvalida(string opcao)
        {
            if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "S" && opcao != "s")
            {
                Console.WriteLine("Opção inválida");
                return true;
            }
            else
                return false;
        }
    }
}
