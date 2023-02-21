
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
    bool res = true;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j, k] = random.Next(10, 100);
                while (res == true)
                {
                    array[i, j, k] = random.Next(10, 100);
                    res = FindEliment(array[i, j, k], array);
                }
                res = true;
                Console.Write($"{array[i, j, k]}\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

bool FindEliment(int num, int[,,] array)
{
    bool res = false;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                if (num == array[i, j, k])
                {
                    res = true;
                }
            }
        }
    }
    return res;

}

void Print3DArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write($"{array[i, j, k]}\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
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
                    // не получается 

                    break;
                }
            case 5:
                {
                    //Напишите программу

                    break;
                }
            case -1: inWork = false; break;
        }
    }
}