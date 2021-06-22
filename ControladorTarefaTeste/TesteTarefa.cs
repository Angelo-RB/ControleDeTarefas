using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ControleDeTarefas.Dominio;
using ControleDeTarefas.Controlador;

namespace ControladorTarefaTeste
{
    [TestClass]
    public class TestesProjetoTarefa
    {        
        public ControladorTarefa controlador;
        public Tarefa tarefaTeste;
        //public TesteDaListaTarefa()
        //{
        //    controlador = new ControladorTarefa();
        //    TarefaTeste = new Tarefa("Testeprimario", new DateTime(2021, 06, 21), 1);
        //}

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
