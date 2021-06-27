using System;
using System.Collections.Generic;
using ControleDeTarefas.Telas;
using ControleDeTarefas.Controlador;

namespace ControleDeTarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ControladorTarefa controlador = new ControladorTarefa();
            ControladorContato controlador1 = new ControladorContato();
            ControladorCompromissos controlador2 = new ControladorCompromissos();

            TelaTarefa telaTarefa = new TelaTarefa(controlador);
            TelaContato telaContato = new TelaContato(controlador1);
            TelaCompromissos telaCompromissos = new TelaCompromissos(controlador2);

            string opcao = " ";

            Console.Clear();

            Console.WriteLine("     ╔══════════════╗");
            Console.WriteLine("     ║ e-Agenda 3.0 ║");
            Console.WriteLine("╔═════════════════════════╗");
            Console.WriteLine("║                         ║");
            Console.WriteLine("║         Digite:         ║");
            Console.WriteLine("║                         ║");
            Console.WriteLine("║   1: Menu Tarefa        ║");
            Console.WriteLine("║   2: Menu Contatos      ║");
            Console.WriteLine("║   3: Menu Compromissos  ║");
            Console.WriteLine("║                         ║");
            Console.WriteLine("║═════════════════════════║");
            Console.WriteLine("║      S para sair        ║");
            Console.WriteLine("╚═════════════════════════╝");

            opcao = Console.ReadLine();

            if (opcao == "1")
            {
                while (true)
                {
                    telaTarefa.ObterOpcao();

                    if (Console.ReadLine().Equals("s", StringComparison.OrdinalIgnoreCase))
                        break;

                    if (opcao == "1")
                        telaTarefa.CadastrarNovaTarefa();

                    if (opcao == "2")
                        telaTarefa.AtualizarTarefa();

                    if (opcao == "3")
                        telaTarefa.ExcluirTarefa();

                    if (opcao == "4")
                        telaTarefa.VisualizarTarefasEmAberto();

                    if (opcao == "5")
                        telaTarefa.VisualizarTarefasConcluidas();
                }
            }

            if (opcao == "2")
            {
                while (true)
                {
                    telaContato.ObterOpcao();

                    if (Console.ReadLine().Equals("s", StringComparison.OrdinalIgnoreCase))
                        break;

                    if (opcao == "1")
                        telaContato.CadastrarNovoContato();

                    if (opcao == "2")
                        telaContato.AtualizarContato();

                    if (opcao == "3")
                        telaContato.ExcluirContato();

                    if (opcao == "4")
                        telaContato.VisualizarTodosOsContatos();
                }

            }

            if (opcao == "3")
            {
                while (true)
                {
                    telaCompromissos.ObterOpcao();

                    if (Console.ReadLine().Equals("s", StringComparison.OrdinalIgnoreCase))
                        break;

                    else if (opcao == "1")
                        telaCompromissos.CadastrarNovoCompromisso();

                    else if (opcao == "2")
                        telaCompromissos.AtualizarCompromisso();

                    else if (opcao == "3")
                        telaCompromissos.ExcluirCompromisso();

                    else if (opcao == "4")
                        telaCompromissos.VisualizarTodosOsCompromisso();
                }
            }
        }
    }
}
