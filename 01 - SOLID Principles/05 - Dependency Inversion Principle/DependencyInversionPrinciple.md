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

![Imagem1](https://github.com/VictorMarri/SOLID_PRINCIPLES/assets/55095546/4d404853-583b-4173-b9fe-23fba387f878)

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

![Imagem2](https://github.com/VictorMarri/SOLID_PRINCIPLES/assets/55095546/6b194f38-6ab1-4afd-8ec6-d1e4fe12fab8)

## Acoplamentos  ruins:

Acoplamentos voltados à tipos instáveis, ou seja, aqueles  tipos que tem alta probabilidade de serem alterados, sejam por adição de novas funcionalidades, seja por outras classes que as substituam

![Imagem3](https://github.com/VictorMarri/SOLID_PRINCIPLES/assets/55095546/48367f88-460e-4167-90c5-81490cb8c1d7)

# Explicando o acoplamento ruim:

Esses acoplamentos são ruins pq, alem de serem altamente voláteis, eles tambem tem suas dependencias. Dessa forma, podemos inferir que, somente a dependencia de LeilaoController para LeilaoDao já carrega outras dependencias como:

![Imagem4](https://github.com/VictorMarri/SOLID_PRINCIPLES/assets/55095546/27a19d1b-467f-419d-92e7-d7b0771967d4)

Aqui, por exemplo, LeilaoController depende do DbContext, e se mudar algo no AppDbContext, impacta diretamente no Controller, o que não deveria acontecer. ****************************************************************************************Eu preciso achar uma maneira de remover essa dependencia.****************************************************************************************

Portanto, vamos criar abstrações, onde nosso codigo vai depender delas, e nao de classes concretas. Vamos remover por completo das dependencias. 

![Imagem5](https://github.com/VictorMarri/SOLID_PRINCIPLES/assets/55095546/2bfb0001-1013-45a5-97d8-a7eeab08e980)

# Passo-a-passo

Basicamente eu crio uma interface com as abstrações de lógica complexa da classe concreta q eu vou implementar ela:

![Imagem6](https://github.com/VictorMarri/SOLID_PRINCIPLES/assets/55095546/b2d2e4c1-8ef3-48a1-87e6-f3dc8fef2c4e)

Implemento essa interface na classe concreta:

![Imagem7](https://github.com/VictorMarri/SOLID_PRINCIPLES/assets/55095546/99837cbf-9f71-4a73-b93f-12d609a6e36a)

Crio a injeção de dependencia no startup:

Aqui, o .Net automaticamente vai fazer a injeção de toda instancia da interface para a classe concreta automaticamente.

![Imagem8](https://github.com/VictorMarri/SOLID_PRINCIPLES/assets/55095546/86f615db-f406-4d49-a775-b79867e7a6cd)

Injeto na classe que precisa da dependencia para termos acesso aos recursos:

![Imagem9](https://github.com/VictorMarri/SOLID_PRINCIPLES/assets/55095546/8db7966a-0332-4016-952a-c26d66684f12)

Injeção de Dependencia / Inversão de Dependencia / Inversão de controle

![Imagem10](https://github.com/VictorMarri/SOLID_PRINCIPLES/assets/55095546/c700d49c-205c-4f9c-a0d7-2ff547a248b5)

### Fontes de estudo

- https://stackify.com/dependency-inversion-principle/
- https://medium.com/@tbaragao/solid-d-i-p-dependency-inversion-principle-e87527f8d0be
- https://deviq.com/principles/dependency-inversion-principle
- https://dev.to/tamerlang/understanding-solid-principles-dependency-inversion-1b0f
