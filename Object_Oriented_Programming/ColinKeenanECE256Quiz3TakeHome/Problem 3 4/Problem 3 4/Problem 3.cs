using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems_3_4
{
    class Problem_3
    {
        public void Run()
        {
            ///////////////////////////////////////////////////////
            int[] n456 = { 4, 5, 6 };
            int[] n654 = { 6, 5, 4 };

            HugeInteger Huge456 = new HugeInteger(n456, 1);
            HugeInteger Huge654 = new HugeInteger(n654, 1);

            Console.WriteLine("for integers, 456 and 654:");
            Console.WriteLine(Huge456.print() + " + " + Huge654.print() + " = " + Huge456.add(Huge654).print()); //456+654
            Console.WriteLine(Huge456.print() + " - " + Huge654.print() + " = " + Huge456.subtract(Huge654).print()); //456-654
            Huge456 = new HugeInteger(n456, 1); //make 456 out of array
            Huge654 = new HugeInteger(n654, 1); // make 654 out of array
            Console.WriteLine(Huge456.print() + " * " + Huge654.print() + " = " + Huge456.product(Huge654).print()); // 456*654

        }
    }
}
