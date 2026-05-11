using System.ComponentModel;

int numero, atual, numA = 0, numB = 1;

Console.Write("Digite o numero limite para calcular o Fibonacci: ");
numero = int.Parse(Console.ReadLine());

Console.WriteLine(0);
while (numA < numero)
{
    atual = numA + numB;
    
    if(atual > numero) return;

    Console.WriteLine(atual);

    numA = numB;
    numB = atual;
}