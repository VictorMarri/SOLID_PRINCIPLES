using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace With_SOLID
{
    /// <summary>
    /// Classe Responsavel apenas pela criação das instancias corretas para cada tipo de cliente, e consequentemente o desconto
    /// </summary>
    public class CalculaDescontoStatusContaFactory : ICalculaDescontoStatusContaFactory
    {
        public IAplicaDescontoStatusConta GetCalculDescontoStatusConta(StatusContaCliente statusContaCliente)
        {
            IAplicaDescontoStatusConta calcular;

            switch (statusContaCliente)
            {
                case StatusContaCliente.NaoRegistrado:
                    calcular = new AplicaDescontoTipoClienteNaoRegistrado();
                    break;
                case StatusContaCliente.ClienteComum:
                    calcular = new AplicaDescontoTipoClienteComum();
                    break;
                case StatusContaCliente.ClienteEspecial:
                    calcular = new AplicaDescontoTipoClienteEspecial();
                    break;
                case StatusContaCliente.ClienteVIP:
                    calcular = new AplicaDescontoTipoClienteVIP();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return calcular;
        }
    }
}
