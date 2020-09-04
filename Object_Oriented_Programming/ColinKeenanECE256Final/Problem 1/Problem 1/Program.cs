using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 0;
            double myexp = 0;
            double mathexp = 0;
            while (value != -1)
            {  
                Console.Write("Please input value of exponent for the exponential function: ");
                value = Convert.ToInt32(Console.ReadLine());

                myexp = CalculateExp(value);
                mathexp = Math.Exp(value);

                Console.WriteLine("myexp({0}) = {1:F5}", value, myexp);
                Console.WriteLine("Math.exp({0}) = {1:F5}", value, mathexp);
                Console.WriteLine("myexp({0}) - Math.exp({0}) = {1:F5}", value, Math.Abs(myexp - mathexp));
                Console.WriteLine("Percent error with value of {0}: {1:F5}%\n", value, Math.Abs(((myexp - mathexp) / mathexp) * 100));
            }
        }

        static double CalculateExp(double x)
        {

            // Holds and returns final answer
            double answer = 0;

            // Holds previous answer and is used to stop Taylor Expansion
            double oldanswer = 0;

            // Summation index variable
            double k = 0;

            // Refine the solution by adding more terms to the Taylor Expansion.
            // Stop when the answer doesn't change.
            while (true)
            {
                answer += Math.Pow(x, k) / Factorial(k);
            
                if (answer == oldanswer)
                {
                    break;
                }
                else
                {
                    oldanswer = answer;
                    k++;
                }
            }

            // Write directly to the console here to avoid global variable
            Console.WriteLine("Answer calculated in " + k.ToString() + " iterations.");

            // Return solution to caller
            return answer;
        }

        static double Factorial(double x)
        {

            double answer = 1;
            double counter = 1;

            while (counter <= x)
            {
                answer = answer * counter;
                counter++;

            }

            return answer;
        }

    }
}
