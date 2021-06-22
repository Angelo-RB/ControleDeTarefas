using ControleDeTarefas.Controlador;
using ControleDeTarefas.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestesProjetoTarefa
{
    [TestClass]
    public class TesteDosContatos
    {
        public ControladorContato controlador;
        public Contato contatoTeste;
        public TesteDosContatos()
        {
            controlador = new ControladorContato();
            contatoTeste = new Contato("Teste", "devteste@gmail.com", 123456789, "Academia", "Desenvolvedor");
        }

        [TestMethod]
        public void DeveInserirUmNovoContato()
        {
            controlador.InserirContato(contatoTeste);
        }

        [TestMethod]
        public void DeveAtualizarContato()
        {
            controlador.EditarContato(contatoTeste);
        }

        [TestMethod]
        public void DeveExcluirContato()
        {
            controlador.ExcluirContato(contatoTeste);
        }
    }
}
