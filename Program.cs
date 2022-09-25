/*
Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
m = 3, n = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9
*/
int m = 0, n = 0;
Random random = new Random();

if (!InputControl(ref m, ref n))
    return;

double[,] array = InitArray(m, n);

PrintArray(array);

# region methods

bool InputControl(ref int m, ref int n)
{
    int tryCount = 3;
    string inputStr = string.Empty;
    bool resultInputCheck = false;

    while (!resultInputCheck)
    {
        Console.WriteLine($"\r\nЗадайте размерность двумерного массива (m n) (количество попыток: {tryCount}):");
        inputStr = Console.ReadLine() ?? string.Empty;

        string[] inputDimension = inputStr.Split(new char[] { ' ', ';' });

        resultInputCheck = inputDimension.Length == 2 && int.TryParse(inputDimension[0], out m) && int.TryParse(inputDimension[1], out n);

        if (!resultInputCheck)
        {
            tryCount--;

            if (tryCount == 0)
            {
                Console.WriteLine("\r\nВы исчерпали все попытки.\r\nВыполнение программы будет остановлено.");
                return false;
            }
        }
    }

    return true;
}

double[,] InitArray(int m, int n)
{
    double[,] array = new double[m,n];

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            array[i,j] = Math.Round(GetRandomNumber(-100,100), 2);
        }
    }

    return array;
}

void PrintArray(double[,] array)
{
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Console.Write($"{array[i,j]}\t");
        }

        Console.WriteLine();
    }
}

double GetRandomNumber(double minimum, double maximum)
{     
    return random.NextDouble() * (maximum - minimum) + minimum;    
}

# endregion
