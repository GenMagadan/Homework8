// Задача 62. Напишите программу, которая заполнит спирально массив
// 4 на 4. Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

Console.WriteLine("Введите размер массива");
int a = Convert.ToInt32(Console.ReadLine());
int b = Convert.ToInt32(Console.ReadLine());


int[,] SpiralMatrix(int a, int b)
{
   int[,] array = new int[a, b];
   int number = 1;
   int startCol = 0;
   int endCol = b - 1;
   int startRow = 0;
   int endRow = a - 1;
   while (startCol <= endCol && startRow <= endRow)
   {
      for (int i = startCol; i <= endCol; i++)
      {
         array[startRow, i] = number;
         number++;
      }
      startRow++;
      for (int j = startRow; j <= endRow; j++)
      {
         array[j, endCol] = number;
         number++;
      }
      endCol--;
      for (int i = endCol; i >= startCol; i--)
      {
         array[endRow, i] = number;
         number++;
      }
      endRow--;
      for (int j = endRow; j >= startRow; j--)
      {
         array[j, startCol] = number;
         number++;
      }
      startCol++;

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
         if (array[i, j].ToString().Length == 1) { Console.Write($"0{array[i, j]}    "); }
         else if (array[i, j].ToString().Length == 2) { Console.Write($"{array[i, j]}    "); }
         else { Console.Write($"{array[i, j]}   "); }
      }
   }
}

int[,] spiralArray = SpiralMatrix(a, b);
PrintArray2D(spiralArray);