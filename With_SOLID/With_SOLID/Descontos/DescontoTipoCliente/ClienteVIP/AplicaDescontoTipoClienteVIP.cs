using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using With_SOLID.Interfaces;
using With_SOLID.Utils;

namespace With_SOLID.Descontos.DescontoTipoCliente.ClienteVIP
{
    public class AplicaDescontoTipoClienteVIP : IAplicaDescontoStatusConta
    {
        public decimal AplicaDesconto(decimal preco)
        {
            return preco - Constantes.DESCONTO_CLIENTE_VIP * preco;
        }
    }
}
