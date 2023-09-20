using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace With_SOLID
{
    public class GerenciadorDeDescontos
    {
        private readonly ICalculaDescontoFidelidade _descontoFidelidade;
        public GerenciadorDeDescontos(ICalculaDescontoFidelidade descontoFidelidade)
        {
            _descontoFidelidade = descontoFidelidade;
        }

        public decimal AplicarDesconto(decimal precoProduto, StatusContaCliente statusTipoContaCliente, int anosDeContaCliente)
        {
            decimal precoDepoisDoDesconto = 0;

            switch (statusTipoContaCliente)
            {
                case StatusContaCliente.NaoRegistrado:
                    precoDepoisDoDesconto = new AplicaDescontoTipoClienteNaoRegistrado().AplicaDesconto(precoProduto);
                    break;
                case StatusContaCliente.ClienteComum:
                    precoDepoisDoDesconto = new AplicaDescontoTipoClienteComum().AplicaDesconto(precoProduto);
                    precoDepoisDoDesconto = _descontoFidelidade.AplicarDescontoFidelidade(precoDepoisDoDesconto, anosDeContaCliente);
                    break;
                case StatusContaCliente.ClienteEspecial:
                    precoDepoisDoDesconto = new AplicaDescontoTipoClienteEspecial().AplicaDesconto(precoProduto);
                    precoDepoisDoDesconto = _descontoFidelidade.AplicarDescontoFidelidade(precoDepoisDoDesconto, anosDeContaCliente);
                    break;
                case StatusContaCliente.ClienteVIP:
                    precoDepoisDoDesconto = new AplicaDescontoTipoClienteVIP().AplicaDesconto(precoProduto);
                    precoDepoisDoDesconto = _descontoFidelidade.AplicarDescontoFidelidade(precoDepoisDoDesconto, anosDeContaCliente);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return precoDepoisDoDesconto;
        }
    }
}
