
void Task_1()
{
    int[,] matrix = new int[ReadInt("first legth"), ReadInt("second legth")];
    FillRandomArray(matrix);
    PrintMatrix(matrix);
    Console.WriteLine("\nNew Array:\n");
    int[,] newMatrix = DescendingArray(matrix);
    PrintMatrix(newMatrix);
}

void Task_2()
{
    int[,] matrix = new int[ReadInt("first legth"), ReadInt("second legth")];
    FillRandomArray(matrix);
    PrintMatrix(matrix);
    int[] sumArray = SumArray(matrix);
    MinSum(sumArray);
}

void Task_3()
{
    Console.WriteLine("Введите первую матрицу");
    int[,] matrix1 = new int[ReadInt("first legth"), ReadInt("second legth")];
    FillRandomArray(matrix1);
    PrintMatrix(matrix1);
    Console.WriteLine("Введите вторую матрицу");
    int[,] matrix2 = new int[ReadInt("first legth"), ReadInt("second legth")];
    FillRandomArray(matrix2);
    PrintMatrix(matrix2);
    CompositionMatrix(matrix1, matrix2);
}

void Task_4()
{
    int[,,] array = new int[ReadInt("first legth"), ReadInt("second legth"), ReadInt("third legth")];
    FillRandomTreeArray(array);
}

void Task_5()
{
    int[,] array = new int[ReadInt("first legth"), ReadInt("second legth")];
    PrintMatrix(SpiralArray(array));
}

int ReadInt(string argumrntName)
{
    Console.Write($"Input {argumrntName}: ");

    int number = 0;
    while (!int.TryParse(Console.ReadLine(), out number))
    {
        Console.WriteLine("It's not a number");
    }
    return number;
}

void FillRandomArray(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = new Random().Next(1, 10);//[1; 10)
        }
    }
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] DescendingArray(int[,] matrix)
{
    int temp;
    int minK;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            minK = 0;
            for (int k = 1; k < matrix.GetLength(1) - j; k++)
            {
                if (matrix[i, minK] > matrix[i, k])
                {
                    minK = k;
                }
            }
            temp = matrix[i, minK];
            matrix[i, minK] = matrix[i, matrix.GetLength(1) - j - 1];
            matrix[i, matrix.GetLength(1) - j - 1] = temp;
        }
    }
    return matrix;
}

int[] SumArray(int[,] matrix)
{
    int[] sum = new int[matrix.GetLength(0)];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum[i] += matrix[i, j];
        }
    }
    return sum;
}

void MinSum(int[] array)
{
    int min = 0;

    for (int i = 1; i < array.Length; i++)
    {
        if (array[min] > array[i])
        {
            min = i;
        }
    }
    Console.WriteLine($"Наименьшая сумма элементов: {min + 1} строка");
}

void CompositionMatrix(int[,] a, int[,] b)
{
    if (a.GetLength(1) == b.GetLength(0))
    {
        int[,] c = new int[a.GetLength(0), b.GetLength(1)];

        for (int i = 0; i < c.GetLength(0); i++)
        {
            for (int j = 0; j < c.GetLength(1); j++)
            {
                for (int k = 0; k < b.GetLength(0); k++)
                {
                    c[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        PrintMatrix(c);
    }
    else
    {
        System.Console.WriteLine("решение не возможно ");
    }
}

void FillRandomTreeArray(int[,,] array)
{
    Random random = new Random();
    bool[] usedNumbers = new bool[90];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {

            for (int k = 0; k < array.GetLength(2); k++)
            {
                do
                {
                    array[i, j, k] = random.Next(10, 100);
                }
                while (usedNumbers[array[i, j, k] - 10]);
                usedNumbers[array[i, j, k] - 10] = true;
                Console.Write($"{array[i, j, k]}\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

int[,] SpiralArray(int[,] array)
{
    int n = array.GetLength(0);
    int value = 1;

    int rowStart = 0;
    int rowEnd = n - 1;
    int colStart = 0;
    int colEnd = n - 1;

    while (value <= n * n)
    {
        for (int i = colStart; i <= colEnd; i++)
        {
            array[rowStart, i] = value;
            value++;
        }

        for (int i = rowStart + 1; i <= rowEnd; i++)
        {
            array[i, colEnd] = value;
            value++;
        }

        for (int i = colEnd - 1; i >= colStart; i--)
        {
            array[rowEnd, i] = value;
            value++;
        }

        for (int i = rowEnd - 1; i >= rowStart + 1; i--)
        {
            array[i, colStart] = value;
            value++;
        }

        rowStart++;
        rowEnd--;
        colStart++;
        colEnd--;
    }
    return array;
}



bool inWork = true;

while (inWork)
{
    Console.Write("Выбери задачу ");

    if (int.TryParse(Console.ReadLine(), out int i))
    {
        switch (i)
        {
            case 1:
                {
                    Task_1();

                    break;
                }
            case 2:
                {
                    Task_2();

                    break;
                }
            case 3:
                {
                    Task_3();

                    break;
                }
            case 4:
                {
                    Task_4();

                    break;
                }
            case 5:
                {
                    Task_5();

                    break;
                }
            case -1: inWork = false; break;
        }
    }
}