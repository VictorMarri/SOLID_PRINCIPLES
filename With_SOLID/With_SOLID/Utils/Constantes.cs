using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace With_SOLID.Utils
{
    public class Constantes
    {
        //Uma alternativa pra isso é colocar essas variaveis dentro de um arquivo de configuração (Exemplo: appsettings.local.json)
        //E comandar isso de forma mais centralizada num azure devOps por exemplo.

        //Podemos tambem colocar essas variaveis dentro da propria classe que estivermos usando, desde que vc tenha certeza
        //De que não vamos usar essas constantes fora da classe implementada

        public const int DESCONTO_MAXIMO_POR_FIDELIDADE = 5;
        public const decimal DESCONTO_CLIENTE_COMUM = 0.1m;
        public const decimal DESCONTO_CLIENTE_ESPECIAL = 0.3m;
        public const decimal DESCONTO_CLIENTE_VIP = 0.5m;
    }
}
