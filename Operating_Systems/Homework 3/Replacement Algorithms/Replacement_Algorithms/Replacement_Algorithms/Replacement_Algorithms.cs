using System;

namespace Replacement_Algorithms
{
    internal class Replacement_Algorithms
    {
        private static void Main(string[] args)
        {
            int maxFrames = 7;
            int numAlgos = 3;
            int[] pageReference = new int[] { 1, 2, 3, 4, 2, 1, 5, 6, 2, 1, 2, 3, 7, 6, 3, 2, 1, 2, 3, 6 };
            int n = pageReference.Length;
            int[,] pageFault = new int[numAlgos, maxFrames + 1];

            for (int frame = 1; frame <= maxFrames; frame++)
            {
                pageFault[0, frame] = FIFO(n, pageReference, frame);
                pageFault[1, frame] = LRU(n, pageReference, frame);
                pageFault[2, frame] = Optimal(n, pageReference, frame);
            }

            Console.WriteLine("Page Reference Order:");
            foreach (int i in pageReference)
            {
                Console.Write("{0} ", i);
            }

            for (int row = 0; row < numAlgos; row++)
            {
                switch (row)
                {
                    case 0:
                        Console.WriteLine("\n\nFiFo Page Faults:");
                        break;

                    case 1:
                        Console.WriteLine("\nLRU Page Faults:");
                        break;

                    case 2:
                        Console.WriteLine("\nOptimal Page Faults:");
                        break;

                    default:
                        Console.WriteLine("You should not be here!");
                        break;
                }

                for (int col = 1; col <= maxFrames; col++)
                {
                    Console.WriteLine("{1} frames: {0}", pageFault[row, col], col);
                }
            }
        }

        private static int FIFO(int n, int[] pageRef, int frame)
        {
            int pageFault = 0;
            int writePtr = 0;

            //1.make a page table (integer array)
            int[] pageTable = new int[frame];

            //2.Read from each page reference and compare to the current table
            for (int i = 0; i < n; i++)
            {
                //3.If miss you inc and switch according to FIFO
                if (!IsInPageTable(pageRef[i], pageTable, frame))
                {
                    pageFault++;
                    pageTable[writePtr++ % frame] = pageRef[i];
                }
            }

            return pageFault;
        }

        private static int LRU(int n, int[] pageRef, int frame)
        {
            int pageFault = 0;
            int maxIndex = 0;
            int[] operationsSinceUse = new int[frame];

            //1.make a page table (integer array)
            int[] pageTable = new int[frame];

            //2.Read from each page reference and compare to the current table
            for (int i = 0; i < n; i++)
            {
                if (i < frame)
                {
                    if (!IsInPageTable(pageRef[i], pageTable, frame))
                    {
                        pageFault++;
                        pageTable[i] = pageRef[i];
                        for (int j = 0; j < frame; j++)
                        {
                            if (pageTable[j] == pageRef[i]) operationsSinceUse[j] = 0;
                            else operationsSinceUse[j]++;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < frame; j++)
                        {
                            if (pageTable[j] == pageRef[i]) operationsSinceUse[j] = 0;
                            else operationsSinceUse[j]++;
                        }
                    }
                }
                //3.If miss you inc and switch according to LRU
                else if (!IsInPageTable(pageRef[i], pageTable, frame))
                {
                    pageFault++;

                    //Implement LRU here
                    maxIndex = Maximum(operationsSinceUse, frame);
                    pageTable[maxIndex] = pageRef[i];
                    for (int j = 0; j < frame; j++)
                    {
                        if (pageTable[j] == pageRef[i]) operationsSinceUse[j] = 0;
                        else operationsSinceUse[j]++;
                    }
                }
                else
                {
                    for (int j = 0; j < frame; j++)
                    {
                        if (pageTable[j] == pageRef[i]) operationsSinceUse[j] = 0;
                        else operationsSinceUse[j]++;
                    }
                }
            }
            return pageFault;
        }

        private static int Optimal(int n, int[] pageRef, int frame)
        {
            int pageFault = 0;
            int offset = 0;
            int[] futureReference = new int[frame];

            //1.make a page table (integer array)
            int[] pageTable = new int[frame];

            //2.Read from each page reference and compare to the current table
            for (int i = 0; i < n; i++)
            {
                //if page is currently unfilled, fill it
                if (i < (frame + offset))
                {
                    //if the page reference isnt in the table
                    if (!IsInPageTable(pageRef[i], pageTable, frame))
                    {
                        pageFault++;
                        pageTable[i - offset] = pageRef[i]; //put it in the table
                    }
                    //currently is in the table
                    else
                    {
                        offset++;   //offset to account for unfilled space
                    }
                }

                //3.If miss you inc and switch according to optimal
                else if (!IsInPageTable(pageRef[i], pageTable, frame))
                {
                    //calculate future reference array
                    futureReference = GenerateFutureReferences(pageRef, pageTable, i);
                    pageFault++;
                    pageTable[Maximum(futureReference, frame)] = pageRef[i];
                }
            }

            return pageFault;
        }

        private static bool IsInPageTable(int pageRef, int[] pageTable, int frame)
        {
            for (int i = 0; i < frame; i++)
            {
                if (pageTable[i] == pageRef)
                {
                    return true;
                }
            }
            return false;
        }

        private static int Maximum(int[] a, int n)
        {
            int max = 0;

            for (int i = 0; i < n; i++)
            {
                if (a[i] > a[max]) max = i;
            }
            return max;
        }

        private static int[] GenerateFutureReferences(int[] pageReference, int[] pageTable, int currentRefIndex)
        {
            int[] futureReference = new int[pageTable.Length];
            int nextRefIn = pageReference[currentRefIndex];     //for debugging purposes

            //for each value in the page table
            for (int i = 0; i < pageTable.Length; i++)
            {
                //look at all the values in the page reference starting from the current reference
                for (int j = currentRefIndex; j < pageReference.Length; j++)
                {
                    //if the page reference coming up is the same as the current page table value
                    if (pageReference[j] == pageTable[i])
                    {
                        //set the future reference of the same index as the page table as the distance from the current reference
                        futureReference[i] = j - currentRefIndex;
                        break;
                    }
                    else
                    {
                        //default value of number of total references + 1
                        futureReference[i] = pageReference.Length + 1;
                    }
                }
            }
            return futureReference;
        }
    }
}