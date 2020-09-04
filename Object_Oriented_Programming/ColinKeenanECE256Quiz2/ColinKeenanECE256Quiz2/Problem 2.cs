using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinKeenanECE256Quiz2
{
    class Problem_2
    {
        public void Run()
        {
            //number 1
            long number = 1357;
            long tempNum = number;
            long reverse, tripleReverse;
            long temp1, temp2, temp3, temp4;

            temp1 = number % 10;
            number /= 10;
            temp2 = number % 10;
            number /= 10;
            temp3 = number % 10;
            number /= 10;
            temp4 = number % 10;
            number /= 10;

            reverse = (1000 * temp1) + (100 * temp2) + (10 * temp3) + temp4;
            tripleReverse = 3 * reverse;

            Console.WriteLine("Original number: {0}\tReverse number: {1}\tTripled Reverse number: {2}", tempNum, reverse, tripleReverse);

            //number 2
            number = 123456;
            tempNum = number;
            long temp5, temp6;

            temp1 = number % 10;
            number /= 10;
            temp2 = number % 10;
            number /= 10;
            temp3 = number % 10;
            number /= 10;
            temp4 = number % 10;
            number /= 10;
            temp5 = number % 10;
            number /= 10;
            temp6 = number % 10;
            number /= 10;

            reverse = (100000 * temp1) + (10000 * temp2) + (1000 * temp3) + (100 * temp4) + (10 * temp5) + temp6;
            tripleReverse = 3 * reverse;

            Console.WriteLine("Original number: {0}\tReverse number: {1}\tTripled Reverse number: {2}", tempNum, reverse, tripleReverse);

            //number 3
            number = 13;
            tempNum = number;
            

            temp1 = number % 10;
            number /= 10;
            temp2 = number % 10;
            number /= 10;

            reverse = (10 * temp1) + temp2;
            tripleReverse = 3 * reverse;

            Console.WriteLine("Original number: {0}\tReverse number: {1}\tTripled Reverse number: {2}", tempNum, reverse, tripleReverse);

        }
    }
}
