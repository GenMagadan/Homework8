// Задача 60. Сформируйте трёхмерный массив из неповторяющихся
// двузначных чисел. Напишите программу, которая будет построчно 
// выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

Console.WriteLine("Задайте размеры трехмерного массива: ");
int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());


int[] array1D = GenerateArray1D(a, b, c);
int[,,] array3D = GenerateArray3D(a, b, c, array1D);
PrintArray3D(array3D);
Console.WriteLine();

int[] GenerateArray1D(int a, int b, int c)
{
   int[] temp = new int[a * b * c];
   int number;
   for (int i = 0; i < temp.GetLength(0); i++)
   {
      temp[i] = new Random().Next(10, 100);
      number = temp[i];
      if (i >= 1)
      {
         for (int j = 0; j < i; j++)
         {
            while (temp[i] == temp[j])
            {
               temp[i] = new Random().Next(10, 100);
               j = 0;
               number = temp[i];
            }
            number = temp[i];
         }
      }
   }
   return temp;
}

int[,,] GenerateArray3D(int a, int b, int c, int[] temp)
{
   int[,,] array3D = new int[a, b, c];
   int count = 0;

   for (int i = 0; i < array3D.GetLength(0); i++)
   {
      for (int j = 0; j < array3D.GetLength(1); j++)
      {
         for (int k = 0; k < array3D.GetLength(2); k++)
         {
            array3D[i, j, k] = temp[count];
            count++;
         }
      }
   }
   return array3D;
}

void PrintArray3D(int[,,] array)
{
   for (int i = 0; i < array.GetLength(0); i++)
   {
      Console.WriteLine();
      for (int j = 0; j < array.GetLength(1); j++)
      {
         Console.WriteLine();
         for (int k = 0; k < array.GetLength(2); k++)
         {
            Console.Write($"{array[i, j, k]}->({i},{j},{k})  ");
         }
      }
   }
}

Dictionary<int, int> result = Search(array3D);
foreach (var row in result)
{
   Console.WriteLine($"Число {row.Key} повторяется {row.Value} раз");
}

Dictionary<int, int> Search(int[,,] array)
{
   Dictionary<int, int> element = new Dictionary<int, int>();
   for (int i = 0; i < array.GetLength(0); i++)
   {
      for (int j = 0; j < array.GetLength(1); j++)
      {
         for (int k = 0; k < array.GetLength(2); k++)
         {
            if (element.ContainsKey(array[i, j, k]))
            {
               element[array[i, j, k]] += 1;
            }
            else
            {
               element.Add(array[i, j, k], +1);
            }
         }
      }
   }
   return element;
}
