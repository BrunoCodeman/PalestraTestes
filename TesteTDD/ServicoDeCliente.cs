using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTDD
{
    public class ServicoDeCliente
    {
        private readonly ServicoExterno _servicoExterno;
        public ServicoDeCliente(ServicoExterno servico)
        {
            _servicoExterno = servico;
        }

        public virtual bool LiberarCadastro(Cliente c)
        {
            return (!string.IsNullOrEmpty(c.CPF) && _servicoExterno.ValidarCPFSerasaESPS(c.CPF));
        }
    }
}
