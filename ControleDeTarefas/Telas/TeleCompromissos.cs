using System;
using System.Collections.Generic;
using ControleDeTarefas.Controlador;
using ControleDeTarefas.Dominio;

namespace ControleDeTarefas.Telas
{
    public class TelaCompromissos : Tela<Compromissos>
    {
        private readonly ControladorCompromissos controlador;

        public TelaCompromissos(ControladorCompromissos ctrl) : base("Gerenciador de Compromissos")
        {
            controlador = ctrl;
        }

        public override void ObterOpcao()
        {

            Console.WriteLine("   ╔════════Menu Compromissos════════╗   ");
            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("║                                       ║");
            Console.WriteLine("║               Digite:                 ║");
            Console.WriteLine("║                                       ║");
            Console.WriteLine("║   1: Cadastrar um novo Compromisso    ║");
            Console.WriteLine("║   2: Editar um Compromisso            ║");
            Console.WriteLine("║   3: Excluir um Compromisso           ║");
            Console.WriteLine("║   4: Visualizar todos os Compromissos ║");
            Console.WriteLine("║                                       ║");
            Console.WriteLine("║═══════════════════════════════════════║");
            Console.WriteLine("║            S para sair                ║");
            Console.WriteLine("╚═══════════════════════════════════════╝");

        }

        public void CadastrarNovoCompromisso()
        {
            ConfigurarTela("Cadastrando uma novo Compromisso...");

            Console.Write("Digite o assunto do Compromisso: ");
            string assunto = Console.ReadLine();

            Console.Write("Digite o Local do compromisso: ");
            string local = Console.ReadLine();

            Console.Write("Digite a data do compromisso: ");
            DateTime DataDoCompromisso = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite a hora de inicio do compromisso: ");
            DateTime HoraInicio = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite a hora de termino do compromisso: ");
            DateTime HoraTermino = Convert.ToDateTime(Console.ReadLine());

            controlador.InserirNovoCompromisso(new Compromissos(assunto, local, DataDoCompromisso, HoraInicio, HoraTermino));

            ApresentarMensagem("Compromisso cadastrado com sucesso!", Mensagem.Sucesso);
        }

        public void AtualizarCompromisso()
        {
            ConfigurarTela("Atualizando um compromisso...");

            VisualizarTodosOsCompromisso();

            Console.Write("\nDigite o ID do compromisso que deseja atualizar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Compromissos compromissos = controlador.SelecionarCompromissoPorId(id);

            Console.Write("Digite o assunto do Compromisso: ");
            string assunto = Console.ReadLine();

            Console.Write("Digite o Local do compromisso: ");
            string local = Console.ReadLine();

            Console.Write("Digite a data do compromisso: ");
            DateTime DataDoCompromisso = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite a hora de inicio do compromisso: ");
            DateTime HoraInicio = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite a hora de termino do compromisso: ");
            DateTime HoraTermino = Convert.ToDateTime(Console.ReadLine());

            controlador.AtualizarCompromisso(compromissos);

            ApresentarMensagem("Compromisso atualizado com sucesso!", Mensagem.Sucesso);
        }

        public void ExcluirCompromisso()
        {
            ConfigurarTela("Excluindo um compromisso...");

            VisualizarTodosOsCompromisso();

            Console.Write("\nDigite o ID do contato que deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Compromissos c = controlador.SelecionarCompromissoPorId(id);

            controlador.ExcluirCompromisso(c);

            ApresentarMensagem("Compromisso excluído sucesso!", Mensagem.Sucesso);
        }

        public void VisualizarTodosOsCompromisso()
        {
            ConfigurarTela("Visualizando todos os compromissos...");

            List<Compromissos> compromissosConcluidos = controlador.SelecionarTodosOsCompromissos();

            if (ListaVazia(compromissosConcluidos))
            {
                ApresentarMensagem("Nenhum compromisso cadastrado!", Mensagem.Atencao);
                return;
            }

            string configuracaColunasTabela = "{0,-5} | {1,-25} | {2,-22} | {3,-3} | {4, -10} | {5, -14} | {5, -14}";

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Assunto", "Local", "Data Do Compromisso", "Hora Inicio", "Hora Termino");

            foreach (Compromissos compromissos in compromissosConcluidos)
            {
                Console.WriteLine(configuracaColunasTabela, compromissos.Id, compromissos.Assunto, compromissos.Local, compromissos.DataDoCompromisso, compromissos.HoraInicio, compromissos.HoraTermino);
            }
            Console.ReadLine();
        }

    }
}
