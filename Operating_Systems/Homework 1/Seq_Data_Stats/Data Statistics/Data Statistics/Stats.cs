using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Statistics
{
    class Stats
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int size = 40;
            int max_value = size;
            double[] data = new double[size];
            for(int i = 0; i < size; i++)
            {
                data[i] = rnd.NextDouble() * (max_value);
            }
            Print_Array(data, size);

            //Statistics
            double mean, min, max, median, std_deviation;
            mean = Get_Average(data);
            median = Get_Median(data);
            min = Get_Min(data);
            max = Get_Max(data);
            std_deviation = Get_std_deviation(data);

            Console.WriteLine("\nMean: {0:f}\n" +
                              "Median: {1:f}\n" +
                              "Min: {2:f}\n" +
                              "Max: {3:F}\n" +
                              "Standard Deviation: {4:f}\n",
                              mean, median, min, max, std_deviation);
        }

        public static double Get_Average(double[] array)
        {
            double avg;
            double total = 0;
            int count = 0;
            foreach(double item in array)
            {
                total += item;
                count++;
            }
            avg = total / count;
            return avg;
        }
        public static double Get_Min(double[] array)
        {
            double min;
            min = array[0];
            foreach (double item in array)
            {
                if(item < min)
                {
                    min = item;
                }
            }
            return min;
        }
        public static double Get_Max(double[] array)
        {
            double max;
            max = array[0];
            foreach (double item in array)
            {
                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }
        public static double Get_Median(double[] array)
        {
            double result;
            int count = 0;
            foreach(double item in array)
            {
                count++;
            }
            result = array[count / 2];
            return result;
        }
        public static double Get_std_deviation(double[] array)
        {
            double result;
            double mean = Get_Average(array);
            double numerator = 0;
            double count = 0;
            foreach(double item in array)
            {
                count++;
                numerator += Math.Pow((item - mean), 2);
            }
            result = Math.Sqrt(numerator / count);
            return result;
        }
        public static void Print_Array(double[] array, int size)
        {
            Console.Write("Array Values: {");
            for (int i = 0; i < size; i++)
            {
                if (i == size - 1) Console.Write("{0:f}", array[i]);
                else Console.Write("{0:f}, ", array[i]);
            }
            Console.Write("}\n");
        }
    }
}