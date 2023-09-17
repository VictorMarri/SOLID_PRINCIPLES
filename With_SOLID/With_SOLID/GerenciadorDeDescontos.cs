using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace With_SOLID
{
    public class GerenciadorDeDescontos
    {
        public decimal AplicarDesconto(decimal precoProduto, StatusContaCliente statusTipoContaCliente, int anosDeContaCliente)
        {
            decimal precoDepoisDoDesconto = 0;
            decimal descontoPorFidelidade = (anosDeContaCliente > 5) ? (decimal)5 / 100 : (decimal)anosDeContaCliente / 100;

            switch (statusTipoContaCliente)
            {
                case StatusContaCliente.NaoRegistrado:
                    precoDepoisDoDesconto = precoProduto;
                    break;
                case StatusContaCliente.ClienteComum:
                    precoDepoisDoDesconto = precoProduto - (0.1m * precoProduto);
                    precoDepoisDoDesconto = precoDepoisDoDesconto - (descontoPorFidelidade  * precoDepoisDoDesconto);
                    break;
                case StatusContaCliente.ClienteEspecial:
                    precoDepoisDoDesconto = (precoProduto - (0.3m * precoProduto));
                    precoDepoisDoDesconto  = precoDepoisDoDesconto - (descontoPorFidelidade * precoDepoisDoDesconto);
                    break;
                case StatusContaCliente.ClienteVIP:
                    precoDepoisDoDesconto = (precoProduto - (0.5m * precoProduto));
                    precoDepoisDoDesconto = precoDepoisDoDesconto - (descontoPorFidelidade * precoDepoisDoDesconto);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return precoDepoisDoDesconto;
        }
    }
}
