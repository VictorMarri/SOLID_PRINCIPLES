using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace With_SOLID
{
    public class GerenciadorDeDescontos
    {
        private readonly ICalculaDescontoStatusContaFactory _factoryStatusConta;
        private readonly ICalculaDescontoFidelidade _descontoFidelidade;

        public GerenciadorDeDescontos(ICalculaDescontoFidelidade descontoFidelidade, ICalculaDescontoStatusContaFactory factory)
        {
            _descontoFidelidade = descontoFidelidade;
            _factoryStatusConta = factory;
        }

        public decimal AplicarDesconto(decimal precoProduto, StatusContaCliente statusTipoContaCliente, int anosDeContaCliente)
        {
            decimal precoFinal= 0, precoDescontoPorStatusConta = 0; 

            precoDescontoPorStatusConta = _factoryStatusConta.GetCalculDescontoStatusConta(statusTipoContaCliente).AplicaDesconto(precoProduto);

            precoFinal = _descontoFidelidade.AplicarDescontoFidelidade(precoDescontoPorStatusConta, anosDeContaCliente);

            return precoFinal;
        }
    }
}
