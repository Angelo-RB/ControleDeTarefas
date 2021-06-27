using ControleDeTarefas.Controlador;
using ControleDeTarefas.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestesProjetoTarefa
{
    [TestClass]
    public class TesteContato
    {
        public ControladorContato controlador;
        public Contato contatoTeste;
        public TesteContato()
        {
            controlador = new ControladorContato();
            contatoTeste = new Contato("Teste3", "admemail@teste.com", "998635265", "Academia", "Suporte");
        }

        [TestMethod]
        public void DeveInserirUmNovoContato()
        {
            controlador.InserirContato(contatoTeste);
        }

        [TestMethod]
        public void DeveAtualizarContato()
        {
            controlador.AtualizarContato(contatoTeste);
        }

        [TestMethod]
        public void DeveExcluirContato()
        {
            controlador.ExcluirContato(contatoTeste);
        }
    }
}
