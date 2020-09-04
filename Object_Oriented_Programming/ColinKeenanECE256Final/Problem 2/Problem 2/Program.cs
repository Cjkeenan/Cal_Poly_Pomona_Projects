using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double err = 0;
            double input = 0;
            Console.Write("Please input error in terms of negative exponent: ");
            input = Convert.ToDouble(Console.ReadLine());
            err = Math.Pow(10, input);
            double Pi = CalculatePi(err);

            Console.WriteLine("myPi with 10^{0} as the error value returns {1}", input, Pi);
            Console.WriteLine("Math.PI = {0}", Math.PI);
            Console.WriteLine("myPi() - Math.PI = {0}", Math.Abs(Pi - Math.PI));
            Console.WriteLine("Error: {0}\n", Math.Abs(((Pi - Math.PI) / Math.PI)));

            Console.Write("Please input error in terms of negative exponent: ");
            input = Convert.ToDouble(Console.ReadLine());
            err = Math.Pow(10, input);
            Pi = CalculatePi(err);

            Console.WriteLine("myPi with 10^{0} as the error value returns {1}", input, Pi);
            Console.WriteLine("Math.PI = {0}", Math.PI);
            Console.WriteLine("myPi() - Math.PI = {0}", Math.Abs(Pi - Math.PI));
            Console.WriteLine("Error: {0}\n", Math.Abs(((Pi - Math.PI) / Math.PI)));
        }

        static double CalculatePi(double error)
        {
            double numerator = 0;
            double denominator = 0;
            double answer = 1;
            double check = Math.PI / 4;
            int i = 2;
            while(Math.Abs(check - answer) > error)
            {
                numerator = Math.Pow(-1, (i + 1));
                denominator = (2 * i) - 1;
                answer += numerator / denominator;
                i++;
            }
            Console.WriteLine("{0} iterations", i + 1);
            return 4 * answer;
        }
    }
}
