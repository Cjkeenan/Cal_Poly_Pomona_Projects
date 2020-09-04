using System;

namespace Scheduling_Algorithms_2
{
    internal class Scheduling_Algorithms_2
    {
        private static int TIME_MAX = 100;
        private static int N = 3;

        private static void Main(string[] args)
        {
            int[] period = { 30, 40, 50 };
            int[] runTime = { 10, 15, 5 };
            int[] process_RMS = new int[TIME_MAX/5];    //Sequence of processes run
            int[] process_EDF = new int[TIME_MAX/5];    //

            PrintArray(period, "Periods");
            PrintArray(runTime, "Run Times");

            RMS(period, runTime, process_RMS);
            EDF(period, runTime, process_EDF);

            PrintArray(process_RMS, "RMS Sequence");
            PrintArray(process_EDF, "EDF Sequence");
        }

        private static void RMS(int[] period, int[] runTime, int[] process)
        {
            bool[] schedule = new bool[N];
            int timeEnd = 0, processRun = N;  //defaulted to no process is running.

            for (int time = 0; time < TIME_MAX; time = time + 5)
            {
                //1. determine the processes to be scheduled,
                for (int i = 0; i < N; i++)
                {
                    if (time % period[i] == 0)      //schedule which process can be run at a given time, i.e. given some amount of time passed, which if any of the processes could have run given their periods
                    {
                        schedule[i] = true;     //schedule that process
                    }
                }

                if (time < timeEnd)     //if current time is before when the previous process(es) ended
                {
                    process[time / 5] = processRun;
                }

                //2. schedule the process with the highest priority(i.e. highest rate)
                else
                {
                    processRun = N; //default to Idle process
                    for (int i = 0; i < N; i++)
                    {
                        if (schedule[i] == true)
                        {
                            processRun = i; break;
                        }
                    }

                    //3. run it until the end of its run time.
                    process[time / 5] = processRun;
                    if (processRun < N)     //if process is a valid process
                    {
                        timeEnd = time + runTime[processRun];    //run this process to its end
                        schedule[processRun] = false;   //reset the schedule for this process. Wait for next period.
                    }
                }
            }
        } //end of RMS function

        private static void EDF(int[] period, int[] runTime, int[] process)
        {
            bool[] schedule = new bool[N];
            int[] deadline = new int[N];
            int processRun = 0;
            int timeEnd = 0;

            //initialize all first deadlines with the value of the period
            for (int i = 0; i < N; i++)
            {
                deadline[i] = period[i];
            }

            for (int time = 0; time < TIME_MAX; time = time + 5)
            {
                //1. determine the processes to be scheduled,
                for (int i = 0; i < N; i++)
                {
                    if (time % period[i] == 0)      //if the period of a given process can be completed within the current time, schedule it
                    {
                        schedule[i] = true;
                    }
                }

                //2. schedule the process with the highest priority(i.e. earliest deadline)
                if (time < timeEnd)
                {
                    process[time / 5] = processRun;  // continue to run the scheduled process
                }
                else
                {
                    processRun = FindMin(3, deadline, schedule); //findMin() returns the index of the minimum

                    //3. run it.
                    process[time / 5] = processRun;
                    if (processRun < N)
                    {
                        timeEnd = time + runTime[processRun];
                        schedule[processRun] = false;
                        deadline[processRun] = deadline[processRun] + period[processRun];
                    }//set next deadline
                }
            }
        } //end of EDF function

        private static int FindMin(int n, int[] a, bool[] s)
        {
            int minimum = 1000;
            int iMin = N;   //default to no process
            for (int i = 0; i < n; i++)
            {
                if (minimum > a[i] && s[i] == true)
                {
                    minimum = a[i]; iMin = i;
                }
            }
            return iMin;
        }

        private static void PrintArray(int[] a, string name)
        {
            Console.Write("{0}: ", name);
            foreach (int i in a)
            {
                Console.Write("{0} ", i);
            }
            Console.Write("\n\n");
        }
    }
}