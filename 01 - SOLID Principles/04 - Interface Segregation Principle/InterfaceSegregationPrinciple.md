![I](https://github.com/VictorMarri/SOLID_PRINCIPLES/assets/55095546/3abe9783-38e9-4c79-a747-b5d506f98a2a)

> Clientes (quem chama o método) não devem ser forçados a depender de métodos que não irão usar.
> 

> Muitas interfaces especificas são melhores que uma interface única
> 

> Assim como as classes, as interfaces nao devem ser genéricas, mas sim ter uma responsabilidade única.
>

Quando temos interfaces com muitos comportamentos se espalhando pelo sistema, isso traz dificuldade e complexidade ao nosso código. Lá na frente, quando a aplicação estiver grande o suficiente, isso pode ser um problema gigantesco. 

A segregação por interfaces vem pra mitigar esse problema. O Principio da segregação por interfaces ajuda quando uma determinada interface se torna ‘Gorda’ ou genérica demais a ponto de muitas responsabilidades sendo atribuídas a ela. Podemos entao subdividir essa interface em interfaces menores com responsabilidades mais especificas/especializadas. 

******************************************************************************************************************************************Esse principio pode ser amplamente usado junto com o Liskov Substitution Principle!******************************************************************************************************************************************

# Objetivos do ISP

- Redução de efeitos colaterias e frequencia de alterações necessárias, dividindo o software em pequenas partes independentes
- Promover um **********************************************************baixo acoplamento do codigo.**********************************************************
- Ter interfaces que sejam somente focadas em sua responsabilidade (Single Responsability Principle)
- Reduzir dependencias no codigo

# Violação do principio

Vamos ver esse caso de exemplo:

```c-sharp
public interface ITelefone
{
	void Tocar();
    void Discar();
	void TirarFoto();
}
```


```c-sharp
public class TelefoneCelular : ITelefone
{
	public void Tocar()
	{
		Console.WriteLine("Eu toco");
	}

	public void Discar()
	{
		Console.WriteLine("Eu disco");
	}

	public void TirarFoto()
	{
		Console.WriteLine("Eu tiro foto");
	}
}
```


```c-sharp
public class TelefoneResidencial: ITelefone
{
	public void Tocar()
	{
		Console.WriteLine("Eu toco");
	}

	public void Discar()
	{
		Console.WriteLine("Eu disco");
	}

	public void TirarFoto()
	{
		throw new Exception("Este dispositivo não é capaz de tirar foto.");
	}
}
```
Bom, primeiramente podemos ver que ********************************a implementação das interfaces está correta. Todos são de fato, telefones, portanto, implementam metodos comuns a um telefone.******************************** 

Porem, se voce reparar, a classe TelefoneResidencial implementa um metodo vindo da interface chamado de ‘TirarFoto’, mas, sabemos que telefones residenciais não tiram fotos. 

Com isso, percebemos que criamos uma interface tão generica **************************************************a ponto de termos metodos que não serão utilizados pra algumas classes que a implementem.**************************************************

# Como resolvemos isso:

Pra resolvermos isso, nos basicamente vamos precisar de criar interfaces especificas pra cada classe.


```c-sharp
public interface ITelefone
{
	public void Tocar();
	public void Discar();
}
```

```c-sharp
public interface ITelefoneCelular : ITelefone
{
	public void TirarFoto();
	public void ConectarInternet();
}
```

OU

```c-sharp
public interface ITelefoneCelular
{
	public void Tocar();
	public void Discar();
	public void TirarFoto();
	public void ConectarInternet();
}
```

```c-sharp
public class TelefoneCelular : ITelefoneCelular
{
	public void Tocar();
	public void Discar();
	public void TirarFoto();
	public void ConectarInternet();
}
```

```c-sharp
public class Telefone : ITelefone
{
	public void Tocar();
	public void Discar();
}
```

Dessa forma, geramos facilidade de manutenção, pois temos especificidades nas classes clientes (que chamam as interfaces). Quebramos o acoplamento entre as classes que a implementação de interfaces gordas traz e ainda ganhamos coesao e eficiencia no codigo. 
