using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ControleDeTarefas.Controlador;

namespace ControleDeTarefas.Telas
{
    public class TelaPrincipal
    {
        public string ObterOpcaoMenuPrincipal()
        {                       
            
                 Console.WriteLine("   ╔═════════Menu Principal═════════╗   ");
                 Console.WriteLine("╔══════════════════════════════════════╗");
                 Console.WriteLine("║                                      ║");
                 Console.WriteLine("║               Digite:                ║");
                 Console.WriteLine("║                                      ║");
                 Console.WriteLine("║         1: menu de Tarefa            ║");
                 Console.WriteLine("║         2: menu de Contato           ║");
                 Console.WriteLine("║                                      ║");
                 Console.WriteLine("║══════════════════════════════════════║");
                 Console.WriteLine("║            S para sair               ║");
                 Console.WriteLine("╚══════════════════════════════════════╝");

                string opcao = Console.ReadLine();

            return opcao;
        }

        public bool OpcaoInvalida(string opcao)
        {
            if (opcao != "1" && opcao != "2" && opcao != "S" && opcao != "s")
            {
                Console.WriteLine("Opção inválida");
                return true;
            }
            else
                return false;
        }

    }
}
