using System.Collections;

var carrinho = new List<Produto>
{
    new Produto() { Nome = "Leite", Preco = 24.1},
    new Produto() { Nome = "Manteiga", Preco = 20.1}
};

var diasDaSemana = new DiasDaSemana();

// Using Foreach
foreach(var produto in carrinho)
{
    System.Console.WriteLine($"Produto: {produto.Nome}");
}

foreach(var dia in diasDaSemana)
{
    System.Console.WriteLine($"Dia da Semana: {dia}");
}

class Produto
{
    public string Nome { get; set; }
    public double Preco { get; set; }
}


class DiasDaSemana : IEnumerable<string>
{
    public IEnumerator<string> GetEnumerator()
    {
        yield return "Domingo";
        yield return "Segunda";
        yield return "Terça";
        yield return "Quarta";
        yield return "Quinta";
        yield return "Sexta";
        yield return "Sábado";
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}