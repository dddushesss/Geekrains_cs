using System;

namespace Dz1
{
    public class PointsDistance
    {
        /*
         Павлов Алексей
         а) Написать программу, которая подсчитывает расстояние между точками
          с координатами x1, y1 и x2,y2 по формуле
          r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). 
          Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
         б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
 
         */
        private static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public void PrintDistance()
        {
            Console.Write("x1: ");
            var x1=double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("y1: ");
            var y1=double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("x2: ");
            var x2=double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("y2: ");
            var y2=double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            
            Console.WriteLine("Расстояние между точками: {0:f2}", CalculateDistance(x1,y1,x2,y2));
        }
    }
}