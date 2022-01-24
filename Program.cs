using System;

namespace Forth_Homework
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] array = GetRandomArray();

            string evenStr = string.Empty;
            string oddStr = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    FillStringCheckingLetters(ref evenStr, array[i]);
                }
                else
                {
                    FillStringCheckingLetters(ref oddStr, array[i]);
                }
            }

            int evenStrCount = CalculateUpperLetterCount(evenStr);
            int oddStrCount = CalculateUpperLetterCount(oddStr);
            if (evenStrCount > oddStrCount)
            {
                Console.WriteLine("В массиве с парными буквами больше элементов верхнего регистра");
            }
            else if (evenStrCount < oddStrCount)
            {
                Console.WriteLine("В массиве с не парными буквами больше элементов верхнего регистра");
            }
            else if (evenStrCount == oddStrCount)
            {
                Console.WriteLine("Равное количество элементов верхнего регистра");
            }

            Console.Write("Парные: ");
            for (int i = 0; i < evenStr.Length; i++)
            {
                Console.Write($"{evenStr[i]} ");
            }

            Console.WriteLine();
            Console.Write("Не парные: ");
            for (int i = 0; i < oddStr.Length; i++)
            {
                Console.Write($"{oddStr[i]} ");
            }

            Console.WriteLine();
        }

        private static int[] GetRandomArray()
        {
            int n = default;
            Console.Write("Введите колличество элементов массива: ");
            string str = Console.ReadLine();
            while (!int.TryParse(str, out n))
            {
                Console.WriteLine("Вы ввели не число");
                Console.Write("Введите колличество элементов массива: ");
                str = Console.ReadLine();
                Console.Clear();
            }

            int[] array = new int[n];
            var rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1, 26);
            }

            return array;
        }

        private static void FillStringCheckingLetters(ref string evenOrOddStr, int index)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string checkingLetters = "aeidhj";
            for (int i = 0; i < checkingLetters.Length; i++)
            {
                if (alphabet[index] == checkingLetters[i])
                {
                    evenOrOddStr += char.ToUpper(alphabet[index]);
                    break;
                }
                else if (i == checkingLetters.Length - 1)
                {
                    evenOrOddStr += alphabet[index];
                }
            }
        }

        private static int CalculateUpperLetterCount(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsUpper(str[i]))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
