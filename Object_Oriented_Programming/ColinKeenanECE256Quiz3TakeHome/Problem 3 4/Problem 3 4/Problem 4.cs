using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems_3_4
{
    class Problem_4
    {
        public void Run()
        {
            //set integer arrays
            //first three numbers are used for factorial calclulation
            int[] fac1 = { 1 };
            int[] fac30 = { 3, 0 };// 30!
            int[] fac50 = { 5, 0};// 50!
            int[] fac100 = { 1, 0, 0 };// 100!
            int[] fac3 = { 1 };
            //these two are used for huge integer calculation 
            int[] num456 = { 4, 5, 6 }; //456
            int[] num654 = { 6, 5, 4 };//654

            HugeInteger Huge1 = new HugeInteger(fac1, 1);
            HugeInteger Huge2 = new HugeInteger(fac30, 1);
            HugeInteger HugeFac = new HugeInteger(fac3, 1);

            Console.Write("\n30! is equal to: ");

            for (int i = 1; i <= 30; i++) //Calculate factorial!
            {
                Huge1 = Huge1.product(Huge2); //1 * factorialnum
                Huge2 = Huge2.subtract(HugeFac); // factorialnum - 1
            }

            Console.WriteLine(Huge1.print());

            Huge1 = new HugeInteger(fac1, 1);
            Huge2 = new HugeInteger(fac50, 1);
            HugeFac = new HugeInteger(fac3, 1);

            Console.Write("\n50! is equal to: ");

            for (int i = 1; i <= 50; i++) //Calculate factorial
            {
                Huge1 = Huge1.product(Huge2); //1 * factorialnum
                Huge2 = Huge2.subtract(HugeFac); // factorialnum - 1
            }

            Console.WriteLine(Huge1.print());

            Huge1 = new HugeInteger(fac1, 1);
            Huge2 = new HugeInteger(fac100, 1);
            HugeFac = new HugeInteger(fac3, 1);

            Console.Write("\n100! is equal to: ");

            for (int i = 1; i <= 100; i++) //Calculate factorial!
            {
                Huge1 = Huge1.product(Huge2); //1 * factorialnum
                Huge2 = Huge2.subtract(HugeFac); // factorialnum - 1
            }

            Console.WriteLine(Huge1.print());
            
        }
    }
}
