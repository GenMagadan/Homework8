// Задача 54: Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного
// массива. Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

Console.WriteLine("Задайте размеры двухмерного массива: ");
int m = int.Parse(Console.ReadLine());
int n = int.Parse(Console.ReadLine());

int[,] array = GenerateArray2D(m, n);
PrintArray2D(array);

int[,] GenerateArray2D(int m, int n)
{
   int[,] array = new int[m, n];
   Random rand = new Random();

   for (int i = 0; i < array.GetLength(0); i++)
   {
      for (int j = 0; j < array.GetLength(1); j++)
      {
         array[i, j] = rand.Next(-9, 10);
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

int[,] SortArrayDesc(int[,] array)
{
   for (int i = 0; i < array.GetLength(0); i++)
   {
      for (int j = 0; j < array.GetLength(1); j++)
      {
         for (int k = 0; k < array.GetLength(1) - 1; k++)
         {
            if (array[i, k] < array[i, k + 1])
            {
               int temp = array[i, k + 1];
               array[i, k + 1] = array[i, k];
               array[i, k] = temp;
            }
         }
      }
   }
   return array;
}

Console.WriteLine();
Console.Write("Отсортированный массив");
SortArrayDesc(array);
PrintArray2D(array);