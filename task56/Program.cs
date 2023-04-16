// Задача 56: Задайте прямоугольный двумерный массив. Напишите 
// программу, которая будет находить строку с наименьшей суммой 
// элементов. Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт 
// номер строки с наименьшей суммой элементов: 1 строка

Console.WriteLine("Задайте размеры двухмерного массива: ");
int m = int.Parse(Console.ReadLine());
int n = int.Parse(Console.ReadLine());

int[,] array = GenerateArray2D(m, n);

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

PrintArray2D(array);

int[] SumOfElementRow(int[,] array)
{
   int[] array1D = new int[array.GetLength(0)];
   for (int i = 0; i < array.GetLength(0); i++)
   {
      array1D[i] = 0;
      for (int j = 0; j < array.GetLength(1); j++)
      {
         array1D[i] += array[i, j];
      }
   }
   return array1D;
}

void PrintArray(int[] array)
{
   Console.Write($"({string.Join(";  ", array)})");
}


void MinSumOfElement(int[] array)
{
   int min = array[0];
   int minString = 0;
   for (int i = 0; i < array.Length; i++)
   {
      if (array[i] < min)
      {
         min = array[i];
         minString = i;
      }
   }
   Console.Write($"Строка с минимальной суммой элементов {minString + 1}-я");
}

int[] newArray = SumOfElementRow(array);
Console.WriteLine();
PrintArray(newArray);
Console.WriteLine();
MinSumOfElement(newArray);
