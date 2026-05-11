Console.Write("Digite a idade: ");
int idade = int.Parse(Console.ReadLine());

if (idade <= 13)
{
    Console.WriteLine("É criança!!");
}
else if (idade > 13 && idade <= 18)
{
    Console.WriteLine("É adolescente!!");
}
else if (idade > 18 && idade <= 60)
{
    Console.WriteLine("É adulto!!");
}
else if (idade > 60)
{
    Console.WriteLine("É idoso!!");
}
else
{
    Console.WriteLine("Tivemos algum problema com a idade informada, tente novamente!!");
}