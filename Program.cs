using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZ_4_2
{
    internal class Program
    {
        //Задание 2
        static int GetSum(params int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        static void GetProduct(int[] numbers, ref int productref)
        {
            productref = 1;
            foreach (int number in numbers)
            {
                productref *= number;
            }
        }

        static void GetAverage(int[] numbers, out double average)
        {
            int sum = GetSum(numbers);
            average = (double)sum / numbers.Length;
        }

        //Задание 3
        static void DrawNumber(int number)
        {
            string[] numbers =
            {
        "###\n# #\n###\n# #\n###",   // 0
        "  #\n  #\n  #\n  #\n  #",   // 1
        "###\n  #\n###\n#  \n###",   // 2
        "###\n  #\n###\n  #\n###",   // 3
        "# #\n# #\n  #\n  #\n  #",   // 4
        "###\n#  \n###\n  #\n###",   // 5
        "###\n#  \n###\n# #\n###",   // 6
        "###\n  #\n  #\n# #\n# #",   // 7
        "###\n# #\n###\n# #\n###",   // 8
        "###\n# #\n###\n  #\n###"    // 9
    };

            Console.WriteLine(numbers[number]);
        }

        //Задание 4
        public enum GrumpinessLevel
        {
            Low,
            Medium,
            High
        }

        public struct Grandpa
        {
            public string Name;
            public GrumpinessLevel Grumpiness;
            public string[] GrumblePhrases;
            public int BlackEyesCount;

            public int CheckForProfanity(params string[] profanityWords)
            {
                int count = 0;
                foreach (var phrase in GrumblePhrases)
                {
                    foreach (var word in profanityWords)
                    {
                        if (phrase.Contains(word))
                        {
                            BlackEyesCount++;
                            count++;
                        }
                    }
                }
                return count;
            }
        }
        static void Main(string[] args)
        {
            //Задание 1
            Console.WriteLine("Задание 1");
            Random random = new Random();
            int[] array = new int[20];

            // Заполнение массива случайными числами
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 100);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine("\nВведите индексы чисел, которые необходимо поменять местами");
            int index1 = Convert.ToInt32(Console.ReadLine());
            int index2 = Convert.ToInt32(Console.ReadLine());

            // Проверка корректности введенных индексов
            if (index1 >= 0 && index1 < array.Length && index2 >= 0 && index2 < array.Length)
            {
                int temp = array[index1];
                array[index1] = array[index2];
                array[index2] = temp;

                Console.WriteLine("\nNew array:");

                // Вывод нового массива после замены чисел
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");
                }
            }
            else
            {
                Console.WriteLine("Неверный индекс");
            }
            Console.WriteLine("\n");
            Console.ReadKey();


            //Задание 2
            Console.WriteLine("Задание 2\n");
            int[] numbers = { 1, 2, 3, 4, 5 };
            int sum = GetSum(numbers);
            Console.WriteLine($"Сумма: {sum}");

            int product = 1;
            GetProduct(numbers, ref product);
            Console.WriteLine($"Произведение: {product}");

            double average;
            GetAverage(numbers, out average);
            Console.WriteLine($"Средние арифметическое: {average}");
            Console.ReadKey();

            //Задание 4
            Console.WriteLine("Задание 4\n");
            Grandpa grandpa1 = new Grandpa
            {
                Name = "Артём",
                Grumpiness = GrumpinessLevel.Low,
                GrumblePhrases = new string[] { "a", "b" },
                BlackEyesCount = 0
            };

            Grandpa grandpa2 = new Grandpa
            {
                Name = "Donald Trump",
                Grumpiness = GrumpinessLevel.Low,
                GrumblePhrases = new string[] { "b", "f" },
                BlackEyesCount = 0
            };

            Grandpa grandpa3 = new Grandpa
            {
                Name = "Олег",
                Grumpiness = GrumpinessLevel.Medium,
                GrumblePhrases = new string[] { "b", "c", "f", "h" },
                BlackEyesCount = 0
            };

            Grandpa grandpa4 = new Grandpa
            {
                Name = "Илья",
                Grumpiness = GrumpinessLevel.High,
                GrumblePhrases = new string[] { "a", "b", "c", "f", "e", "h" },
                BlackEyesCount = 0
            };

            Grandpa grandpa5 = new Grandpa
            {
                Name = "Максим",
                Grumpiness = GrumpinessLevel.High,
                GrumblePhrases = new string[] { "c", "d", "e", "f", "j", "h" },
                BlackEyesCount = 0
            };


            string[] profanityWords = { "a", "d", "h" };
            Console.WriteLine(grandpa1.CheckForProfanity(profanityWords) + " Фингалов");
            Console.WriteLine(grandpa2.CheckForProfanity(profanityWords) + " Фингалов");
            Console.WriteLine(grandpa3.CheckForProfanity(profanityWords) + " Фингалов");
            Console.WriteLine(grandpa4.CheckForProfanity(profanityWords) + " Фингалов");
            Console.WriteLine(grandpa5.CheckForProfanity(profanityWords) + " Фингалов");

            Console.ReadKey();

            //Задание 3
            string input;
            Console.WriteLine("Задание 3");
            do
            {
                Console.WriteLine("Введите число (от 0 до 9) или exit для выхода:");
                input = Console.ReadLine();

                try
                {
                    int number = int.Parse(input);

                    if (number >= 0 && number <= 9)
                    {
                        DrawNumber(number);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка: число должно быть от 0 до 9!");

                        // Устанавливаем цвет обратно на 3 секунды
                        Thread.Sleep(3000);
                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    throw new Exception("Ошибка: введите число от 0 до 9!");
                }
            } while (input != "exit" && input != "закрыть");
            Console.ReadKey();
        }
    
    }
}
