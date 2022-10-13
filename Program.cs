while (true)
{
    Console.Write("Type task number(54, 56 or 58): ");
    string task = Console.ReadLine() ?? "0";
    if (task == "54") 
    {
        Task54();
        break;
    }
    else if (task == "56") 
    {
        Task56();
        break;
    }
    else if (task == "58") 
    {
        Task58();
        break;
    }
    else Console.WriteLine("Incorrect task number");
}
void Task54() //Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
{
    int[,] array2d = FillArrayRandom(CreateIntArray(
                                        UserNumberInput("enter number of rows: "),
                                        UserNumberInput("enter number of columns: ")),
                                     UserNumberInput("enter minimum generated number: "),
                                     UserNumberInput("enter maximum generated number: "));
    Console.WriteLine("original array");
    PrintArray(array2d);
    SortArrayRowElements(array2d);
    Console.WriteLine("sorted array");
    PrintArray(array2d);
}
void Task56() //Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
{
    int rows = 6;
    int columns = 4;
    int[,] arrayRectangle = FillArrayRandom(CreateIntArray(rows, columns),
                                            UserNumberInput("enter minimum generated number: "),
                                            UserNumberInput("enter maximum generated number: "));
    PrintArray(arrayRectangle);
    Console.WriteLine("row with lowest sum of elements is: {0}", FindLowestSumOfRowElements(arrayRectangle) +1);
    
}
void Task58() //Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
{
    int[,] matrixA = CreateIntArray(UserNumberInput("enter matrix A number of rows: "),
                                    UserNumberInput("enter matrix A number of columns: "));
    int[,] matrixB = CreateIntArray(UserNumberInput("enter matrix B number of rows: "),
                                    UserNumberInput("enter matrix B number of columns: "));                                
    matrixA = FillArrayRandom(matrixA, 0, 9);
    matrixB = FillArrayRandom(matrixB, 0, 9);
    
    Console.WriteLine("matrix A");
    PrintArray(matrixA);
    Console.WriteLine("matrix B");
    PrintArray(matrixB);
    
    if (matrixA.GetLength(1) == matrixB.GetLength(0))
    {
        int[,] matrixResult = MatrixMultiplication(matrixA, matrixB);
        Console.WriteLine("result of multiplication");
        PrintArray(matrixResult);
    }
    else Console.WriteLine("matrixes are incompatible");
    
}
int[,] CreateIntArray(int row, int col)
{
    int[,] array = new int[row, col];
    return array;
}
int[,] FillArrayRandom(int[,] array, int minValue, int maxValue)
{
    Random random = new Random();
    int row = array.GetLength(0);
    int col = array.GetLength(1);
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            array[i,j] = random.Next(minValue, maxValue + 1);
        }
    }
    return array;
}
void PrintArray(int[,] array)
{
    int row = array.GetLength(0);
    int col = array.GetLength(1);
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            Console.Write(array[i,j] + "\t");
        }
        Console.WriteLine();
    }
}
int UserNumberInput(string msg)
{
    int userNumber;
    while (true)
    {
        try
        {
            Console.Write(msg);
            userNumber = int.Parse(Console.ReadLine()!);
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Incorrect data entered");
        }
    }
    return userNumber;
}
int[,] SortArrayRowElements(int[,] array)
{
    int row = array.GetLength(0);
    int col = array.GetLength(1);
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            for (int k = 0; k < col -1; k++)
            {
                if (array[i,k] < array[i,k+1])
                {
                    (array[i,k], array[i,k+1]) = (array[i,k+1], array[i,k]);
                }
            }
        }
    }
    return array;
}
int FindLowestSumOfRowElements(int[,] array)
{
    int rowSumMin = int.MaxValue;
    int tempSum;
    int rowNumber = -10;
    int row = array.GetLength(0);
    int col = array.GetLength(1);
    for (int i = 0; i < row; i++)
    {
        tempSum = 0;
        for (int j = 0; j < col; j++)
        {
            tempSum += array[i,j];
        }
        if (rowSumMin > tempSum)
        {
            rowSumMin = tempSum;
            rowNumber = i;
        }
    }
    return rowNumber;
} 
int[,] MatrixMultiplication(int[,] a, int[,] b)
{
    
    int columnsB = b.GetLength(1);
    int rowsA = a.GetLength(0);
    int columnsA = a.GetLength(1);
    int[,] result = new int[rowsA, columnsB];
    int temp;
    for (int i = 0; i < rowsA; i++)
    {
        for (int j = 0; j < columnsB; j++)
        {
            temp = 0;
            for (int k = 0; k < columnsA; k++)
            {
                temp += a[i, k] * b[k, j];
            }
            result[i, j] = temp;
        }
    }
    return result;
}