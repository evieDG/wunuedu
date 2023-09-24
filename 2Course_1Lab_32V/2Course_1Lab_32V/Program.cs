
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Course_1Lab_32V
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Exercsie 1\nExercise 2\nExercise 3\n");
                int a = Convert.ToInt16(Console.ReadLine());
                if (a == 1)
                {
                    Ex1();
                }
                if (a == 2)
                {
                    Ex2();
                }
                if (a == 3)
                {
                    Ex3();
                }
                
                else { continue; }
            }
        }
        public static void Ex1()
        {
            double y = 0;
            Console.WriteLine("Exercise 1 \tVariant 32\n y=((√(x^2 - b))/x) - (tgx/b^2)\n");

            Console.WriteLine("Enter Х value:");
            
            int x = Convert.ToInt32(Console.ReadLine());

            if (x <= 0)
            {
                Console.WriteLine("X can't be a 0 or less");
            }
            else
            {
                Console.WriteLine("Enter B value:");
                int b = Convert.ToInt32(Console.ReadLine());
                if (b <= 0)
                {
                    Console.WriteLine("B can't be a 0 or less");
                }
                else
                {
                    y = (((Math.Sqrt(x * x - b)) / x) - (Math.Tan(x) / b * b));
                    Console.WriteLine("Y equal to " + y + " when X is " + x + " and B is" + b);
                    Console.WriteLine("Press Enter for continue");
                    Console.ReadLine();
                }
            }
  

        }
        public static void Ex2()
        {


            // Додатковий код для перевірки факторіалу n
            Console.WriteLine("\n]Exercise 2\n Variant 7 \n Дано натуральне число n. Перевірити, чи можна подати n! у вигляді добутку трьох послідовних цілих чисел.");
            Console.WriteLine("Enter a natural number n:");
            int n = Convert.ToInt32(Console.ReadLine());
            if (CheckFactorial(n))
            {
                Console.WriteLine($"{n}! можна подати у вигляді добутку трьох послідовних цілих чисел.");
            }
            else
            {
                Console.WriteLine($"{n}! не можна подати у вигляді добутку трьох послідовних цілих чисел.");
            }

            Console.WriteLine("Натисніть Enter для  продовження");
            Console.ReadLine();
        }



        // Новий метод для перевірки факторіалу n
        public static bool CheckFactorial(int n)
        {
            int product = 1;
            for (int i = 1; i <= n; i++)
            {
                product *= i;
                if (i >= 3 && product == n)
                {
                    return true;
                }
            }
            return false;
        }


        public static void Ex3()
        {
            Console.WriteLine("Завдання 3:\nДано дійсні числа a1, . . . , an , b1, . . . , bm  . У послідовності a1, . . . , an  та у послідовності b1, . . . , bm  всі члени, розташовані за членом з найбільшим значенням (за першим, якщо їх декілька), замініть на 0.5.\n");

            Console.WriteLine("Введіть послідовність a через пробіл:");
            string inputA = Console.ReadLine();
            double[] sequenceA = ParseSequence(inputA);

            Console.WriteLine("Введіть послідовність b через пробіл:");
            string inputB = Console.ReadLine();
            double[] sequenceB = ParseSequence(inputB);

            ReplaceMaxWith0_5(sequenceA);
            ReplaceMaxWith0_5(sequenceB);

            Console.WriteLine("Послідовність a зі заміненими максимальними елементами:");
            Console.WriteLine(string.Join(" ", sequenceA));

            Console.WriteLine("Послідовність b зі заміненими максимальними елементами:");
            Console.WriteLine(string.Join(" ", sequenceB));

            Console.WriteLine("Натисніть Enter для продовження");
            Console.ReadLine();
        }

        // Новий метод для заміни максимального елемента у послідовності на 0.5
        public static void ReplaceMaxWith0_5(double[] sequence)
        {
            if (sequence.Length == 0)
            {
                return;
            }

            double max = sequence.Max();
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == max)
                {
                    sequence[i] = 0.5;
                }
            }
        }

        // Новий метод для розбору рядка з числами у масив дійсних чисел
        public static double[] ParseSequence(string input)
        {
            string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double[] sequence = new double[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                if (double.TryParse(parts[i], out double number))
                {
                    sequence[i] = number;
                }
            }
            return sequence;
        }

    }
}
