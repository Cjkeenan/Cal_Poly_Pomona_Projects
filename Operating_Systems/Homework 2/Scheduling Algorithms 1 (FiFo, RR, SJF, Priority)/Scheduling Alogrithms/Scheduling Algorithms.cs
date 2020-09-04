using System;

namespace Scheduling_Alogrithms
{
    internal class Scheduling_Algorithms
    {
        private static void Main(string[] args)
        {
            int n = 3;
            int timeQuantum = 4;
            int[] arrival_time = new int[] { 0, 1, 2 };
            int[] run_time = new int[] { 24, 3, 3 };
            int[] priority = new int[] { 3, 1, 4 };
            double FiFo_Avg, ShortestJob_Avg, RoundRobin_Avg, Priority_Avg;

            PrintArray(arrival_time, "Arrival Times");
            PrintArray(run_time, "Run Times");
            PrintArray(priority, "Priorities");

            FiFo_Avg = FiFo(n, arrival_time, run_time, priority, timeQuantum);
            ShortestJob_Avg = Shortest_Job(n, arrival_time, run_time, priority, timeQuantum);
            Priority_Avg = Priority(n, arrival_time, run_time, priority, timeQuantum);
            RoundRobin_Avg = Round_Robin(n, arrival_time, run_time, priority, timeQuantum);

            Console.WriteLine("FiFo Average Waiting Time: {0:f}", FiFo_Avg);
            Console.WriteLine("Shortest Job Average Waiting Time: {0:f}", ShortestJob_Avg);
            Console.WriteLine("Priority Average Waiting Time: {0:f}", Priority_Avg);
            Console.WriteLine("Round Robin Average Waiting Time: {0:f}", RoundRobin_Avg);
        }

        private static double FiFo(int n, int[] arrival_time, int[] run_time, int[] priority, int timeQuantum)
        {
            double avg_time = 0;
            int[] waiting_time = new int[n];
            int[] turnaround_time = new int[n];
            int[] prev_run_time = new int[n];

            //Calculate Waiting Time
            waiting_time[0] = 0;                    //waiting time for the first process is always 0
            prev_run_time[0] = 0;                   //no processes run before the first process
            for (int i = 1; i < n; i++)
            {
                prev_run_time[i] = prev_run_time[i - 1] + run_time[i - 1];  //Calculate the previously run programs for each program

                waiting_time[i] = prev_run_time[i] - arrival_time[i];       //waiting time for a given program is the run time of previous programs minus its arrival time

                if (waiting_time[i] < 0) waiting_time[i] = 0;               //if the waiting time is less than 0, that means when it arrived nothing was currently running, so it ran immediately
            }

            //Calculate Turnaround Time
            for (int i = 0; i < n; i++)
            {
                turnaround_time[i] = waiting_time[i] + run_time[i];     //time to finish a given process is how long it takes to start plus how long a process runs for
            }

            //Calculate Average Waiting Time
            for (int i = 0; i < n; i++)
            {
                avg_time += waiting_time[i];           //total waiting time for processes
            }
            avg_time /= n;                      //average waiting time is total waiting time of all processes divided by number of processes

            return avg_time;
        }

        private static double Shortest_Job(int n, int[] arrival_time, int[] run_time, int[] priority, int timeQuantum)
        {
            //Bubble sort with respect to run_time
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (run_time[j] > run_time[j + 1])
                    {
                        int temp = priority[j];
                        priority[j] = priority[j + 1];
                        priority[j + 1] = temp;

                        temp = arrival_time[j];
                        arrival_time[j] = arrival_time[j + 1];
                        arrival_time[j + 1] = temp;

                        temp = run_time[j];
                        run_time[j] = run_time[j + 1];
                        run_time[j + 1] = temp;
                    }
                }
            }

            //then FiFo when sorted with respect to run time
            return FiFo(n, arrival_time, run_time, priority, timeQuantum);
        }

        private static double Round_Robin(int n, int[] arrival_time, int[] run_time, int[] priority, int timeQuantum)
        {
            double avg_time = 0;
            int current_time = 0;
            int[] waiting_time = new int[n];
            int[] turnaround_time = new int[n];
            int[] remaining_runtime = run_time;
            int[] remaining_arrivals = arrival_time;

            //Calculate Waiting time for a given process
            while (true)
            {
                bool done = true;

                for (int i = 0; i < n; i++)
                {
                    if (remaining_runtime[i] <= timeQuantum)   //if the given process can be completed in one time quantum
                    {
                        done = false;               //work still needs to be done

                        if (remaining_runtime[i] > timeQuantum)     //if the current process needs more time than the time quantum
                        {
                            current_time += timeQuantum;            //increment current time by runtime process
                            remaining_runtime[i] -= timeQuantum;   //decrease runtime of a given process by the time quantum
                            remaining_arrivals[i] += timeQuantum;
                        }
                        else
                        {
                            current_time += remaining_runtime[i];      //current time incremented by how long a given process needs to run for
                            waiting_time[i] = current_time - run_time[i] - arrival_time[i];   //waiting time for a given process is the current time minus how much it uses, i.e. time to start
                            remaining_runtime[i] = 0;      //set finished process as 0 more needed run time
                        }
                    }
                    else
                    {
                        for (int j = 0; j < n; j++)      //comparing each process to each other to find the one that arrived first given that the process is longer than the time quantum
                        {
                            if (arrival_time[j] < arrival_time[i])   //process j arrived first
                            {
                                done = false;

                                //executing on the j-th process
                                if (remaining_runtime[j] > timeQuantum)
                                {
                                    current_time += timeQuantum;
                                    remaining_runtime[j] -= timeQuantum;
                                    arrival_time[j] += timeQuantum;
                                }
                                else
                                {
                                    current_time += run_time[j];
                                    waiting_time[j] = current_time - run_time[j] - arrival_time[j];
                                    remaining_runtime[j] = 0;
                                }
                            }
                            else    //process i arrived first
                            {
                                done = false;

                                //executing on the i-th process
                                if (remaining_runtime[i] > timeQuantum)
                                {
                                    current_time += timeQuantum;
                                    remaining_runtime[i] -= timeQuantum;
                                    arrival_time[i] += timeQuantum;
                                }
                                else
                                {
                                    current_time += run_time[i];
                                    waiting_time[i] = current_time - run_time[i] - arrival_time[i];
                                    remaining_runtime[j] = 0;
                                }
                            }
                        }
                    }
                }
                done = true;

                if (done) break;
            }

            //Calculate Turnaround time for a given process
            for (int i = 0; i < n; i++)
            {
                turnaround_time[i] = waiting_time[i] + run_time[i];     //time to finish a given process is how long it takes to start plus how long a process runs for
            }

            //Calculate Average Waiting time
            for (int i = 0; i < n; i++)
            {
                avg_time += waiting_time[i];           //total waiting time for processes
            }
            avg_time /= n;                      //average waiting time is total waiting time of all processes divided by number of processes

            return avg_time;
        }

        private static double Priority(int n, int[] arrival_time, int[] run_time, int[] priority, int timeQuantum)
        {
            //Bubble sort with respect to priority
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (priority[j] > priority[j + 1])
                    {
                        //Swap all data associated with j and j+1
                        int temp = priority[j];
                        priority[j] = priority[j + 1];
                        priority[j + 1] = temp;

                        temp = arrival_time[j];
                        arrival_time[j] = arrival_time[j + 1];
                        arrival_time[j + 1] = temp;

                        temp = run_time[j];
                        run_time[j] = run_time[j + 1];
                        run_time[j + 1] = temp;
                    }
                }
            }

            //then FiFo when sorted with respect to priority
            return FiFo(n, arrival_time, run_time, priority, timeQuantum);
        }

        private static void PrintArray(int [] a, string name)
        {
            Console.Write("{0}: ", name);
            foreach(int i in a)
            {
                Console.Write("{0} ", i);
            }
            Console.Write("\n\n");
        }
    }
}