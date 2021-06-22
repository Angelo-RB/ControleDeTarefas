using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Dominio;
using ControleDeTarefas.Telas;
using ControleDeTarefas.Controlador;

namespace ControleDeTarefas
{
    class Program
    {       
        static void Main(string[] args)
        {
            //Tarefa tarefa = new Tarefa("aaa", DateTime.Now, DateTime.Now, 1, "50%");

            ////tarefa.InserirTarefa(tarefa);
            //tarefa.Titulo = "Limpar o Pc";
            //tarefa.DataCriacao = new DateTime(2021, 12, 10);
            //tarefa.DataConclusao = DateTime.Now;
            //tarefa.Prioridade = 1;
            //tarefa.Percentual = "50%";

            TelaContato telaContato = new TelaContato();

            TelaTarefa telaTarefa = new TelaTarefa();
            ControladorTarefa controladorTarefa = new ControladorTarefa();
            ControladorContato controladorContato = new ControladorContato();

            TelaPrincipal telaPrincipal = new TelaPrincipal();

            Console.Clear();

            while (true)
            {
                string opcao = telaPrincipal.ObterOpcaoMenuPrincipal();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    break;

                if (opcao == "1")
                {
                    Console.Clear();
                    string obterOpcaoMenuTarefa = telaTarefa.ObterOpcaoMenuTarefa();

                    if (obterOpcaoMenuTarefa.Equals("s", StringComparison.OrdinalIgnoreCase))
                        break;

                    if (obterOpcaoMenuTarefa == "1")
                        controladorTarefa.InserirTarefa(new Tarefa("aaa", DateTime.Now, DateTime.Now, 1, "50%"));

                    else if (obterOpcaoMenuTarefa == "2")
                    {
                        //foreach (List<Tarefa> item in testeTarefa)
                        //{
                        //    Console.WriteLine(item.Titulo);
                        //}
                    }
                        //telaTarefa.VisualizarEquipamentos(new Tarefa());

                    //else if (obterOpcaoMenuTarefa == "3")
                    //    telaTarefa.EditarEquipamento();

                    //else if (obterOpcaoMenuTarefa == "4")
                    //    telaTarefa.ExcluirTarefa();
                }
                else if (opcao == "2")
                {

                    Console.Clear();
                    string obterOpcaoMenuContato = telaContato.ObterOpcaoMenuContato();                    

                    if (obterOpcaoMenuContato.Equals("s", StringComparison.OrdinalIgnoreCase))
                        break;

                    //if (obterOpcaoMenuContato == "1")
                    //    controladorContato.InserirContato();

                    //else if (obterOpcaoMenuContato == "2")
                    //    controladorContato.SelecionarTodosOsContatos();

                    //else if (obterOpcaoMenuContato == "3")
                    //    controladorContato.EditarContato();

                    //else if (obterOpcaoMenuContato == "4")
                    //    controladorContato.ExcluirContato();

                }

                Console.Clear();
            }
        }
    }
}
