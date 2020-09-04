using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinKeenanECE256Exercise1
{
    class Tester
    {
        static void Main(string[] args)
        {
            Problem1 P1 = new Problem1();
            Problem2 P2 = new Problem2();
            Problem3 P3 = new Problem3();
            ExtraCredit EC = new ExtraCredit();

            Console.WriteLine("Problem 1:");
            P1.Run();    //Display Problem 1
            Console.WriteLine("\nProblem 2:");
            P2.Run();    //Display Problem 2
            Console.WriteLine("Problem 3:");
            P3.Run();    //Display Problem 3
            Console.WriteLine("\nExtra Credit:");
            EC.Run();    //Display Extra Credit

        }
    }
}
