// Задача 58: Задайте две матрицы. Напишите программу, которая будет
// находить произведение двух матриц. Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

Console.WriteLine("Задайте размеры первой матрицы: ");
int rowMatrix1 = int.Parse(Console.ReadLine());
int colMatrix1 = int.Parse(Console.ReadLine());
Console.WriteLine("Задайте размеры второй матрицы: ");
int rowMatrix2 = int.Parse(Console.ReadLine());
int colMatrix2 = int.Parse(Console.ReadLine());

Console.WriteLine();
int[,] matrix1 = GenerateArray2D(rowMatrix1, colMatrix1);
Console.Write("Первая матрица");
PrintArray2D(matrix1);
Console.WriteLine();
int[,] matrix2 = GenerateArray2D(rowMatrix2, colMatrix2);
Console.Write("Вторая матрица");
PrintArray2D(matrix2);
Console.WriteLine();

int[,] GenerateArray2D(int m, int n)
{
   int[,] array = new int[m, n];
   Random rand = new Random();

   for (int i = 0; i < array.GetLength(0); i++)
   {
      for (int j = 0; j < array.GetLength(1); j++)
      {
         array[i, j] = rand.Next(1, 10);
      }
   }
   return array;
}

void PrintArray2D(int[,] array)
{
   for (int i = 0; i < array.GetLength(0); i++)
   {
      Console.WriteLine();
      for (int j = 0; j < array.GetLength(1); j++)
      {
         if (array[i, j].ToString().Length == 1) { Console.Write($"{array[i, j]}     "); }
         else if (array[i, j].ToString().Length == 2) { Console.Write($"{array[i, j]}    "); }
         else { Console.Write($"{array[i, j]}   "); }
      }
   }
}

if (matrix1.GetLength(1) != matrix2.GetLength(0))
{
   Console.WriteLine("Матрицы не могут быть перемножены");
   return;
}

int[,] MultiplicationMatrix(int[,] matrix1, int[,] matrix2)
{
   int[,] matrix3 = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
   for (int i = 0; i < matrix1.GetLength(0); i++)
   {
      for (int j = 0; j < matrix2.GetLength(1); j++)
      {
         for (int k = 0; k < matrix1.GetLength(0); k++)
         {
            matrix3[i, j] += matrix1[i, k] * matrix2[k, j];
         }
      }
   }
   return matrix3;
}

Console.Write("Произведение матриц");
int[,] matrix3 = MultiplicationMatrix(matrix1, matrix2);
PrintArray2D(matrix3);