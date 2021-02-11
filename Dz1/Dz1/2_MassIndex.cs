using System;

namespace Dz1
{
    public class MassIndex
    {
        /*
         Павлов Алексей
         Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); 
         где m — масса тела в килограммах, h — рост в метрах.
         */
        private double CalculateMassIndex(double weight, double height)
        {
            return weight / (height * height);
        }

        public void PrintMassIndex()
        {
            Console.WriteLine("Введите рост: ");
            var weight = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine("Введите вес: ");
            var height = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine($"Индекс массы = {CalculateMassIndex(weight, height)}");
        }
    }
}