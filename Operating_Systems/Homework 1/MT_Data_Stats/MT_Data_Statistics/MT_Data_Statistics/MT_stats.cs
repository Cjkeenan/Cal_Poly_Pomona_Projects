using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MT_Data_Statistics
{
    class MT_Data_Stats
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int size = 40;
            int max_value = size;
            double[] data = new double[size];
            for (int i = 0; i < size; i++)
            {
                data[i] = rnd.NextDouble() * (max_value);
            }
            Print_Array(data, size);

            //Statistic Threads setup
            int threads = 5;
            Thread[] stat_threads = new Thread[threads];

            //Mean
            double mean = 0;
            stat_threads[0] = new Thread(() => mean = Get_Average(data, mean));
            stat_threads[0].SetApartmentState(ApartmentState.MTA);
            stat_threads[0].Name = string.Format("Mean");
            stat_threads[0].Start();
            Console.WriteLine("Thread {0} started!", stat_threads[0].Name.ToString());

            //Median
            double median = 0;
            stat_threads[1] = new Thread(() => median = Get_Median(data, median));
            stat_threads[1].SetApartmentState(ApartmentState.MTA);
            stat_threads[1].Name = string.Format("Median");
            stat_threads[1].Start();
            Console.WriteLine("Thread {0} started!", stat_threads[1].Name.ToString());

            //Min
            double min = 0;
            stat_threads[2] = new Thread(() => min = Get_Min(data, min));
            stat_threads[2].SetApartmentState(ApartmentState.MTA);
            stat_threads[2].Name = string.Format("Min");
            stat_threads[2].Start();
            Console.WriteLine("Thread {0} started!", stat_threads[2].Name.ToString());

            //Max
            double max = 0;
            stat_threads[3] = new Thread(() => max = Get_Max(data, max));
            stat_threads[3].SetApartmentState(ApartmentState.MTA);
            stat_threads[3].Name = string.Format("Max");
            stat_threads[3].Start();
            Console.WriteLine("Thread {0} started!", stat_threads[3].Name.ToString());

            //Standard Deviation
            double standard_deviation = 0;
            stat_threads[4] = new Thread(() => standard_deviation = Get_std_deviation(data, standard_deviation));
            stat_threads[4].SetApartmentState(ApartmentState.MTA);
            stat_threads[4].Name = string.Format("Standard Deviation");
            stat_threads[4].Start();
            Console.WriteLine("Thread {0} started!", stat_threads[4].Name.ToString());

            //Join Statistic Threads
            for (int i = 0; i < threads; i++)
            {
                stat_threads[i].Join();
                Console.WriteLine("Thread {0} joined!", stat_threads[i].Name.ToString());
            }

            Console.WriteLine("\nMean: {0:f}\n" +
                  "Median: {1:f}\n" +
                  "Min: {2:f}\n" +
                  "Max: {3:F}\n" +
                  "Standard Deviation: {4:f}\n",
                  mean, median, min, max, standard_deviation);
        }

        public static double Get_Average(double[] array, double avg)
        {
            double total = 0;
            int count = 0;
            foreach (double item in array)
            {
                total += item;
                count++;
            }
            avg = total / count;
            return avg;
        }
        public static double Get_Min(double[] array, double min)
        {
            min = array[0];
            foreach (double item in array)
            {
                if (item < min)
                {
                    min = item;
                }
            }
            return min;
        }
        public static double Get_Max(double[] array, double max)
        {
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
        public static double Get_Median(double[] array, double median)
        {
            int count = 0;
            foreach (double item in array)
            {
                count++;
            }
            median = array[count / 2];
            return median;
        }
        public static double Get_std_deviation(double[] array, double result)
        {
            double mean = 0;
            Get_Average(array, mean);
            double numerator = 0;
            double count = 0;
            foreach (double item in array)
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
