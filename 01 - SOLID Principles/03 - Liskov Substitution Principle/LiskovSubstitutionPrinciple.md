# L - Liskov Substitution Principle

![L](https://github.com/VictorMarri/SOLID_PRINCIPLES/assets/55095546/a005fd98-c2f0-4912-989b-4545b412adfb)

> **"Os objetos de uma superclasse devem poder ser substituídos por objetos de suas subclasses sem quebrarmos a aplicação."**

> Se para cada objeto **x1** do tipo **S** há um objeto **x2** do tipo **T**, de tal forma que, para todos os programas **P** definidos em termos de **T**, o comportamento de **P** não muda quando **x1** é substituído por **x2**, então **S** é um subtipo de **T**.

Se uma classe A é uma classe base de uma classe B, então, **qualquer instância de A pode ser substituída por uma instância de B sem causar erros ou resultados incorretos.** As subclasses devem respeitar o contrato definido pelas superclasses e não devem adicionar pré-condições mais fortes ou pós-condições mais fracas.

![TS](https://github.com/VictorMarri/SOLID_PRINCIPLES/assets/55095546/ed6aa020-080f-42ef-b326-c5dc82515359)

O princípio de Liskov basicamente determina que **objetos de uma SUPERCLASSE podem ser SUBSTITUÍDOS com objetos de suas SUBCLASSES, de forma a NÃO QUEBRAR A APLICAÇÃO.** Com isso, os objetos das suas SUBCLASSES devem se comportar da MESMA FORMA que os objetos da superclasse.

Um método sobrescrito (OVERRIDE) de uma SUPERCLASSE precisa aceitar o mesmo parâmetro (tipo, valor) que o método que está contido na SUPERCLASSE. Isso significa que não pode implementar regras de validações que restrinjam o uso da abstração.

A violação desse princípio acontece quando a **subclasse altera ou restringe o comportamento dos métodos herdados da superclasse de uma maneira que não esteja de acordo com o contrato estabelecido pela superclasse. Isso gera inconsistência no programa, e é isso que o princípio busca mitigar.**

Então, basicamente, podemos reger o princípio por algumas regras:

- A Subclasse tem que ter os mesmos membros públicos da Superclasse
- Esses membros devem ter a mesma assinatura
- Esses membros devem ter o mesmo comportamento que o seu membro da superclasse

# Passos para garantir a conformidade do princípio de Liskov.

### 1 - A assinatura dos métodos na subclasse deve ser compatível com a superclasse. A subclasse **não deve adicionar novos parâmetros aos métodos ou alterar seus tipos de retorno:**

```csharp
class Animal
{
    public virtual void EmitSound()
    {
        Console.WriteLine("Animal is making a sound");
    }
}

class Dog : Animal
{
    public override void EmitSound()
    {
        Console.WriteLine("Dog is barking");
    }
}
````

Aqui, como podemos ver, a subclasse ‘Dog’ substitui o método EmitSound() da superclasse ‘Animal’, mas não adiciona nenhum novo parâmetro ou altera o tipo de retorno (nesse caso não tem retorno, mas a ideia é a mesma). A assinatura do método na subclasse, nesse caso, é compatível com a da superclasse.

Agora vamos ver um exemplo errado, onde fere diretamente essa parte:

```csharp
class Animal
{
    public virtual void EmitSound()
    {
        Console.WriteLine("Animal is making a sound");
    }
}
````


```csharp
class Dog : Animal
{
    public override void EmitSound(int volume) // Violando a assinatura
    {
        Console.WriteLine("Dog is barking");
    }
}
````

Aqui, a classe ‘Dog’ está violando diretamente a assinatura do método EmitSound() da sua superclasse ‘Animal’, onde adiciona um novo parâmetro ‘volume’. Isso significa que objetos do tipo ‘Dog’ não podem mais ser substituídos corretamente pelos objetos do tipo ‘Animal’, assim, violando o princípio de Liskov.

### 2 - As pré-condições dos métodos na subclasse não devem ser mais fortes (não devem impor restrições mais rígidas) do que as pré-condições definidas na superclasse


```csharp
class Shape
{
    public virtual void Draw(int width, int height)
    {
        // Desenhar a forma com as dimensões fornecidas
    }
}
````


```csharp
class Rectangle : Shape
{
    public override void Draw(int width, int height)
    {
        if (width <= 0 || height <= 0)
        {
            throw new ArgumentException("As dimensões do retângulo devem ser positivas");
        }

        // Desenhar o retângulo com as dimensões fornecidas
    }
}
````

Como podemos ver, nesse exemplo, a subclasse ‘Rectangle’ tá adicionando uma pré-condiçõa ao metodo Draw() da superclasse ‘Shape’. A pré condição vai verificar se as dimensões do retagulo são positivas. Essa pré-condição não é mais forte do que a pré-condição definida na superclasse. 
