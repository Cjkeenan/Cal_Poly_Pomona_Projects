using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinKeenanECE256Exercise1
{
    class Problem1
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

            number = 2018;
            temp = number;              //store number for output
            sum = 0;
            while (number != 0)
            {
                sum += number % 10;     //add the last digit of the number to the sum
                number /= 10;           //remove the last digit of the number
            }
            Console.WriteLine("The sum for the digits {0} is {1}.", temp, sum);

            number = randomNumber.Next(10000, 100000);      //random 5-digit number
            temp = number;              //store number for output
            sum = 0;
            while (number != 0)
            {
                sum += number % 10;     //add the last digit of the number to the sum
                number /= 10;           //remove the last digit of the number
            }
            Console.WriteLine("The sum for the digits {0} is {1}.", temp, sum);

            number = randomNumber.Next(10000000, 100000000);        //random 8-digit number
            temp = number;              //store number for output
            sum = 0;
            while (number != 0)
            {
                sum += number % 10;     //add the last digit of the number to the sum
                number /= 10;           //remove the last digit of the number
            }
            Console.WriteLine("The sum for the digits {0} is {1}.\n", temp, sum);
        }
    }
}
