using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinKeenanECE256Quiz1
{
    class Quiz1
    {
        public static bool IsPrime(int k)
        {  // method to check if k is a prime
            for (int j = 2; j <= Math.Sqrt((double)k); j++)  // Need to check up to square root only
                if (k % j == 0)  // if j divides k
                    return false;

            return true;
        }

        static void Main(string[] args)
        {
            //Problem 1
            Console.WriteLine("Problem 1:");
            int sum10 = 0;
            int iteration10 = 0;
            for(int i = 10; i > 0; i--)
            {
                iteration10++;
                sum10 += i;
                Console.WriteLine("Sum of 10 + 9 + .. + 1 is {0} in iteration {1}", sum10, iteration10);
            }

            //Problem 2
            Console.WriteLine("\nProblem 2:");
            int sum100 = 0;
            int iteration100 = 0;
            for(int i = 1; i <= 100; i++)
            {
                iteration100++;
                sum100 += i;
                if(sum100 > 2000)
                {
                    Console.WriteLine("At iteration {0}, the sum of 1 + 2 + .. + {0} is {1} > 2000", iteration100, sum100);
                    break;
                }
            }

            //Problem 3
            Console.WriteLine("\nProblem 3:");
            sum100 = 0;
            iteration100 = 0;
            for (int i = 1; i <= 100; i++)
            {
                iteration100++;
                sum100 += i;
                if (sum100 >= 1000)
                {
                    Console.WriteLine("At iteration {0}, the sum of 1 + 2 + .. + {0} is {1} < 1000, but the sum of 1 + 2 + .. + {0} + {2} is {3} >= 1000", iteration100 - 1, sum100 - i, iteration100, sum100);
                    break;
                }
            }

            //Problem 4
            Console.WriteLine("\nProblem 4:");
            int sumSquared = 0;
            for(int i = 0; i <= 10; i++)
            {
                sumSquared += (i * i);
            }
            Console.WriteLine("Sum of 1*1 + 2*2 + 3*3 + .. + 10*10 is {0}", sumSquared);

            //Problem 5
            Console.WriteLine("\nProblem 5:");
            string name = "";
            Console.Write("Please enter your name: ");
            name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Welcome to C#, {0}", name);

            //Problem 6
            Console.WriteLine("\nProblem 6:");
            //Part A
            Console.WriteLine("\nPart A:");
            int primeCounter = 0;
            int column = 0;
            for(int i = 2; i <= 500; i++)
            {
                if (IsPrime(i))
                {
                    primeCounter++;
                    column++;
                    if (column == 8)
                    {
                        column = 0;
                        Console.Write("{0}\t\n", i);
                    }
                    else
                    {
                        Console.Write("{0}\t", i);
                    }
                }
            }
            Console.WriteLine("\nThere are {0} prime numbers from 2 to 500", primeCounter);

            //Part B
            Console.WriteLine("\nPart B:");
            int n;
            Console.Write("Please enter an integer that you would like to test until: ");
            n = Convert.ToInt32(Console.ReadLine());
            primeCounter = 0;
            column = 0;
            for (int i = 2; i <= n; i++)
            {
                if (IsPrime(i))
                {
                    primeCounter++;
                    column++;
                    if (column == 8)
                    {
                        column = 0;
                        Console.Write("{0}\t\n", i);
                    }
                    else
                    {
                        Console.Write("{0}\t", i);
                    }
                }
            }
            Console.WriteLine("\nThere are {0} prime numbers from 2 to {1}", primeCounter, n);
        }
    }
}
