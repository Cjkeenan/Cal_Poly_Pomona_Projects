using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequential_Sorting
{
    class Sort
    {
        static void Main(string[] args)
        {
            //Generate Random Array Values
            Random rnd = new Random();
            int size = 20;
            int[] numbers = new int[size];
            for (int i = 0; i < size; i++)
            {
                numbers[i] = rnd.Next(0, 4 * size);
            }

            //Print out unsorted array values
            Console.Write("Unsorted Array Values: {");
            for(int i = 0; i < size; i++)
            {
                if (i == size - 1) Console.Write(numbers[i]);
                else Console.Write("{0}, ", numbers[i]);
            }
            Console.Write("}\n");

            //Sort Array (Bubble)
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }


            //Print out sorted array values
            Console.Write("Sorted Array Values: {");
            for (int i = 0; i < size; i++)
            {
                if (i == size - 1) Console.Write(numbers[i]);
                else Console.Write("{0}, ", numbers[i]);
            }
            Console.Write("}\n");
        }
    }
}
