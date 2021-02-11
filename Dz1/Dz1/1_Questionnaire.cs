using System;

namespace Dz1
{
    /*
     Павлов Алексей
     Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес).
     В результате вся информация выводится в одну строчку:
    а) используя  склеивание;
	б) используя форматированный вывод;
	в) используя вывод со знаком $.
     */
    public class Questionnaire
    {
        public void PrintQuestionnaire()
        {
            Console.WriteLine("Введите имя:");
            var name = Console.ReadLine();
            Console.WriteLine("Введите фамилию:");
            var surname = Console.ReadLine();
            Console.WriteLine("Введите возраст:");
            var age = Console.ReadLine();
            Console.WriteLine("Введите рост:");
            var height = Console.ReadLine();
            Console.WriteLine("Введите вес:");
            var weight = Console.ReadLine();
            Console.WriteLine(name + ' ' + surname + ' ' + age + ' ' + height + ' ' + weight);
            Console.WriteLine("Имя: {0} Фамилия: {1}  Возраст: {2} Рост: {3}, Вес: {4}", name, surname, age, height,
                weight);
            Console.WriteLine($"Имя: {name} Фамилия: {surname} Возраст: {age}  Рост: {height} Вес: {weight}");
        }
        
    }
}