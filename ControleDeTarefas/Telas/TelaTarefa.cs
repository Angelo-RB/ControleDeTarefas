using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Telas
{
    public class TelaTarefa
    {
        public string ObterOpcaoMenuTarefa()
        {
            Console.WriteLine("    ╔═════════Menu Tarefa═════════╗    ");
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║                                      ║");
            Console.WriteLine("║               Digite:                ║");
            Console.WriteLine("║                                      ║");
            Console.WriteLine("║     1 para inserir nova Tarefa       ║");
            Console.WriteLine("║     2 para visualizar Tarefas        ║");
            Console.WriteLine("║     3 para editar uma Tarefa         ║");
            Console.WriteLine("║     4 para excluir uma Tarefa        ║");
            Console.WriteLine("║                                      ║");
            Console.WriteLine("║══════════════════════════════════════║");
            Console.WriteLine("║            S para sair               ║");
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
