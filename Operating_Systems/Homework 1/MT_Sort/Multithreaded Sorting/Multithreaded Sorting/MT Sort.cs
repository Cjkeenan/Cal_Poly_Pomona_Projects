using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Multithreaded_Sorting
{
    class MT_Sort

    {
        static void Main(string[] args)
        {
            //Generate Random Array Values
            Random rnd = new Random();
            int size = 23;
            int[] numbers = new int[size];
            for (int i = 0; i < size; i++)
            {
                numbers[i] = rnd.Next(0, 4 * size);
            }
            Print_Array(numbers, size, false);

            //Sorting Threads setup
            int threads = 2;
            int working_size = size / threads;
            int[] from = new int[] { 0, working_size };
            int[] to = new int[] { working_size, 2 * working_size };

            Thread[] sorting_threads = new Thread[threads];
            for (int i = 0; i < threads; i++)
            {
                int toPass = i;
                sorting_threads[toPass] = new Thread(() => Sort(numbers, from[toPass], to[toPass]));
                sorting_threads[toPass].SetApartmentState(ApartmentState.MTA);
                sorting_threads[toPass].Name = string.Format("Sorting_Thread_{0}", toPass);
                sorting_threads[toPass].Start();
                Console.WriteLine("Thread {0} started!", toPass);
            }

            //Join Sorting Threads
            for (int i = 0; i < threads; i++)
            {
                sorting_threads[i].Join();
                Console.WriteLine("Thread {0} joined!", i);
            }

            //Merging Thread setup
            int[] sorted_numbers = new int[size];
            Thread merging_thread = new Thread(() => Sort(numbers, 0, size));
            merging_thread.Start();

            //Join Sorting Threads
            merging_thread.Join();

            //Print_Array(sorted_numbers, size, true);
            Print_Array(numbers, size, true);
        }
        public static void Sort(int[] array, int from, int to)
        {            
            //Sort Array (Bubble)
            for (int i = from; i < to; i++)
            {
                //Console.WriteLine("thread selected first value");
                for (int j = from; j < to - 1; j++)
                {
                    //Console.WriteLine("thread selected second value");
                    if (array[j] > array[j + 1])
                    {
                        //Console.WriteLine("thread swapping");
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            //Console.WriteLine("thread finished");
        }

        //not working
        public static void Merge(int[] a, int size, int[] b)
        {
            //Merge Arrays
            for (int i = 0; i < size; i++)
            {
                //Console.WriteLine("thread selected first value");
                for (int j = i; j < size - 1; j++)
                {
                    //Console.WriteLine("thread selected second value");
                    if (a[j] < a[j + 1])
                    {
                        b[i] = a[j];
                    }
                }
            }
            //Console.WriteLine("thread finished");        
        }

    public static void Print_Array(int[] array, int size, bool sorted)
        {
            if (sorted)
            {
                Console.Write("Sorted Array Values: {");
                for (int i = 0; i < size; i++)
                {
                    if (i == size - 1) Console.Write(array[i]);
                    else Console.Write("{0}, ", array[i]);
                }
                Console.Write("}\n");
            }
            else if (!sorted)
            {
                Console.Write("Unsorted Array Values: {");
                for (int i = 0; i < size; i++)
                {
                    if (i == size - 1) Console.Write(array[i]);
                    else Console.Write("{0}, ", array[i]);
                }
                Console.Write("}\n");
            }
            else
            {
                Console.WriteLine("ERROR");
            }
        }
    }
}
