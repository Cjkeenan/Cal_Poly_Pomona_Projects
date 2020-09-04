using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinKeenanECE256Midterm
{
    class Tester
    {
        static void Main(string[] args)
        {
            Problem_1 P1 = new Problem_1();
            Problem_2 P2 = new Problem_2();
            Problem_3 P3 = new Problem_3();

            //Problem 1
            Console.WriteLine("Problem 1:");
            P1.Run();

            //Problem 2
            Console.WriteLine("\nProblem 2:");
            P2.Run();

            //Problem 3
            Console.WriteLine("\nProblem 3:");
            P3.Run();

        }
    }
}
