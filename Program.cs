using System;

namespace Forth_Homework
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = default;
            Console.Write("Введите колличество элементов массива: ");
            string str = Console.ReadLine();
            while (!int.TryParse(str, out n))
            {
                Console.WriteLine("Вы ввели не число");
                Console.Write("Введите колличество элементов массива: ");
                str = Console.ReadLine();
            }

            int[] array = new int[n];
            var rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1, 26);
            }

            string parStr = string.Empty;
            string notParStr = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    FillStringCheckingLetters(ref parStr, array[i]);
                }
                else
                {
                    FillStringCheckingLetters(ref notParStr, array[i]);
                }
            }

            int parStrCount = CalculateUpperLetterCount(parStr);
            int notParStrCount = CalculateUpperLetterCount(notParStr);
            if (parStrCount > notParStrCount)
            {
                Console.WriteLine("В массиве с парными буквами больше элементов верхнего регистра");
            }
            else if (parStrCount < notParStrCount)
            {
                Console.WriteLine("В массиве с не парными буквами больше элементов верхнего регистра");
            }
            else if (parStrCount == notParStrCount)
            {
                Console.WriteLine("Равное количество элементов верхнего регистра");
            }

            Console.Write("Парные: ");
            for (int i = 0; i < parStr.Length; i++)
            {
                Console.Write($"{parStr[i]} ");
            }

            Console.WriteLine();
            Console.Write("Не парные: ");
            for (int i = 0; i < notParStr.Length; i++)
            {
                Console.Write($"{notParStr[i]} ");
            }

            Console.WriteLine();
        }

        private static void FillStringCheckingLetters(ref string parOrNotParStr, int index)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string checkingLetters = "aeidhj";
            for (int i = 0; i < checkingLetters.Length; i++)
            {
                if (alphabet[index] == checkingLetters[i])
                {
                    parOrNotParStr += char.ToUpper(alphabet[index]);
                    break;
                }
                else if (i == checkingLetters.Length - 1)
                {
                    parOrNotParStr += alphabet[index];
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
