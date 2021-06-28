using System;
using System.Collections.Generic;
using ControleDeTarefas.Controlador;
using ControleDeTarefas.Dominio;

namespace ControleDeTarefas.Telas
{
    public class TelaTarefa : Tela<Tarefa>
    {
        private readonly ControladorTarefa controlador;
        public TelaTarefa(ControladorTarefa ctrl) : base("Controle de Tarefas")
        {
            controlador = ctrl;
        }
        public override void ObterOpcao()
        {
            Console.Clear();
            Console.WriteLine("    ╔═════════Menu Tarefa═════════╗    ");
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║                                    ║");
            Console.WriteLine("║               Digite:              ║");
            Console.WriteLine("║                                    ║");
            Console.WriteLine("║   1: Cadastrar uma nova tarefa     ║");
            Console.WriteLine("║   2: Editar uma tarefa             ║");
            Console.WriteLine("║   3: Excluir um Contato            ║");
            Console.WriteLine("║   4: Visualizar tarefas em aberto  ║");
            Console.WriteLine("║   5: Visualizar tarefas Concluídas ║");
            Console.WriteLine("║                                    ║");
            Console.WriteLine("║════════════════════════════════════║");
            Console.WriteLine("║            S para sair             ║");
            Console.WriteLine("╚════════════════════════════════════╝");

        }

        //public bool OpcaoInvalida(string opcao)
        //{
        //    if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "S" && opcao != "s")
        //    {
        //        Console.WriteLine("Opção inválida");
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        public void CadastrarNovaTarefa()
        {
            ConfigurarTela("Cadastrando uma nova tarefa...");

            Console.Write("Digite o título da tarefa: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a data de abertura da tarefa Ex(dia/mês/ano): ");
            DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());

            Prioridade prioridade;
            string strPrioridade;

            do
            {
                Console.WriteLine("Qual a prioridade da tarefa? (Alta, Media ou Baixa)");
                strPrioridade = Console.ReadLine();

            } while (strPrioridade != "Alta" && strPrioridade != "Media" && strPrioridade != "Baixa");

            prioridade = ConfiguracoesPrioridade.DefinirPrioridade(strPrioridade);

            controlador.InserirTarefa(new Tarefa(titulo, dataAbertura, (int)prioridade));

            ApresentarMensagem("Tarefa cadastrada com sucesso!", Mensagem.Sucesso);
        }

        public void AtualizarTarefa()
        {
            ConfigurarTela("Atualizando uma tarefa...");

            VisualizarTarefasEmAberto();

            Console.Write("\nDigite o ID da tarefa que deseja atualizar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Tarefa tarefa = controlador.SelecionarTarefaPorId(id);

            Console.Write("Digite o título da tarefa: ");
            tarefa.Titulo = Console.ReadLine();

            Prioridade prioridade;
            string strPrioridade;

            do
            {
                Console.WriteLine("Qual a prioridade da tarefa? (Alta, Media ou Baixa)");
                strPrioridade = Console.ReadLine();

            } while (strPrioridade != "Alta" && strPrioridade != "Media" && strPrioridade != "Baixa");

            prioridade = ConfiguracoesPrioridade.DefinirPrioridade(strPrioridade);

            tarefa.Prioridade = (int)prioridade;

            controlador.EditaTarefa(tarefa);

            ApresentarMensagem("Tarefa atualizada com sucesso!", Mensagem.Sucesso);
        }

        public void ExcluirTarefa()
        {
            ConfigurarTela("Excluindo uma tarefa...");

            VisualizarTodasAsTarefas();

            Console.Write("\nDigite o ID da tarefa que deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Tarefa l = controlador.SelecionarTarefaPorId(id);

            controlador.ExcluirTarefa(l);

            ApresentarMensagem("Tarefa excluída sucesso!", Mensagem.Sucesso);
        }

        public void VisualizarTodasAsTarefas()
        {
            ConfigurarTela("Visualizando todas as tarefas...");

            List<Tarefa> tarefas = controlador.SelecionarTodasAsTarefas();

            if (ListaVazia(tarefas))
            {
                ApresentarMensagem("Nenhuma tarefa cadastrada!", Mensagem.Atencao);
                return;
            }

            string configuracaColunasTabela = "{0,-5} | {1,-25} | {2,-22} | {3,-3} | {4, -10}";

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Título", "Data de Criação", "Prioridade");

            foreach (Tarefa tarefa in tarefas)
            {
                Console.WriteLine(configuracaColunasTabela, tarefa.Id, tarefa.Titulo, tarefa.DataCriacao.ToShortDateString(), tarefa.Prioridade);
            }
            Console.ReadLine();
        }

        public void VisualizarTarefasEmAberto()
        {
            ConfigurarTela("Visualizando tarefas em aberto...");

            List<Tarefa> tarefasEmAberto = controlador.SelecionarTodasAsTarefasEmAberto();

            if (ListaVazia(tarefasEmAberto))
            {
                ApresentarMensagem("Nenhuma tarefa em aberto!", Mensagem.Atencao);
                return;
            }

            string configuracaColunasTabela = "{0,-5} | {1,-25} | {2,-22} | {3,-3} | {4, -10}";

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Título", "Data de Criação", "%", "Prioridade");

            foreach (Tarefa tarefa in tarefasEmAberto)
            {
                Console.WriteLine(configuracaColunasTabela, tarefa.Id, tarefa.Titulo, tarefa.DataCriacao.ToShortDateString(), tarefa.Prioridade);
            }
            Console.ReadLine();
        }

        public void VisualizarTarefasConcluidas()
        {
            ConfigurarTela("Visualizando tarefas concluídas...");

            List<Tarefa> tarefaConcluida = controlador.SelecionarTodasAsTarefasConcluidas();

            if (ListaVazia(tarefaConcluida))
            {
                ApresentarMensagem("Nenhuma tarefa concluída!", Mensagem.Atencao);
                return;
            }

            string configuracaColunasTabela = "{0,-5} | {1,-25} | {2,-22} | {3,-22} | {4,-4}";

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Título", "Data de Criação", "Data de Conclusão", "Prioridade");

            foreach (Tarefa tarefa in tarefaConcluida)
            {
                Console.WriteLine(configuracaColunasTabela, tarefa.Id, tarefa.Titulo, tarefa.DataCriacao.ToShortDateString(),
                    tarefa.DataConclusao.ToShortDateString(), tarefa.Prioridade);
            }

            Console.ReadLine();
        }
    }
}
