using System;
using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;

namespace TesteTDD.Tests
{
    [Binding]
    public class PassosParaValidarCPF
    {
        [Given(@"um cliente com CPF ""(.*)""")]
        public void DadoUmClienteComCPF(string p0)
        {
            var _cliente = Builder<Cliente>.CreateNew().With(_ => _.CPF = "123456").Build();
            ScenarioContext.Current.Add("cliente",_cliente);
        }

        [When(@"o CPF dele não estiver na lista do SPC ou Serasa")]
        public void QuandoOCPFDeleNaoEstiverNaListaDoSPCOuSerasa()
        {
            var _servicoExterno = new Mock<ServicoExterno>();
            _servicoExterno.Setup(_ => _.ValidarCPFSerasaESPS(It.IsAny<string>())).Returns(true);
            var _servicodeCliente = new ServicoDeCliente(_servicoExterno.Object);
            var _cliente = ScenarioContext.Current.Get<Cliente>("cliente");
            var _cpfNormal = _servicodeCliente.LiberarCadastro(_cliente);
            ScenarioContext.Current.Add("cpfNormal",_cpfNormal);

        }

        [When(@"o CPF dele estiver na lista do SPC ou Serasa")]
        public void QuandoOCPFDeleEstiverNaListaDoSPCOuSerasa()
        {
            var _servicoExterno = new Mock<ServicoExterno>();
            _servicoExterno.Setup(_ => _.ValidarCPFSerasaESPS(It.IsAny<string>())).Returns(false);
            var _servicodeCliente = new ServicoDeCliente(_servicoExterno.Object);
            var _cliente = ScenarioContext.Current.Get<Cliente>("cliente");
            var _cpfNormal = _servicodeCliente.LiberarCadastro(_cliente);
            ScenarioContext.Current.Add("cpfNormal", _cpfNormal);
        }

        [Then(@"o sistema deve liberar a aprovação de crédito")]
        public void EntaoOSistemaDeveLiberarAAprovacaoDeCredito()
        {
            var _cpfNormal = ScenarioContext.Current.Get<bool>("cpfNormal");
            Assert.IsTrue(_cpfNormal);
        }

        [Then(@"o sistema deve me avisar e impedir a aprovação de crédito")]
        public void EntaoOSistemaDeveMeAvisarEImpedirAAprovacaoDeCredito()
        {
            var _cpfNormal = ScenarioContext.Current.Get<bool>("cpfNormal");
            Assert.IsFalse(_cpfNormal);
        }
    }
}
