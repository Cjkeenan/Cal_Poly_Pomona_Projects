using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinKeenanECE256Exercise1
{
    class Problem2
    {
        public void Run()
        {
            bool first = true;
            string s1 = "On the ";
            string s2 = " day of Christmas,\nmy true love sent to me ";
            string s = "";
            string[] days = new string[13] { "", "first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eighth", "ninth",
                                                "tenth", "eleventh", "twelfth"};
            string[] x = new string[13] { "", "And a partridge in a pear tree. ", "Two turtle doves, ", "Three French hens, ", 
                                            "Four calling birds, ", "Five golden rings, ", "Six geese a-laying, ",
                                            "Seven swans a-swimming, ", "Eight maids a-milking, ", "Nine ladies dancing, ",
                                            "Ten lords a-leaping, ", "Eleven pipers piping, ", "Twelve drummers drumming, "};
            if (first)
            {
                first = false;
                s += s1 + days[1] + s2;
                for (int j = 1; j >= 1; j--)
                {
                    s += "\na partridge in a pear tree. ";   //concatenate first verse into output string since it changes for the rest
                }
                s += "\n\n";        //add lines for clarity between verses
            }
            for (int i = 2; i <= 12; i++)
            {
                // For each i > 2, print the ith day
                s += s1 + days[i] + s2;
                for (int j = i; j >= 1; j--)
                {
                    s += "\n" + x[j];   //concatenate verses into output string with each set of items on a new line
                }
                s += "\n\n";        //add lines for clarity between verses

            }
            Console.WriteLine(s);       //output song

        }
    }
}