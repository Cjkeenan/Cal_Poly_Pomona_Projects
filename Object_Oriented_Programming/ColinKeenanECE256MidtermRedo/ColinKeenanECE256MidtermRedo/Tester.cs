using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ColinKeenanECE256MidtermRedo
{
    class Tester
    {
        static void Main(string[] args)
        {
            Problem_4 P4 = new Problem_4();
            Problem_5 P5 = new Problem_5();
            Problem_6 P6 = new Problem_6();
            Problem_8 P8 = new Problem_8();

            //Problem 4
            Console.WriteLine("Problem 4:");
            P4.Run();

            //Problem 5
            Console.WriteLine("\n\nProblem 5:");
            P5.Run();

            //Problem 6
            Console.WriteLine("\n\nProblem 6:");
            P6.Run();

            //Problem 8
            Console.WriteLine("\n\nProblem 8:");
            P8.Run();
        }
    }
}
