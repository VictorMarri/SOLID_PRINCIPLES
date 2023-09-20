using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace With_SOLID
{
    public class CalculoDescontoFidelidade : ICalculaDescontoFidelidade
    {
        public decimal AplicarDescontoFidelidade(decimal preco, int tempoDeContaEmAnos)
        {
            decimal descontoPorFidelidade =  (tempoDeContaEmAnos > Constantes.DESCONTO_MAXIMO_POR_FIDELIDADE) ? 
                   (decimal)Constantes.DESCONTO_MAXIMO_POR_FIDELIDADE / 100 : 
                   (decimal)tempoDeContaEmAnos / 100;

            return preco - (descontoPorFidelidade * preco);
        }
    }
}
