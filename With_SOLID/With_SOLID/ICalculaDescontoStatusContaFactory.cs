using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace With_SOLID
{
    public interface ICalculaDescontoStatusContaFactory
    {
        IAplicaDescontoStatusConta GetCalculDescontoStatusConta(StatusContaCliente statusContaCliente);
    }
}
