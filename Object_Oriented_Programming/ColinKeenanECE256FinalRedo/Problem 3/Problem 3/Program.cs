using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double err = 0;
            double input = 0;
            double value = 0;
            double atan = 0;

            Console.Write("Please input value in which you you like the inverse Tangent of: ");
            value = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please input error in terms of negative exponent: ");
            input = Convert.ToDouble(Console.ReadLine());
            err = Math.Pow(10, input);
            atan = inverseTangent(value, err);

            Console.WriteLine("myAtan({0}) with 10^{1} as the error value returns {2}", value, input, atan);
            Console.WriteLine("Math.atan({0}) = {1}", value, Math.Atan(value));
            Console.WriteLine("myAtan({0}) - Math.atan({0}) = {1}", value, Math.Abs(atan - Math.Atan(value)));
            Console.WriteLine("Error: {0}\n", Math.Abs(((atan - Math.Atan(value)) / Math.Atan(value))));

            Console.Write("Please input value in which you you like the inverse Tangent of: ");
            value = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please input error in terms of negative exponent: ");
            input = Convert.ToDouble(Console.ReadLine());
            err = Math.Pow(10, input);
            atan = inverseTangent(value, err);

            Console.WriteLine("myAtan({0}) with 10^{1} as the error value returns {2}", value, input, atan);
            Console.WriteLine("Math.atan({0}) = {1}", value, Math.Atan(value));
            Console.WriteLine("myAtan({0}) - Math.atan({0}) = {1}", value, Math.Abs(atan - Math.Atan(value)));
            Console.WriteLine("Error: {0}\n", Math.Abs(((atan - Math.Atan(value)) / Math.Atan(value))));
        }
        static double inverseTangent(double x, double error)
        {
            double numerator = 0;
            double denominator = 0;
            double answer = x;
            double check = Math.Atan(x);
            int i = 2;
            while (Math.Abs(check - answer) > error)
            {
                numerator = Math.Pow(-1, (i + 1)) * Math.Pow(x, (2 * i) - 1);
                denominator = (2 * i) - 1;
                answer += numerator / denominator;
                if(i < 5)
                {
                    Console.Write("({0} / {1}) + ", numerator, denominator);
                }
                else if(i == 5)
                {
                    Console.Write("...");
                }
                i++;
            }
            Console.WriteLine("\n{0} iterations", i + 1);
            return answer;
        }
    }

}
