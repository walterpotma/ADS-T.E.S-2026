//Passo a passo para criar uma solução de projeto em c#endregion

//1 - Criar a solução           dotnet new sln --output Nome
//2 - Entrar na pasta sln       cd nome da pasta
//3 - Criar o projeto           dotnet new Console --name Nome
//4 - Adicionar o projeto na sln dotnet sln add NomeProjeto

//Passo a passo para resolver o exercicio 06
//1 - Criar um vetor de valores inteiros com N posições
//2 - Criar um laço de repetição para percorrer o vetor
//3 - Atribuir um valor aleatório para cada posição
//4 - Imprimir o vetor sem ordenação

// Array.Sort(vetor);
// Array.Reverse(verto);

Console.Clear();

int tamanho = 100;
int[] vetor = new int[tamanho];

Random random = new Random();

Console.WriteLine("Não ordenado ainda: ");

for (int i = 0; i < vetor.Length; i++)
{
    vetor[i] = random.Next(200);
    Console.Write(vetor[i] + " ");
}

Console.WriteLine();

bool correto = true;

do
{
    correto = true;

    for (int j = 0; j < vetor.Length - 1; j++)
    {
        int maior;
        int menor;

        if (vetor[j] > vetor[j + 1])
        {
            maior = vetor[j];
            menor = vetor[j + 1];

            vetor[j] = menor;
            vetor[j + 1] = maior;
            correto = false;
        }
    }
} while (correto == false);

Console.WriteLine("Ordenado: ");

for (int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
}