![D](https://github.com/VictorMarri/SOLID_PRINCIPLES/assets/55095546/56395000-e656-49f7-ac5f-0686b356f362)

A ideia geral desse principio é basicamente: **********************************************************************Módulos de alto nível, que proveem logicas complexas, devem facilmente ser reusáveis e não ser afetados por mudanças em módulos de baixo nível, que proveem recursos utilizáveis. Ambos devem depender de uma abstração (interface).**********************************************************************

Abstrações não devem depender de detalhes, e sim, detalhes devem depender de abstrações. 

**Classes de Alto nível:**

- Classes que **encapsulam logicas complexas.**

**Classes de Baixo nível:**

- Classes que implementam operações básicas como **acesso a disco, protocolos de rede, acesso a banco de dados**
Isso reforça o mantra da programação orientada a objetos: 

> ‘Programe para uma interface, não para uma implementação’

![Untitled](https://github.com/VictorMarri/SOLID_PRINCIPLES/assets/55095546/a40f824b-820a-44bb-8542-ffc197c720bf)

A ideia geral desse principio é basicamente: **********************************************************************Módulos de alto nível, que proveem logicas complexas, devem facilmente ser reusáveis e não ser afetados por mudanças em módulos de baixo nível, que proveem recursos utilizáveis. Ambos devem depender de uma abstração (interface).**********************************************************************

Abstrações não devem depender de detalhes, e sim, detalhes devem depender de abstrações. 

**Classes de Alto nível:**

- Classes que **encapsulam logicas complexas.**

**Classes de Baixo nível:**

- Classes que implementam operações básicas como **acesso a disco, protocolos de rede, acesso a banco de dados**

 ********************************************************************************************************************************************

Isso reforça o mantra da programação orientada a objetos: 

> ‘Programe para uma interface, não para uma implementação’
>

# Observando dependências

Se pegarmos esse codigo aqui, podemos ver algumas dependências.

Essas dependencias são:

[imagem1]

LeilaoController depende de:

- HttpGet
- HttpPost
- Controller
- Int
- String
- IActionResult
- AppDbContext
- Leilao
- LeilaoDao

************************************************************************************Todo código tem acoplamento, independente de qual seja. Acoplamento é fundamental para conversação de entidades e funcionalidades. Porem, existem acoplamentos bons e acoplamentos ruins.************************************************************************************

# Acoplamento:

Acoplamento diz respeito à dependência entre dois tipos. Num sistema orientado a objetos os acoplamentos são inevitáveis. O que devemos fazer é cuidar de sua qualidade. Acoplamentos bons são aqueles para tipos estáveis (que não vão mudar ou tem alta probabilidade de não mudar). Candidatos a tipos estáveis são aqueles que fazem parte da plataforma .NET e de APIs muito usadas. Acoplamentos ruins são aqueles para tipos instáveis. Exemplos dessa categoria são os tipos criados especificamente para nossa aplicação e principalmente implementações para mecanismos específicos (no nosso exemplo o `LeilaoDaoComEfCore`
).

## Acoplamentos bons:

- Acoplamentos para tipos estáveis (Tipos que muito dificilmente serão alterados)

[Imagem2]

## Acoplamentos  ruins:

Acoplamentos voltados à tipos instáveis, ou seja, aqueles  tipos que tem alta probabilidade de serem alterados, sejam por adição de novas funcionalidades, seja por outras classes que as substituam

[Imagem3]

# Explicando o acoplamento ruim:

Esses acoplamentos são ruins pq, alem de serem altamente voláteis, eles tambem tem suas dependencias. Dessa forma, podemos inferir que, somente a dependencia de LeilaoController para LeilaoDao já carrega outras dependencias como:

[Imagem4]

Aqui, por exemplo, LeilaoController depende do DbContext, e se mudar algo no AppDbContext, impacta diretamente no Controller, o que não deveria acontecer. ****************************************************************************************Eu preciso achar uma maneira de remover essa dependencia.****************************************************************************************

Portanto, vamos criar abstrações, onde nosso codigo vai depender delas, e nao de classes concretas. Vamos remover por completo das dependencias. 

[Imagem5]

# Passo-a-passo

Basicamente eu crio uma interface com as abstrações de lógica complexa da classe concreta q eu vou implementar ela:

[Imagem6]

Implemento essa interface na classe concreta:

[Imagme7]

Crio a injeção de dependencia no startup:

Aqui, o .Net automaticamente vai fazer a injeção de toda instancia da interface para a classe concreta automaticamente.

[Iamgem8]

Injeto na classe que precisa da dependencia para termos acesso aos recursos:

[Imagem9]

Injeção de Dependencia / Inversão de Dependencia / Inversão de controle

Imagem10
