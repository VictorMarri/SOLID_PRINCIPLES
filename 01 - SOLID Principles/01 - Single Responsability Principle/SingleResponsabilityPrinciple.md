# Single Responsability Principle

![S](https://github.com/VictorMarri/SOLID_PRINCIPLES/assets/55095546/a91a0c13-daa0-4195-83cf-c5ac8ff81d43)

> _Cada classe deve ter apenas uma responsabilidade a ser cumprida_

Esse principio tange principalmente a Coesão de código. Coesão pode ser definida como a afinidade funcional dos elementos de um módulo. É o relacionamento fluido e segregado entre os membros de um módulo, onde possuem uma relação direta e importante. Com isso, quanto mais bem definido o que a classe faz, mais coesa ela é. Se essa classe tem mais de um motivo pra mudar, ela já não é coesa. 

A ideia central do SRP é que cada classe deve se concentrar em fazer uma coisa e fazê-la bem. Isso não significa que uma classe deve ter apenas um método ou uma única linha de código, mas sim que ela deve estar relacionada a um único conjunto de funcionalidades ou responsabilidades.

### Exemplo em C#

Aqui está um exemplo simples em C# para ilustrar o SRP:

```csharp
using System;

// Classe que viola o SRP
public class Pedido
{
    public void CriarPedido() 
    {
        // Lógica para criar um novo pedido
        Console.WriteLine("Pedido criado com sucesso.");
    }

    public void EnviarEmailConfirmacao() 
    {
        // Lógica para enviar um e-mail de confirmação
        Console.WriteLine("E-mail de confirmação enviado.");
    }
}
```

Neste exemplo, a classe Pedido tem duas responsabilidades: criar um pedido e enviar um e-mail de confirmação, o que viola o SRP.

### Aplicando o SRP

Agora, vamos aplicar o SRP reorganizando o código:

```csharp
using System;

// Classe que segue o SRP
public class Pedido
{
    public void CriarPedido() 
    {
        // Lógica para criar um novo pedido
        Console.WriteLine("Pedido criado com sucesso.");
    }
}

public class EmailService
{
    public void EnviarEmailConfirmacao() 
    {
        // Lógica para enviar um e-mail de confirmação
        Console.WriteLine("E-mail de confirmação enviado.");
    }
}
```

Agora, a classe Pedido tem apenas a responsabilidade de criar pedidos, enquanto a classe EmailService cuida exclusivamente do envio de e-mails de confirmação. Cada classe tem uma única razão para mudar, tornando o código mais modular e fácil de manter.

Em resumo, o SRP incentiva a divisão de responsabilidades em classes separadas, tornando o código mais coeso, facilitando a manutenção e reduzindo o risco de introduzir erros quando as funcionalidades precisam ser alteradas.

### Fontes de estudo

- https://carloszan.medium.com/entendendo-solid-com-exemplos-em-c-98a983d47f
- https://medium.com/beelabacademy/princ%C3%ADpios-de-s-o-l-i-d-em-c-guia-pr%C3%A1tico-cbb1e6584284#:~:text=O%20SOLID%20%C3%A9%20um%20acr%C3%B4nimo,poderiam%20se%20encaixar%20nesta%20palavra.
- https://blog.cleancoder.com/uncle-bob/2014/05/08/SingleReponsibilityPrinciple.html
