using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using MassLib;

namespace lesson_4
{
    internal static class Program
    {
        #region Task1

        /*
         * Дан  целочисленный  массив  из 20 элементов.
         * Элементы  массива  могут принимать  целые  значения  от –10 000 до 10 000 включительно.
         * Заполнить случайными числами.  Написать программу, позволяющую найти
         * и вывести количество пар элементов массива, в которых только одно число делится на 3.
         * В данной задаче под парой подразумевается два подряд идущих элемента массива.
         * Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
         * Павлов Алексей
         */
        private static int DevidedByThreePairs(int[] mass)
        {
            var count = 0;
            for (var i = 0; i < mass.Length - 1; i++)
            {
                if ((mass[i] % 3 == 0) && (mass[i + 1] % 3 != 0))
                {
                    count++;
                }
                else if (mass[i + 1] % 3 == 0 && mass[i] % 3 != 0)
                {
                    count++;
                }
            }

            return count;
        }

        private static void Task1()
        {
            var mass = new int[20];
            var rnd = new Random();
            Console.WriteLine("Задание 1. Дан массив:");
            for (var i = 0; i < mass.Length; i++)
            {
                mass[i] = rnd.Next(-10000, 10000);
                Console.Write($"{mass[i]} ");
            }

            Console.WriteLine(
                $"\nКоличество пар элементов массива, в которых только одно число делится на 3 - {DevidedByThreePairs(mass)}");
        }

        #endregion

        #region Task2

        /*
         * Реализуйте задачу 1 в виде статического класса StaticClass;
        а) Класс должен содержать статический метод, который принимает на вход массив
        и решает задачу 1;
        б) *Добавьте статический метод для считывания массива из текстового файла. 
        Метод должен возвращать массив целых чисел;
        в)**Добавьте обработку ситуации отсутствия файла на диске.
        Павлов Алексей
         */

        private static class StaticClass
        {
            public static int DevidedByThreePairs(int[] mass)
            {
                var count = 0;
                for (var i = 0; i < mass.Length - 1; i++)
                {
                    if ((mass[i] % 3 == 0) && (mass[i + 1] % 3 != 0))
                    {
                        count++;
                    }
                    else if (mass[i + 1] % 3 == 0 && mass[i] % 3 != 0)
                    {
                        count++;
                    }
                }

                return count;
            }

            public static int[] MassFromFile(string fileName)
            {
                StreamReader sr;
                try
                {
                    sr = new StreamReader(fileName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return new[] {0};
                }

                var s = sr.ReadLine();
                if (string.IsNullOrEmpty(s))
                    return new[] {0};
                s = s.Trim();
                s = Regex.Replace(s, @"\s+", " ");
                var mass = new int[s.Count(t => t.Equals(' ')) + 1];

                var i = 0;
                var j = 0;
                while (i < s.Length)
                {
                    var tmp = "";
                    while ((i < s.Length) && !s[i].Equals(' '))
                    {
                        tmp += s[i++];
                    }

                    ++i;

                    if (int.TryParse(tmp, out var num))
                    {
                        mass[j++] = num;
                    }
                }

                sr.Close();
                return mass;
            }
        }

        private static void Task2()
        {
            var mass = StaticClass.MassFromFile("..\\..\\data.txt");
            Console.WriteLine("Задание 2. Дан массив: ");
            foreach (var num in mass)
            {
                Console.Write($"{num} ");
            }

            Console.WriteLine(
                $"\nКоличество пар элементов массива, в которых только одно число делится на 3 - {StaticClass.DevidedByThreePairs(mass)}");
        }

        #endregion

        #region Task4

        struct Account
        {
            public Dictionary<string, string> LogPass;

            public Account(string filename)
            {
                if (File.Exists(filename))
                {
                    var lines = File.ReadAllLines(filename);
                    LogPass = new Dictionary<string, string>(lines.Length);
                    foreach (var s in lines)
                    {
                        var tmp = s.Split(' ');
                        tmp[0] = Regex.Replace(tmp[0], @"\s+", " ").Trim();
                        tmp[1] = Regex.Replace(tmp[1], @"\s+", " ").Trim();
                        if (LogPass.ContainsKey(tmp[0]))
                        {
                            continue;
                        }

                        LogPass.Add(tmp[0], tmp[1]);
                    }
                }
                else
                {
                    Console.WriteLine("Не найден файл");
                    LogPass = new Dictionary<string, string>();
                }
            }
        }

        private static bool CheckPass(string login, string password, Account account)
        {
            return account.LogPass.ContainsKey(login) && account.LogPass[login].Equals(password);
        }

        private static void Task4()
        {
            Console.WriteLine("Задание 4");
            var account = new Account("..\\..\\account.txt");
            var tries = 0;
            var isLogin = false;
            while ((tries <= 3) && (!isLogin))
            {
                Console.Write("Введите логин: ");
                var login = Console.ReadLine();
                Console.Write("Введите пароль: ");
                var password = Console.ReadLine();
                if (CheckPass(login, password, account))
                {
                    isLogin = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Введены неправильный логин или пароль");
                }

                tries++;
            }

            Console.WriteLine(isLogin ? "Логин и пароль приняты" : "Слишком много попыток входа");
        }

        #endregion

        public static void Main(string[] args)
        {
            Task1();
            Console.ReadKey();
            Console.Clear();
            Task2();
            Console.ReadKey();
            Console.Clear();
            var mass = new Task3(20, 10, 4);
            Console.WriteLine("Задание 3. Дан массив: ");
            foreach (var num in mass.Mass)
            {
                Console.Write($"{num} ");
            }

            Console.WriteLine($"\nСумма: {mass.Sum} Колличество максимальых элементов {mass.MaxCount}");
            Console.WriteLine("Каждый элемент меняет знак:");
            foreach (var num in mass.Inverse())
            {
                Console.Write($"{num} ");
            }

            mass.Multi(2);
            Console.WriteLine("\nКаждый элемент массива умножается на 2:");
            foreach (var num in mass.Mass)
            {
                Console.Write($"{num} ");
            }

            Console.WriteLine("\n");
            foreach (var key in mass.dic)
            {
                Console.WriteLine($"{key.Key} - {key.Value} штук");
            }

            Console.ReadKey();
            Console.Clear();
            Task4();
        }
    }
}