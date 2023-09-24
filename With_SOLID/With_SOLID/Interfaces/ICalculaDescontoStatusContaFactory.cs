using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using With_SOLID.Enums;

namespace With_SOLID.Interfaces
{
    public interface ICalculaDescontoStatusContaFactory
    {
        IAplicaDescontoStatusConta GetCalculDescontoStatusConta(StatusContaCliente statusContaCliente);
    }
}
