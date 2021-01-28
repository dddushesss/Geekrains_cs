using System;

namespace lesson_3
{
    internal static class Program
    {
        #region Task 1
        /*
         * а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.
         * Продемонстрировать работу структуры.
         * б) Дописать класс Complex, добавив методы вычитания и произведения чисел.
         * Проверить работу класса.
         * в) Добавить диалог с использованием switch демонстрирующий работу класса.
        */
        struct Complex
        {
            public double Im;
            public double Re;

            public Complex Plus(Complex x)
            {
                Complex y;
                y.Im = Im + x.Im;
                y.Re = Re + x.Re;
                return y;
            }

            public Complex Minus(Complex x)
            {
                Complex y;
                y.Re = Re - x.Re;
                y.Im = Im - x.Im;
                return y;
            }

            public Complex Multi(Complex x)
            {
                Complex y;
                y.Im = Re * x.Im + Im * x.Re;
                y.Re = Re * x.Re - Im * x.Im;
                return y;
            }

            public override string ToString()
            {
                return Im > 0 ? Re + "+" + Im + "i" : $"{Re}{Im}i";
            }
        }

        class ComplexClass
        {
            private double Im { get; set; }

            private double Re { get; set; }

            public ComplexClass()
            {
                Im = 0;
                Re = 0;
            }

            public ComplexClass(double re, double im)
            {
                Im = im;
                Re = re;
            }

            public override string ToString()
            {
                return Im >= 0 ? $"{Re}+{Im}i" : $"{Re}{Im}i";
            }

            public static ComplexClass operator +(ComplexClass x, ComplexClass y) =>
                new ComplexClass(x.Re + y.Re, x.Im + y.Im);

            public static ComplexClass operator -(ComplexClass x, ComplexClass y) =>
                new ComplexClass(x.Re - y.Re, x.Im - y.Im);

            public static ComplexClass operator *(ComplexClass x, ComplexClass y) =>
                new ComplexClass(x.Re * y.Re - x.Im * y.Im, x.Re * y.Im + x.Im * y.Re);
        }

        private static void Task1()
        {
            ComplexClass x;
            ComplexClass y;
            double re, im;
            string s;
            var isToExit = false;
            Console.WriteLine("Введите число x. Сначала вещественную часть, затем мнимую");
            while (!(double.TryParse(Console.ReadLine(), out re)
                     && double.TryParse(Console.ReadLine(), out im)))
            {
                Console.Clear();
                Console.WriteLine("Недопустивый ввод");
                Console.WriteLine("Введите число x. Сначала вещественную часть, затем мнимую");
            }

            x = new ComplexClass(re, im);
            Console.Clear();
            Console.WriteLine($"x = {x}, введите второе число. Сначала вещественную часть, затем мнимую");
            while (!(double.TryParse(Console.ReadLine(), out re)
                     && double.TryParse(Console.ReadLine(), out im)))
            {
                Console.Clear();
                Console.WriteLine("Недопустивый ввод");
            }

            y = new ComplexClass(re, im);
            while (!isToExit)
            {
                Console.WriteLine($"x = {x}, y = {y}; + - сложение, - - вычитание, * - умножение, q - выход");
                s = Console.ReadLine();
                Console.Clear();
                switch (s)
                {
                    case "+":
                        Console.WriteLine($"x + y = {x + y}");
                        break;
                    case "-":
                        Console.WriteLine($"x - y = {x - y}");
                        break;
                    case "*":
                        Console.WriteLine($"x * y = {x * y}");
                        break;
                    case "q":
                        isToExit = true;
                        break;
                    default:
                        Console.WriteLine("Нет такой команды");
                        break;
                }
            }
        }

        #endregion

        #region Task 2
        /*
         * 2.а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке).
         * Требуется подсчитать сумму всех нечетных положительных чисел.
         * Сами числа и сумму вывести на экран, используя tryParse;
         * 
         * б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.
         * При возникновении ошибки вывести сообщение. Напишите соответствующую функцию;
         */
        private static void Task2()
        {
            var isToExit = false;
            int num, sum = 0;
            var nums = "";
            Console.WriteLine(
                "Вводите числа с клавиатуры. Будут суммироваться нечетные положительные числа. Введите 0 для выхода");
            while (!isToExit)
            {
                if (int.TryParse(Console.ReadLine(), out num))
                {
                    if ((num % 2 != 0) && (num > 0))
                    {
                        sum += num;
                        nums += $"{num} + ";
                    }
                    else if (num == 0)
                    {
                        isToExit = true;
                    }
                }
                else
                {
                    Console.WriteLine("Не удалось получить число из ввода");
                }
            }

            nums = nums.Remove(nums.LastIndexOf('+') - 1, 3);
            Console.WriteLine($"Сумма положительных нечетных чисел равна \n" +
                              $"{nums} = {sum}");
        }

        #endregion

        #region Task 3
        /*
         * 3. *Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел.
         * Предусмотреть методы сложения, вычитания, умножения и деления дробей.
         * Написать программу, демонстрирующую все разработанные элементы класса.
              ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение
              ArgumentException("Знаменатель не может быть равен 0");
              Добавить упрощение дробей.
         */

        public class Fraction
        {
            private int _numerator; // Числитель
            private int _denominator; // Знаменатель
            private readonly int _sign; // Знак

            public Fraction(int numerator, int denominator)
            {
                if (denominator == 0)
                {
                    throw new ArgumentException("В знаменателе не может быть нуля");
                }

                this._numerator = Math.Abs(numerator);
                this._denominator = Math.Abs(denominator);
                if (numerator * denominator < 0)
                {
                    this._sign = -1;
                }
                else
                {
                    this._sign = 1;
                }
            }

            public Fraction(int number) : this(number, 1)
            {
            }

            private static int GetGreatestCommonDivisor(int a, int b)
            {
                while (b != 0)
                {
                    var temp = b;
                    b = a % b;
                    a = temp;
                }

                return a;
            }

            private static int GetLeastCommonMultiple(int a, int b)
            {
                return a * b / GetGreatestCommonDivisor(a, b);
            }


            private static Fraction PerformOperation(Fraction a, Fraction b, Func<int, int, int> operation)
            {
                var leastCommonMultiple = GetLeastCommonMultiple(a._denominator, b._denominator);

                var additionalMultiplierFirst = leastCommonMultiple / a._denominator;

                var additionalMultiplierSecond = leastCommonMultiple / b._denominator;

                var operationResult = operation(a._numerator * additionalMultiplierFirst * a._sign,
                    b._numerator * additionalMultiplierSecond * b._sign);
                return new Fraction(operationResult, a._denominator * additionalMultiplierFirst);
            }

            private Fraction GetReverse()
            {
                return new Fraction(this._denominator * this._sign, this._numerator);
            }

            public static Fraction operator +(Fraction a, Fraction b)
            {
                return PerformOperation(a, b, (int x, int y) => x + y);
            }

            public static Fraction operator +(Fraction a, int b)
            {
                return a + new Fraction(b);
            }

            public static Fraction operator +(int a, Fraction b)
            {
                return b + a;
            }

            public static Fraction operator -(Fraction a, Fraction b)
            {
                return PerformOperation(a, b, (int x, int y) => x - y);
            }

            public static Fraction operator -(Fraction a, int b)
            {
                return a - new Fraction(b);
            }

            public static Fraction operator -(int a, Fraction b)
            {
                return b - a;
            }

            public static Fraction operator *(Fraction a, Fraction b)
            {
                return new Fraction(a._numerator * a._sign * b._numerator * b._sign, a._denominator * b._denominator);
            }

            public static Fraction operator *(Fraction a, int b)
            {
                return a * new Fraction(b);
            }

            public static Fraction operator *(int a, Fraction b)
            {
                return b * a;
            }

            public static Fraction operator /(Fraction a, Fraction b)
            {
                return a * b.GetReverse();
            }

            public static Fraction operator /(Fraction a, int b)
            {
                return a / new Fraction(b);
            }

            public static Fraction operator /(int a, Fraction b)
            {
                return new Fraction(a) / b;
            }

            public Fraction Reduce()
            {
                Fraction result = this;
                int greatestCommonDivisor = GetGreatestCommonDivisor(this._numerator, this._denominator);
                result._numerator /= greatestCommonDivisor;
                result._denominator /= greatestCommonDivisor;
                return result;
            }

            public override string ToString()
            {
                if (this._numerator == 0)
                {
                    return "0";
                }

                var result = this._sign < 0 ? "-" : "";

                if (this._numerator == this._denominator)
                {
                    return result + "1";
                }

                if (this._denominator == 1)
                {
                    return result + this._numerator;
                }

                return result + this._numerator + "/" + this._denominator;
            }
        }

        private static void Task3()
        {
            Fraction x, y;
            int nu = 0, de = 0;
            var isToExit = false;

            Console.WriteLine("Введите число x. Сначала числитель, затем знаминатель");
            while (!(int.TryParse(Console.ReadLine(), out nu)
                     && int.TryParse(Console.ReadLine(), out de)))
            {
                Console.Clear();
                Console.WriteLine("Недопустивый ввод");
                Console.WriteLine("Введите число x. Сначала числитель, затем знаминатель");
            }

            x = new Fraction(nu, de);
            Console.Clear();
            Console.WriteLine($"x = {x}, введите второе число. Сначала числитель, затем знаминатель");
            while (!(int.TryParse(Console.ReadLine(), out nu)
                     && int.TryParse(Console.ReadLine(), out de)))
            {
                Console.Clear();
                Console.WriteLine("Недопустивый ввод");
            }

            y = new Fraction(nu, de);
            while (!isToExit)
            {
                Console.WriteLine($"x = {x}, y = {y}; + - сложение, - - вычитание, * - умножение, r - упростить q - выход");
                var s = Console.ReadLine();
                Console.Clear();
                switch (s)
                {
                    case "+":
                        Console.WriteLine($"x + y = {x + y}");
                        break;
                    case "-":
                        Console.WriteLine($"x - y = {x - y}");
                        break;
                    case "*":
                        Console.WriteLine($"x * y = {x * y}");
                        break;
                    case "r":
                        x = x.Reduce();
                        y = y.Reduce();
                        Console.WriteLine($"После упрощения x = {x}, y = {y}");
                        break;
                    case "q":
                        isToExit = true;
                        break;
                    default:
                        Console.WriteLine("Нет такой команды");
                        break;
                }
            }
        }
        
        #endregion
        public static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
        }
    }
}