using System;
using NUnit.Framework;
using FizzWare.NBuilder;
using Moq;
namespace TesteTDD.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase]
        public void Deve_retornar_true_para_um_cpf_sem_restricao()
        {
            var _cliente = Builder<Cliente>.CreateNew().With(_ => _.CPF = "123456").Build();
            var _servico = new Mock<ServicoExterno>();
            _servico.Setup(_ => _.ValidarCPFSerasaESPS(It.IsAny<string>())).Returns(true);
            var _servicoDeCliente = new ServicoDeCliente(_servico.Object);
            var _retorno = _servicoDeCliente.LiberarCadastro(_cliente);
            Assert.IsTrue(_retorno);    


        }

        [TestCase]
        public void Deve_retornar_false_para_um_cpf_com_restricao()
        {
            var _cliente = Builder<Cliente>.CreateNew().With(_ => _.CPF = "123456").Build();
            var _servico = new Mock<ServicoExterno>();
            _servico.Setup(_ => _.ValidarCPFSerasaESPS(It.IsAny<string>())).Returns(false);
            var _servicoDeCliente = new ServicoDeCliente(_servico.Object);
            var _retorno = _servicoDeCliente.LiberarCadastro(_cliente);
            Assert.IsFalse(_retorno);  
        }

        [TestCase]
        public void Deve_retornar_false_para_cpf_invalido()
        {
            var _cliente = Builder<Cliente>.CreateNew().With(_ => _.CPF = "").Build();
            var _servico = new Mock<ServicoExterno>();
            _servico.Setup(_ => _.ValidarCPFSerasaESPS(It.IsAny<string>())).Returns(true);
            var _servicoDeCliente = new ServicoDeCliente(_servico.Object);
            var _retorno = _servicoDeCliente.LiberarCadastro(_cliente);
            Assert.IsFalse(_retorno);  
        }

    }
}
