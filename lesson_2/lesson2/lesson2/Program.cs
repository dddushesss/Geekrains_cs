using System;
using System.Linq;

namespace lesson2
{
    internal class Program
    {
        //Павлов Алексей

        /*
         * 1. Написать метод, возвращающий минимальное из трёх чисел.
         */
        private static int GreatestOfThree(int a, int b, int c)
        {
            if ((a > b) && (a > c))
            {
                return a;
            }
            else if ((b > a) && (b > c))
            {
                return b;
            }

            return c;
        }
        /*
         * 2. Написать метод подсчета количества цифр числа.
         */
        private static int CountOfDigits(int a)
        {
            var count = 0;
            while (a != 0)
            {
                count++;
                a /= 10;
            }

            return count;
        }
        /*
         * 3.С клавиатуры вводятся числа, пока не будет введен 0.
         * Подсчитать сумму всех нечетных положительных чисел.
         */
        private static int PositiveEvenCounter()
        {
            var input = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            var count = 0;
            while (input != 0)
            {
                if ((input > 0) && (input % 2 != 0))
                {
                    count++;
                }

                input = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            }
            Console.Write("Количество положительных нечётых чисел: ");
            return count;
        }
        
        /*
         * 4.Реализовать метод проверки логина и пароля.
         * На вход метода подается логин и пароль.
         * На выходе истина, если прошел авторизацию,
         * и ложь, если не прошел (Логин: root, Password: GeekBrains).
         * Используя метод проверки логина и пароля, написать программу:
         * пользователь вводит логин и пароль, программа пропускает его дальше
         * или не пропускает.
         * С помощью цикла do while ограничить ввод пароля тремя попытками.
         */
        private static bool PasswordCheck()
        {
            var count = 0;
            const string pass = "GeekBrains";
            const string login = "root";
            while (count < 3)
            {
                Console.Write("Логин: ");
                var inLogin = Console.ReadLine();
                Console.Write("Пароль: ");
                var inPass = Console.ReadLine();
                if (login.Equals(inLogin) && pass.Equals(inPass))
                {
                    Console.WriteLine("Логин и пароль приняты");
                    return true;
                }
                else
                {
                    Console.WriteLine("Введен неправильный пароль или логин");
                }
                count++;
            }

            return false;
        }
        
        /*
         * 5. а) Написать программу, которая запрашивает массу и рост человека,
         * вычисляет его индекс массы и сообщает, нужно ли человеку похудеть,
         * набрать вес или всё в норме.
         * 
         * б) *Рассчитать, на сколько кг похудеть или сколько кг набрать
         * для нормализации веса.
         */
        private static void BMI(double weight, double height)
        {
            var BMI = weight / (height*height);
            if (BMI < 18.5)
            {
                Console.WriteLine($"Дефицит массы, до нормы надо набрать {(18.5 * height * height) - weight} кг");
            }
            else if(BMI > 25.0)
            {
                Console.WriteLine($"Ожирение, до нормы надо скинуть {weight - (25 * height * height)} кг");
            }
            else
            {
                Console.WriteLine("Норма");
            }
        }

        /*
         * 6.*Написать программу подсчета количества
         * «хороших» чисел в диапазоне от 1 до 1 000 000 000.
         * «Хорошим» называется число, которое делится на сумму своих цифр.
         * Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
         */

        private static int RecSumOfNumsDigits(int a)//1:13
        {
            if (a == 0)
            {
                return a;
            }

            return RecSumOfNumsDigits(a / 10) + a % 10;
        }
        
        private static int SumOfNumsDigits(int a)//0:36
        {
            var sum = 0;
            while (a != 0)
            {
                sum += a % 10;
                a /= 10;
            }
            
            return sum;
        }
        
        private static void GoodNums()
        {
            var count = 0;
            var time1 = DateTime.Now;
            for (var i = 1; i < 1000000000; i++)
            {
                if (i % SumOfNumsDigits(i) == 0)
                {
                    count++;
                }
            }
            var time2 = DateTime.Now;
            Console.WriteLine($"Количество хороших чисел: {count}. Время выполнения программы: {(time2 - time1)}");
        }

        /*
         * 7.a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
           б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
         */
        private static int RecSumOfNums(int a, int b)
        {
            return a >= b ? a : a + RecSumOfNums(a + 1, b);
        }
        
        public static void Main(string[] args)
        {
            //1
            Console.WriteLine(GreatestOfThree(int.Parse(Console.ReadLine() ?? throw new InvalidOperationException()),
                int.Parse(Console.ReadLine() ?? throw new InvalidOperationException()),
                int.Parse(Console.ReadLine() ?? throw new InvalidOperationException())));
            Console.WriteLine("<....>");
            //2
            Console.WriteLine(CountOfDigits(int.Parse(Console.ReadLine() ?? throw new InvalidOperationException())));
            Console.WriteLine("<....>");
            //3
            Console.WriteLine(PositiveEvenCounter());
            //4
            Console.WriteLine(PasswordCheck());
            //5
            Console.WriteLine("Введите сначала массу, а затем рост");
            BMI(double.Parse(Console.ReadLine() ?? throw new InvalidOperationException()),
                double.Parse(Console.ReadLine() ?? throw new InvalidOperationException()));
            //6
            GoodNums();
            //7
            Console.WriteLine(RecSumOfNums(1, 4));
        }
    }
}