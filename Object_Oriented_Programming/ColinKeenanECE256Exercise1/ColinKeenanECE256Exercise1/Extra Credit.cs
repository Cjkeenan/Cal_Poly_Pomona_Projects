using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinKeenanECE256Exercise1
{
    class ExtraCredit              
    {
        public void Run()
        {
            int counter = 0;

            for (int o = 4; o >= 0; o--)    // O (No solutions contain 'o' greater than 4)
            {
                for (int n = 9; n >= 0; n--)    // N
                {
                    if(o == n)
                    {
                        continue;
                    }
                    for (int e = 7; e >= 0; e--)    // E (No solutions contain 'e' greater than 7)
                    {
                        if(e == o || e == n)
                        {
                            continue;
                        }
                        for (int t = 9; t >= 0; t--)    // T
                        {
                            if (t == o || t == n || t == e)
                            {
                                continue;
                            }
                            for (int w = 9; w >= 0; w--)    // W
                            {
                                if (w == o || w == n || w == e || w == t)
                                {
                                    continue;
                                }
                                //Test equation
                                if (((t * 100) + (w * 10) + o) == (((o * 100) + (n * 10) + e) + ((o * 100) + (n * 10) + e)))
                                {
                                    counter++;       //Increment solution number

                                    //Output a correct solution
                                    Console.WriteLine("{0}. ONE[{1}{2}{3}] + ONE[{1}{2}{3}] = TWO[{4}{5}{1}]", counter, o, n, e, t, w);
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("\nThere are {0} solutions to the equation ONE + ONE = TWO.\n", counter);
        }
    }
}
