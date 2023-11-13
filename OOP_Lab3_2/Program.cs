using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть кількість рядків масиву (n): ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Введіть кількість стовпців масиву (m): ");
        int m = int.Parse(Console.ReadLine());

        // Оголошення та ініціалізація двовимірного масиву
        double[,] array = new double[n, m];
        Random rnd = new Random();

        // Заповнення масиву псевдовипадковими числами
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                double randomNumber = (rnd.NextDouble() * 49.34) - 42.31; // Генерувати числа в інтервалі [-42.31, 7.03]
                array[i, j] = Math.Round(randomNumber, 2); // Заокруглення до 2 знаків після коми
            }
        }

        Console.WriteLine("Початковий двовимірний масив:");
        PrintArray(array);

        // Визначення кількості рядків без від'ємних елементів
        int rowsWithoutNegative = 0;
        for (int i = 0; i < n; i++)
        {
            bool hasNegative = false;
            for (int j = 0; j < m; j++)
            {
                if (array[i, j] < 0)
                {
                    hasNegative = true;
                    break;
                }
            }
            if (!hasNegative)
            {
                rowsWithoutNegative++;
            }
        }
        Console.WriteLine("Кількість рядків без від'ємних елементів: " + rowsWithoutNegative);

        // Поміняти порядок слідування елементів у стовпцях на протилежний
        for (int j = 0; j < m; j++)
        {
            for (int i = 0; i < n / 2; i++)
            {
                double temp = array[i, j];
                array[i, j] = array[n - i - 1, j];
                array[n - i - 1, j] = temp;
            }
        }

        Console.WriteLine("Масив після зміни порядку у стовпцях:");
        PrintArray(array);
    }

    // Метод для виводу двовимірного масиву
    static void PrintArray(double[,] arr)
    {
        int n = arr.GetLength(0);
        int m = arr.GetLength(1);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(arr[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
