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
            decimal descontoPorFidelidade = (anosDeContaCliente > Constantes.DESCONTO_MAXIMO_POR_FIDELIDADE) ? (decimal)5 / 100 : (decimal)anosDeContaCliente / 100;

            switch (statusTipoContaCliente)
            {
                case StatusContaCliente.NaoRegistrado:
                    precoDepoisDoDesconto = precoProduto;
                    break;
                case StatusContaCliente.ClienteComum:
                    precoDepoisDoDesconto = precoProduto - (Constantes.DESCONTO_CLIENTE_COMUM * precoProduto);
                    precoDepoisDoDesconto = precoDepoisDoDesconto - (descontoPorFidelidade  * precoDepoisDoDesconto);
                    break;
                case StatusContaCliente.ClienteEspecial:
                    precoDepoisDoDesconto = (precoProduto - (Constantes.DESCONTO_CLIENTE_ESPECIAL * precoProduto));
                    precoDepoisDoDesconto  = precoDepoisDoDesconto - (descontoPorFidelidade * precoDepoisDoDesconto);
                    break;
                case StatusContaCliente.ClienteVIP:
                    precoDepoisDoDesconto = (precoProduto - (Constantes.DESCONTO_CLIENTE_VIP * precoProduto));
                    precoDepoisDoDesconto = precoDepoisDoDesconto - (descontoPorFidelidade * precoDepoisDoDesconto);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return precoDepoisDoDesconto;
        }
    }
}
