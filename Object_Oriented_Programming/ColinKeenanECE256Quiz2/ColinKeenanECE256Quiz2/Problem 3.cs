using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinKeenanECE256Quiz2
{
    class Problem_3
    {
        public void Run()
        {
            Complex A = new Complex();
            A.SetComplex(1, -1);

            Complex B = new Complex();
            B.SetComplex(0, 1);

            Complex C = new Complex();
            C.SetComplex(1, 1);

            Complex D = new Complex();
            D.SetComplex(0, 0);

            Complex w = new Complex();
            double w1 = -1.0 / 2.0;
            double w2 = Math.Sqrt(3.0) / 2.0;
            w.SetComplex(w1, w2);

            Console.Write("(1-j)^500 = ");
            complexExponential(A, 500);
            Console.Write("j^1003 = ");
            complexExponential(B, 1003);
            Console.Write("w^300 = ");
            complexExponential(w, 300);

            C.div(A);
            Console.Write("\nThe division of (1+i)/(1-i) = ");
            C.print();

            Console.WriteLine("\nThis division should throw a divide by zero exception");
            C.div(D);
        }

        public static void complexExponential(Complex c, int power)
        {
            Complex cA = new Complex();
            cA.copy(c);
            Complex cB = new Complex();
            cB.copy(c);
            for (int i = 1; i < power; i++)
            {
                cA.mul(cB);
            }
            cA.print();
        }
    }
 }


