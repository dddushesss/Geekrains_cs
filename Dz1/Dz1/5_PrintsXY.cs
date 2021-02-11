using System;

namespace Dz1
{
    /*
     Павлов Алексей
     а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
     б) *Сделать задание, только вывод организовать в центре экрана.
     в) **Сделать задание б с использованием собственных методов
      (например, Print(string ms, int x,int y).
     */
    public class PrintsXy
    {
        private string _name;
        private string _surname;
        private string _city;

        public PrintsXy(string name, string surname, string city)
        {
            _name = name;
            _surname = surname;
            _city = city;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{_name} {_surname}, {_city}");
        }

        public void printInfoOnCentre()
        {
            PrintOnXY($"{_name} {_surname}, {_city}", Console.WindowWidth / 2, Console.CursorTop);
        }

        private void PrintOnXY(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }
    }
}