using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using With_SOLID.Interfaces;

namespace With_SOLID.Descontos.DescontoTipoCliente.ClienteNaoRegistrado
{
    public class AplicaDescontoTipoClienteNaoRegistrado : IAplicaDescontoStatusConta
    {
        public decimal AplicaDesconto(decimal preco)
        {
            return preco;
        }
    }
}
