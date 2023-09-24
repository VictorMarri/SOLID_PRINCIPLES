using No_SOLID;

internal class Program
{
    private static void Main(string[] args)
    {
        GerDesc gerDesc = new GerDesc();
        Console.WriteLine("Valor da compra 1000 e fidelidade 10 anos (5%)\n");
        var resultado = gerDesc.Calcular(1000, 2, 10);
        Console.WriteLine($"Cliente tipo 2, 10 anos fidelidade, ={resultado}");
        var resultado1 = gerDesc.Calcular(1000, 3, 10);
        Console.WriteLine("Cliente tipo 3 o valor do desconto é de: { resultado1)");
        
        var resultado2 = gerDesc.Calcular(1000, 4, 10);
        Console.WriteLine($"Cliente tipo 4 o valor do desconto é de :{resultado2}\n");
        Console.WriteLine("Valor da compra 1000 e fidelidade 4 anos (4%)\n");
        var resultado3 = gerDesc.Calcular(3000, 2, 4);
        Console.WriteLine($"Cliente tipo 2, 10 anos fidelidade, ={resultado3}");
        var resultado4 = gerDesc.Calcular(1000, 3, 4);
        Console.WriteLine($"Para Cliente tipo 3 o valor do desconto é de: {resultado4}");
        var resultado5 = gerDesc.Calcular(1000, 4, 4);
        Console.WriteLine($"Para Cliente tipo 4 o valor do desconto é de:{resultado5}");

    }
}