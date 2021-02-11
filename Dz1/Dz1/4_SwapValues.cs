using System;

namespace Dz1
{
    /*
     Павлов Алексей
    Написать программу обмена значениями двух переменных:
    а) с использованием третьей переменной;
	б) *без использования третьей переменной.
     */
    public class SwapValues
    {
        public void SwapWithVar(int a, int b)
        {
            Console.WriteLine($"a = {a}, b = {b}");
            int tmp = a;
            a = b;
            b = tmp;
            Console.WriteLine($"a = {a}, b = {b}");
        }

        public void SwapWithoutVar(int a, int b)
        {
            Console.WriteLine($"a = {a}, b = {b}");
            a = a + b;
            b = b - a;
            b = -b;
            a = a - b;
            Console.WriteLine($"a = {a}, b = {b}");
        }
    }
}