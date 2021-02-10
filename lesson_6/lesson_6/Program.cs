using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace lesson_6
{
    internal static class Program
    {
        #region Task1

        delegate double DoOperation(double x, double y);
        /*
         * 1. Изменить программу вывода таблицы функции так,
         * чтобы можно было передавать функции типа double (double, double).
         * Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
         */

        private static double Ax2(DoOperation f, double a, double x, double y)
        {
            return a * Math.Pow(f(x, y), 2);
        }

        private static double Asinx(DoOperation f, double a, double x, double y)
        {
            return a * Math.Sin(f(x, y));
        }

        private static double Plus(double x, double y)
        {
            Console.Write($"{x} + {y}");
            return x + y;
        }

        private static double Minus(double x, double y)
        {
            Console.Write($"{x} - {y}");
            return x - y;
        }

        private static void Task1()
        {
            Console.WriteLine("Введите a, x, y");
            var a = double.Parse(Console.ReadLine() ?? string.Empty);
            var x = double.Parse(Console.ReadLine() ?? string.Empty);
            var y = double.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("1 - a*(x+y)^2, 2 - a*(x-y)^2, 3 - a*sin(x+y), 4 - a*sin(x-y)");
            var s = Console.ReadLine();
            Console.Clear();
            switch (s?.ToLower().Trim())
            {
                case "1":
                    Console.WriteLine($"{a} * ({x} + {y})^2 = {Ax2(Plus, a, x, y)}");
                    break;
                case "2":
                    Console.WriteLine($"{a} * ({x} - {y})^2 = {Ax2(Minus, a, x, y)}");
                    break;
                case "3":
                    Console.WriteLine($"{a} * sin({x} + {y}) = {Asinx(Plus, a, x, y)}");
                    break;
                case "4":
                    Console.WriteLine($"{a} * sin({x} - {y}) = {Asinx(Minus, a, x, y)}");
                    break;
                default:
                    Console.WriteLine("Нет такой команды");
                    break;
            }
        }

        #endregion

        #region Task2

        /*
         * 2. Модифицировать программу нахождения минимума функции так,
         * чтобы можно было передавать функцию в виде делегата.
         * а) Сделайте меню с различными функциями и предоставьте пользователю выбор,
         * для какой функции и на каком отрезке находить минимум.
         * б) Ипользуйте массив (или список) делегатов, в котором хранятся различные функции.
         * в) *Переделайте функцию Load, чтобы она возвращала массив считанных значений. Пусть она
         * возвращает минимум через параметр.
         */

        public delegate double FuncToSave(double x);

        private static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }

        private static double F2(double x)
        {
            return Math.Sin(x);
        }

        private static void SaveFunc(string fileName, double a, double b, double h, FuncToSave func)
        {
            var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            var bw = new BinaryWriter(fs);
            var x = a;
            while (x <= b)
            {
                bw.Write(func(x));
                x += h; // x=x+h;
            }

            bw.Close();
            fs.Close();
        }

        private static double[] Load(string fileName, ref double min)
        {
            var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var bw = new BinaryReader(fs);

            var mass = new double[fs.Length / sizeof(double)];
            for (var i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                mass[i] = bw.ReadDouble();
                if (mass[i] < min)
                {
                    min = mass[i];
                }
            }

            bw.Close();
            fs.Close();
            return mass;
        }


        private static void Task2()
        {
            var fList = new List<FuncToSave> {F1, F2};
            SaveFunc("..\\..\\data.bin", -100, 100, 0.5, fList[0]);
            var min = 0d;
            Console.WriteLine("Массив:");
            foreach (var num in Load("data.bin", ref min))
            {
                Console.WriteLine(num);
            }

            Console.WriteLine($"минимальный элемент - {min}");
        }

        #endregion

        #region Task3

        /*
         * 3. Переделать программу «Пример использования коллекций» для решения следующих задач:
         * а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
         * б) подсчитать сколько студентов в возрасте от 18 до 20 лет
         * на каком курсе учатся (частотный массив);
         * в) отсортировать список по возрасту студента;
         * г) *отсортировать список по курсу и возрасту студента;
         * д) разработать единый метод подсчета количества студентов по различным параметрам
         * выбора с помощью делегата и методов предикатов.
         * Павлов Алексей
         */

        class Student : IComparable<Student>
        {
            public string lastName;
            public string firstName;
            public string university;
            public string faculty;
            public int course;
            public string department;
            public int group;
            public string city;

            public int age;

            // Создаем конструктор
            public Student(string firstName, string lastName, string university, string faculty, string department,
                int course, int age, int group, string city)
            {
                this.lastName = lastName;
                this.firstName = firstName;
                this.university = university;
                this.faculty = faculty;
                this.department = department;
                this.course = course;
                this.age = age;
                this.group = group;
                this.city = city;
            }

            public int CompareTo(Student other)
            {
                if (other != null)
                {
                    return this.age - other.age;
                }

                throw new ArgumentException("Объект не является студентом");
            }

            public override string ToString()
            {
                return $"{firstName} {lastName}, {city}, {age} " +
                       (age % 10 == 1 ? "год" : (age % 10 > 1 && age % 10 < 5) ? "года" : "лет") +
                       $", группа {group}, университет {university}, факультет {faculty}, кафедра {department}, {course} курс, ";
            }
        }

        class CourseAndAgeComparator : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                if ((x != null) && (y != null))
                {
                    var res = x.course.CompareTo(y.course);
                    if (res == 0)
                    {
                        res = x.age.CompareTo(y.age);
                    }

                    return res;
                }

                throw new ArgumentException("Один из аргументов не является студентом");
            }
        }

        private static List<Student> LoadStudents(string filename)
        {
            var sr = new StreamReader(filename);
            var list = new List<Student>();
            while (!sr.EndOfStream)
            {
                var s = sr.ReadLine()?.Split(';');
                if (s != null)
                    list.Add(new Student(
                        s[0], s[1], s[2],
                        s[3], s[4],
                        int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]
                    ));
            }

            return list;
        }

        private static int StudentsOnCurse(int cource, List<Student> list)
        {
            var courseCount = 0;
            foreach (var student in list)
            {
                if (student.course == cource)
                    courseCount += 1;
            }

            return courseCount;
        }

        private static int StudentsOfAge(int ageFrom, int ageBefore, List<Student> students)
        {
            var studentsCount = 0;
            foreach (var student in students)
            {
                if ((student.age >= ageFrom) && (student.age <= ageBefore))
                {
                    studentsCount++;
                }
            }

            return studentsCount;
        }

        private delegate bool Sorting(Student student, double parametrFrom, double parametrTo, string str);

        private static bool AgeCompare(Student student, double parametrFrom, double parametrTo, string str)
        {
            return student.age >= parametrFrom && student.age <= parametrTo;
        }

        private static bool CourseCompare(Student student, double parametrFrom, double parametrTo, string str)
        {
            return student.course >= parametrFrom && student.course <= parametrTo;
        }

        private static bool InstituteCompare(Student student, double parametrFrom, double parametrTo, string str)
        {
            return student.university.ToLower().Equals(str.ToLower().Trim());
        }

        private static bool FacilityCompare(Student student, double parametrFrom, double parametrTo, string str)
        {
            return student.faculty.ToLower().Equals(str.ToLower().Trim());
        }

        private static int CountBy(Sorting sorting, List<Student> students, double parametrFrom, double parametrTo,
            string str)
        {
            var res = 0;
            foreach (var student in students)
            {
                if (sorting(student, parametrFrom, parametrTo, str))
                {
                    res++;
                }
            }

            return res;
        }

        private static void Task3()
        {
            var students = LoadStudents("..\\..\\students.txt");

            Console.WriteLine(
                $"Студентов на 5 курсе - {StudentsOnCurse(5, students)}, на 6 - {StudentsOnCurse(6, students)}");
            Console.WriteLine($"Студентов от 18 лет до 20 - {StudentsOfAge(18, 20, students)}");
            Console.WriteLine("Сортировка по возрасту");
            students.Sort();
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Сортировка по курсу и возрасту");
            students.Sort(new CourseAndAgeComparator());
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("1 - количество студентов на курсе, 2 - на факультете, 3 - по возрасту, 4 по институту");
            var s = Console.ReadLine();
            Console.Clear();
            switch (s?.ToLower().Trim())
            {
                case "1":
                {
                    Console.WriteLine("Введите курс сначала от какого, потом до кагого");
                    var parametrFrom = int.Parse(Console.ReadLine() ?? string.Empty);
                    var parametrTo = int.Parse(Console.ReadLine() ?? string.Empty);
                    Console.WriteLine(
                        $"{CountBy(CourseCompare, students, parametrFrom, parametrTo, "")} студентов на курсах");
                }
                    break;
                case "2":
                {
                    Console.WriteLine("Введите название факультета");
                    var facility = Console.ReadLine();
                    Console.WriteLine($"{CountBy(FacilityCompare, students, 0, 0, facility)} стуентов на факультете");
                }
                    break;
                case "3":
                {
                    Console.WriteLine("Введите возраст сначала от какого, потом до кагого");
                    var parametrFrom = int.Parse(Console.ReadLine() ?? string.Empty);
                    var parametrTo = int.Parse(Console.ReadLine() ?? string.Empty);
                    Console.WriteLine(
                        $"{CountBy(AgeCompare, students, parametrFrom, parametrTo, "")} студентов от {parametrFrom} до {parametrTo}");
                }
                    break;
                case "4":
                {
                    Console.WriteLine("Введите название института");
                    var institute = Console.ReadLine();
                    Console.WriteLine($"{CountBy(FacilityCompare, students, 0, 0, institute)} стуентов на факультете");
                }
                    break;
            }
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
            Task3();
        }
    }
}