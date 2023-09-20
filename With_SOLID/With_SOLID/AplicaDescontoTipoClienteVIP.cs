using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace With_SOLID
{
    public class AplicaDescontoTipoClienteVIP : IAplicaDescontoStatusConta
    {
        public decimal AplicaDesconto(decimal preco)
        {
            return preco - (Constantes.DESCONTO_CLIENTE_VIP * preco);
        }
    }
}
