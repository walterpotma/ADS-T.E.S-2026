Console.Write("Digite o numero Um: ");
int numOne = int.Parse(Console.ReadLine());
Console.Write("Digite o numero dois: ");
int numTwo = int.Parse(Console.ReadLine());

if (numOne > numTwo)
{
    Console.WriteLine("!!O primeiro numero é maior que o segundo!!");
}
else if (numOne < numTwo)
{
    Console.WriteLine("!!O segundo numero é maior que o primeiro!!");
}
else
{
    Console.WriteLine("!!Os numeros são Iguais!!");
}