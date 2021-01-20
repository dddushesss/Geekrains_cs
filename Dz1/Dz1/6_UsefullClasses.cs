using System;

namespace Dz1
{
    public class UsefullClasses
    {
        /*
         * Павлов Алексей
         *Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause). 
         */
        public void Pause()
        {
            Console.ReadKey();
        }

        public void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}