using System;

namespace Dz1
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            //1
            var questionnaire = new Questionnaire();
            questionnaire.PrintQuestionnaire();
            //2
            var massIndex = new MassIndex();
            massIndex.PrintMassIndex();
            //3
            var pointsDistance = new PointsDistance();
            pointsDistance.PrintDistance();
            //4
            var swapVars = new SwapValues();
            swapVars.SwapWithVar(5, 2);
            Console.WriteLine("<....>");
            swapVars.SwapWithoutVar(5, 2);
            //5
            var printInfo = new PrintsXy("Алексей", "Павлов", "Санкт-Петербург");
            printInfo.PrintInfo();
            printInfo.printInfoOnCentre();
            //6
            var usefullClasses = new UsefullClasses();
            usefullClasses.Pause();
            usefullClasses.Print("Сообщение");
        }
    }
}