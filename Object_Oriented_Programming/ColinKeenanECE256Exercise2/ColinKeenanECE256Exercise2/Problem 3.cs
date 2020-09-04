using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinKeenanECE256Exercise2
{
    public class Problem_3
    {
        public void Run()
        {
            int integer;
            string binary;
            Console.Write("Please enter an integer that you would like to convert to binary: ");
            integer = Convert.ToInt32(Console.ReadLine());

            binary = Convert.ToString(integer, 2);
            Console.WriteLine(binary);
        }
    }
}
