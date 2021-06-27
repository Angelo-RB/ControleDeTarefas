using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ControleDeTarefas.Dominio;
using ControleDeTarefas.Controlador;

namespace ControladorTarefaTeste
{
    [TestClass]
    public class TesteDaListaTarefa
    {
        public ControladorTarefa controlador;
        public Tarefa tarefaTeste;
        public TesteDaListaTarefa()
        {
            controlador = new ControladorTarefa();
            tarefaTeste = new Tarefa("Teste1", new DateTime(2021, 06, 21), 1);
        }

        [TestMethod]
        public void DeveInserirUmaTarefaNova()
        {
            controlador.InserirTarefa(tarefaTeste);
        }

        [TestMethod]
        public void DeveExcluirUmaTarefa()
        {
            controlador.ExcluirTarefa(tarefaTeste);
        }

    }
}
