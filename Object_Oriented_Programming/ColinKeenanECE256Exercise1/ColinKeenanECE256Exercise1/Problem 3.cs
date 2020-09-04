using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinKeenanECE256Exercise1
{
    class Problem3
    {
        public void Run()
        {
            double P, r, I, x; // principal, monthly rate, and installment
            int n; // number of years

            Console.Write("Input principal for the loan: ");
            P = Convert.ToDouble(Console.ReadLine());        //principal

            Console.Write("Input annual rate in % for the loan: ");
            r = Convert.ToDouble(Console.ReadLine());        //monthly rate
            r = r / 1200;

            Console.Write("Input an integer number of years for the loan: ");
            n = Convert.ToInt32(Console.ReadLine());        //years for loan

            Console.Write("Compute (1+r)^ 12n:\n");
            x = Math.Pow(1 + r, 12 * n);
            Console.Write("pow (1+r, 12*n) AKA x is {0}\n\n", x);
            I = P * x * r / (x - 1);

            Console.Write("Installment is {0:C}.\n", I);
            Console.Write("Total payment is {0:C}.\n\n", 12 * n * I);
        }
    }
}
