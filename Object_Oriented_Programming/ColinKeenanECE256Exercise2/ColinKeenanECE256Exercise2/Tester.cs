using System;

namespace ColinKeenanECE256Exercise2
{
    class Tester
    {
        static void Main(string[] args)
        {
            Problem_1 P1 = new Problem_1();
            Problem_2 P2 = new Problem_2();
            Problem_3 P3 = new Problem_3();

            // create GradeBook object myGradeBook and 
            // pass course name to constructor
            GradeBook myGradeBook = new GradeBook(
               "ECE 256 Introduction to C# Programming");
            /*
            Console.WriteLine("Problem 1:");
            P1.Run();
            P1.Run();
            P1.Run();

            Console.WriteLine("\nProblem 2:");
            Console.WriteLine("Right Triangle:");
            P2.Run();
            Console.WriteLine("\nObtuse Triangle:");
            P2.Run();
            Console.WriteLine("\nAcute Triangle:");
            P2.Run();
            Console.WriteLine("\nInvalid Triangle:");
            P2.Run();
            
            Console.WriteLine("\nProblem 3:");
            P3.Run();
            P3.Run();
            */
            Console.WriteLine("\nExtra Credit:");
            myGradeBook.DisplayMessage(); // display welcome message
            myGradeBook.DetermineClassAverage(); // find average of entered grades
        }
    }
}
