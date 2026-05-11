decimal dolar = 5.17m;
decimal euro = 6.14m;
decimal peso_argentino = 0.05m;

Console.WriteLine("Digite o valor em reais: ");
decimal valor = decimal.Parse(Console.ReadLine());

Console.WriteLine($"Valor em dolar: {(valor / dolar).ToString("c2")}");
Console.WriteLine($"Valor em euro: {(valor / euro).ToString("c2")}");
Console.WriteLine($"Valor em peso argentino: {(valor / peso_argentino).ToString("c2")}");

// .ToString("c2") é para converter para reais