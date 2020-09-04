using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinKeenanECE256Quiz2
{
    class Problem_1
    {
        public void Run()
        {
            Random randomNumber = new Random();
            long number = 256;
            long temp = number;         //store number for output
            long sum = 0;
            while (number != 0)
            {
                sum += number % 10;     //add the last digit of the number to the sum
                number /= 10;           //remove the last digit from the number
            }
            Console.WriteLine("The sum for the digits {0} is {1}.", temp, sum);
            Console.WriteLine("3 times the sum of the digits {0} is {1}.\n", temp, 3 * sum);

            number = 65536;
            temp = number;              //store number for output
            sum = 0;
            while (number != 0)
            {
                sum += number % 10;     //add the last digit of the number to the sum
                number /= 10;           //remove the last digit of the number
            }
            Console.WriteLine("The sum for the digits {0} is {1}.", temp, sum);
            Console.WriteLine("3 times the sum of the digits {0} is {1}.\n", temp, 3 * sum);

            number = randomNumber.Next(1000000, 10000000);      //random 7-digit number
            temp = number;              //store number for output
            sum = 0;
            while (number != 0)
            {
                sum += number % 10;     //add the last digit of the number to the sum
                number /= 10;           //remove the last digit of the number
            }
            Console.WriteLine("The sum for the digits {0} is {1}.", temp, sum);
            Console.WriteLine("3 times the sum of the digits {0} is {1}.\n", temp, 3 * sum);

            number = randomNumber.Next(10000000, 100000000);        //random 8-digit number
            temp = number;              //store number for output
            sum = 0;
            while (number != 0)
            {
                sum += number % 10;     //add the last digit of the number to the sum
                number /= 10;           //remove the last digit of the number
            }
            Console.WriteLine("The sum for the digits {0} is {1}.", temp, sum);
            Console.WriteLine("3 times the sum of the digits {0} is {1}.", temp, 3 * sum);
        }
    }
}
