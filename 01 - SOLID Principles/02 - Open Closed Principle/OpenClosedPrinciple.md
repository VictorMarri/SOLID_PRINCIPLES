# Open Closed Principle

![o](https://github.com/VictorMarri/SOLID_PRINCIPLES/assets/55095546/db516662-2cf5-4024-a369-bb1cc9c822f6)

_As entidades do software (classes), devem estar abertas para extensão, e fechadas para modificação/alteração._

_O OCP anda lado a lado com o strategy pattern, que consiste em definir uma família de algoritmos, encapsular cada um deles e torná-los intercambiáveis. Dessa forma, permite-se que o algoritmo varie independentemente dos clientes que o utilizam._

Primeiramente precisamos entender a diferença fundamental entre **************************************estender e alterar************************************** uma entidade/classe. 

### Estender/Extensibilidade:

Incluir novas funcionalidades, sem ter a necessidade de ‘mexer’ no que já está desenvolvido, mantendo a estabilidade do código. Essa é uma das chaves da orientação a objetos, pois, quando um comportamento ou funcionalidade precisa ser adicionado é esperado que as existentes sejam estendidas e não alteradas. Dessa forma, nosso código original permanece intacto e confiável, enquanto as novas funcionalidades são implementadas através da extensibilidade. 

### Alterar:

Alterar é nada mais do que incluir novas funcionalidades num código, de maneira a ‘mexer’ no que já está pronto e funcional. Isso geralmente causa impactos no código e gera insegurança acerca da funcionalidade do código que participou da alteração. 

A razão por trás desse principio é que nós já temos uma classe/modulo desenvolvido e o mesmo já passou pelo processo de testes unitários. Então, nós não devemos mudar a classe de forma que afete as funcionalidades existentes. Devemos desenvolver um módulo/classe de uma maneira que possibilite seu comportamento a ser estendido sem alterar seu código base.

## Quando deve ser aplicado?

O Princípio Aberto-Fechado (OCP) deve ser aplicado em **situações em que se espera que o sistema seja facilmente estendido sem que seja necessário modificar o código existente.** Isso geralmente ocorre em sistemas que têm **requisitos de mudança frequentes ou sistemas que precisam suportar um grande número de casos de uso diferentes.**

Por outro lado, o OCP pode não ser tão importante em sistemas pequenos ou em situações em que se sabe que os requisitos do sistema serão estáveis e não mudarão com frequência. Nestes casos, o esforço necessário para projetar o sistema para atender ao OCP pode não justificar os benefícios potenciais.

Em resumo, a aplicação do OCP depende das necessidades e requisitos do sistema em questão, bem como das expectativas de mudança futura.

## Como implementar o principio Aberto/Fechado?


1. Criamos novas classes derivadas das quais devem ser herdadas da classe base original
2. Permitir que o cliente acesse a classe original com uma interface abstrata
3. Sempre que um novo requisito ou mudança chegar, em vez de mexer na funcionalidade existente, criamos uma classe derivadas e deixamos a implementação da classe base da maneira que está.

## Consequências de não seguir o principio Aberto/Fechado

1. Se permitirmos que uma classe ou função tenha mais logica adicionada, vamos ter que testar todas as funcionalidades nas quais incluem também as funcionalidades antigas da aplicação.
2. **Se não seguirmos o principio Aberto/Fechado, estamos automaticamente violando o principio da responsabilidade única, pq o módulo/classe vai ter múltiplas responsabilidades.**********************
3. Se implementarmos todas as funcionalidades numa única classe, a manutenção da classe, a longo prazo, vai se tornar muito difícil.

# Exemplo Código 1:

```csharp
public enum TipoCliente
{
  Comum = 1,
  Associado = 2, 
  Especial = 3
}

public class Pedido 
{
  public double DescontoPedido(double valor, TipoCliente tipoCliente)
  {
    double valorFinalPedido;

    if(tipoCliente == TipoCliente.Especial)
    {
      valorFinalPedido = valor - 50;
    }
    else if(tipoCliente == TipoCliente.Associado)
    {
      valorFinalPedido = valor - 10;
    }
    else
    {
      valorFinalPedido = valor;
    }

    return valorFinalPedido;
  }
}
```

Essa classe **'Pedido' não está fechada para modificações, e não está aberta para extensão.**

1. Precisamos ‘Alterar’ o código que já existe na classe **Pedido**
2. Essa classe Pedido deverá ser substituída em produção
3. Corremos o risco de introduzir um erro/bug nessa modificação feita e quebrar tudo
4. Esse erro afetaria toda a classe Pedido, e não somente a parte do código incluída.
5. Teríamos que testar a classe Pedido novamente para todos os tipos de clientes

[x] colocar aqui imagens do OCP

### Estendendo utilizando herança:

O Código fica assim aplicando o principio utilizando-se de herança:

```csharp
//Essa classe ta Fechada para alteração, e aberta para extenção, para ser herdada
public class Pedido {

  protected double valorFinalPedido;
  
  public virtual double DescontoPedido(double valor)
  {
    return valorFinalPedido;
  }
}
```

```csharp
public class DescontoClienteAssociado : Pedido
{
  public override double DescontoPedido(double valor)
  {
    return valorFinalPedido - 10
  }
}

```

```csharp
public class DescontoClienteEspecial : Pedido
{
  public override DescontoPedido(double valor)
  {
    return valorFinalPedido - 50;
  }
}
```

```csharp
public class DescontoClienteVip : Pedido 
{
  public override double DescontoPedido(double valor)
  {
    return valorFinalPedido - 100;
  }
}
```

## Ou podemos, ainda, fazer de forma mais abstraida ainda

```csharp
public class Pedido {

  protected double valorFinalPedido; 
  
  public virtual double DescontoPedido(double valor)
  {
    return valorFinalPedido;
  }
}
```

```csharp
public class DescontoClienteAssociado : Pedido
{
  public override double DescontoPedido(double valor)
  {
    return base.DescontoPedido(valor) - 10
  }
}
```

```csharp
public class DescontoClienteEspecial : Pedido
{
  public override DescontoPedido(double valor)
  {
    return base.DescontoPedido(valor) - 50;
  }
}
```

```csharp
public class DescontoClienteVip : Pedido 
{
  public override double DescontoPedido(double valor)
  {
    return base.DescontoPedido(valor) - 100;
  }
}
```
