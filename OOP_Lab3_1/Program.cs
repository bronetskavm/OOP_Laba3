
using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть кількість елементів масиву: ");
        int n = int.Parse(Console.ReadLine());

        // Оголошення масиву та генерація псевдовипадкових чисел 
        double[] array = new double[n];
        Random rnd = new Random();
        double minElement = double.MaxValue;

        for (int i = 0; i < n; i++)
        {
            double randomNumber = (rnd.NextDouble() * 11) - 7.51; // Генерувати числа в інтервалі [-7.51, 3.49] 
            array[i] = Math.Round(randomNumber, 2); // Заокруглення до 2 знаків після коми 

            if (array[i] < minElement)
            {
                minElement = array[i]; // Знайти мінімальний елемент 
            }
        }

        Console.WriteLine("Початковий масив:");
        PrintArray(array);

        // Знайти суму модулів елементів, які мають дробову частину меншу за 0.5 
        double sumOfModulus = 0;
        foreach (double element in array)
        {
            if (Math.Abs(element % 1) < 0.5)
            {
                sumOfModulus += Math.Abs(element);
            }
        }

        Console.WriteLine("Сума модулів елементів з дробовою частиною менше 0.5: " + sumOfModulus);

        // Впорядкувати елементи після мінімального за спаданням 
        double[] subArray = array.Skip(Array.IndexOf(array, minElement) + 1).ToArray();
        Array.Sort(subArray, (a, b) => b.CompareTo(a));
        Array.Copy(subArray, 0, array, Array.IndexOf(array, minElement) + 1, subArray.Length);


        Console.WriteLine("Масив після сортування:");
        PrintArray(array);
    }

    // Метод для виводу масиву 
    static void PrintArray(double[] arr)
    {
        foreach (double element in arr)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}
