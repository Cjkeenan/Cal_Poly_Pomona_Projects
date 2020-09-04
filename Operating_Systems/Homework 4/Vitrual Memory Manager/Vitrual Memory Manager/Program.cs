using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Memory_Manager
{
    public class Globals
    {
        public static int   MAX_VALUE = 65534,
                            ADDRESS_MASK = 0xFFFF,
                            PAGE_MASK = 0xFF00,
                            OFFSET_MASK = 0x00FF,
                            TLB_SIZE = 16,
                            FRAME_SIZE = 256,
                            PT_SIZE = 256,
                            TOTAL_FRAMES = 256;

        public static int[] pageTableNumbers = new int[PT_SIZE];  // array to hold the page numbers in the page table
        public static int[] pageTableFrames = new int[PT_SIZE];   // array to hold the frame numbers in the page table

        public static int[] TLBPageNumber = new int[TLB_SIZE];  // array to hold the page numbers in the TLB
        public static int[] TLBFrameNumber = new int[TLB_SIZE]; // array to hold the frame numbers in the TLB

        public static int[,] physicalMemory = new int[TOTAL_FRAMES, FRAME_SIZE]; // physical memory 2D array

        public static int pageFaults = 0;                     // counter to track page faults
        public static int TLBHits = 0;                        // counter to track TLB hits
        public static int firstAvailableFrame = 0;            // counter to track the first available frame
        public static int firstAvailablePageTableNumber = 0;  // counter to track the first available page table entry
        public static int numberOfTLBEntries = 0;             // counter to track the number of entries in the TLB
        public static int numberOfPTEntries = 0;              // counter to track the number of entries in the Page Table
    }
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            int numAddresses = (int)Math.Pow(2,20);
            int[] address = new int[numAddresses];
            for(int i = 0; i < numAddresses; i++)
            {
                address[i] = random.Next(Globals.MAX_VALUE);
            }

            int[] logicalAddress = new int[numAddresses];
            for(int i = 0; i < numAddresses; i++)
            {
                logicalAddress[i] = address[i] & Globals.ADDRESS_MASK;
            }

            int[] pageNumber = new int[numAddresses];
            for(int i = 0; i < numAddresses; i++)
            {
                pageNumber[i] = (logicalAddress[i] & Globals.PAGE_MASK) >> 8;
            }

            int[] offset = new int[numAddresses];
            for(int i = 0; i < numAddresses; i++)
            {
                offset[i] = logicalAddress[i] & Globals.OFFSET_MASK;
            }

            foreach(int i in pageNumber) { FindPage(i); }   //populate page table

            //for (int i = 0; i < numAddresses; i++)
            //{
            //    Console.Write("Logical Address: {0}\t\t", logicalAddress[i]);
            //    Console.Write("Page: {0}\t\t", pageNumber[i]);
            //    Console.Write("Frame: {0}\t\t", FindPage(pageNumber[i]));
            //    Console.Write("Offset: {0}\n", offset[i]);
            //}

            Console.WriteLine("Number of Addresses Called: {0}", numAddresses);
            Console.WriteLine("Max Value per Address: {0}", Globals.MAX_VALUE);
            Console.WriteLine("Page faults: {0}", Globals.pageFaults);
            Console.WriteLine("TLB Hits: {0}", Globals.TLBHits);

            Console.WriteLine("\n\nTLB Pages:");
            foreach (int i in Globals.TLBPageNumber) { Console.Write("{0} ", i); }

            Console.WriteLine("\n\nTLB Frames:");
            foreach (int i in Globals.TLBFrameNumber) { Console.Write("{0} ", i); }

            Console.WriteLine("\n\nPage Table Pages:");
            foreach (int i in Globals.pageTableNumbers) { Console.Write("{0} ", i); }

            Console.WriteLine("\n\nPage Table Frames:");
            foreach (int i in Globals.pageTableFrames) { Console.Write("{0} ", i); }


            //Console.WriteLine("Addresses:");
            //foreach(int i in address) { Console.Write(" {0} ", i); }

            //Console.WriteLine("\nLogical Addresses:");
            //foreach (int i in logicalAddress) { Console.Write(" {0} ", i); }

            //Console.WriteLine("\nPage Numbers:");
            //foreach (int i in pageNumber) { Console.Write(" {0} ", i); }

            //Console.WriteLine("\nOffsets:");
            //foreach (int i in offset) { Console.Write(" {0} ", i); }
        }

        // Obtain the physical address and value stored at that address from a logical address
        static int FindPage(int pageNumber)
        {

            // first try to get page from TLB
            int frameNumber = -1;

            // look through TLB for a match
            for (int i = 0; i < Globals.TLB_SIZE; i++)
            {
                // if the TLB index is equal to the page number
                if (Globals.TLBPageNumber[i] == pageNumber)
                {   
                    frameNumber = Globals.TLBFrameNumber[i];    // then the frame number is extracted
                    Globals.TLBHits++;                          // and the TLBHit counter is incremented
                }
            }

            // if the frameNumber was not found in TLB
            if (frameNumber == -1)
            {
                // Look through page table
                for (int i = 0; i < Globals.numberOfPTEntries; i++)
                {
                    // if the page is found in those contents
                    if (Globals.pageTableNumbers[i] == pageNumber)
                    {         
                        frameNumber = Globals.pageTableFrames[i];          // get the frame number associated with that page number in the table
                    }
                }
                // if the page is not found in those contents
                if (frameNumber == -1)
                {                     
                    AddToPageTable(pageNumber);             // page fault, call to readFromStore to get the frame into physical memory and the page table
                    Globals.pageFaults++;                          // increment the number of page faults
                }
            }

            AddToTLB(pageNumber, frameNumber);  // Insert the page number and frame number into the TLB

            return frameNumber;
        }

        static void AddToPageTable(int pageNumber)
        {
            bool alreadyIn = true;
            //look through the Page Table
            for (int i = 0; i <= Globals.numberOfPTEntries; i++)
            {
                alreadyIn = false;
                // if it's already in the Page Table, break
                if (Globals.pageTableNumbers[i] == pageNumber)
                {
                    alreadyIn = true;
                    break;
                }

                // if the number of entries is less than the size of the Page Table, i.e. there is room left
                if (Globals.numberOfPTEntries < Globals.PT_SIZE)
                {
                    Globals.pageTableNumbers[Globals.numberOfPTEntries] = pageNumber;     // insert the page and frame on the end
                    Globals.pageTableFrames[Globals.numberOfPTEntries] = Globals.firstAvailableFrame;   //
                    Globals.firstAvailableFrame++;
                    break;
                }

                // otherwise move everything over
                else
                {
                    for (i = 0; i < Globals.TLB_SIZE - 1; i++)
                    {
                        Globals.pageTableNumbers[i] = Globals.pageTableNumbers[i + 1];
                        Globals.pageTableFrames[i] = Globals.pageTableFrames[i + 1];
                    }
                    Globals.pageTableNumbers[Globals.numberOfPTEntries - 1] = pageNumber;  // and insert the page and frame on the end
                    Globals.pageTableFrames[Globals.numberOfPTEntries - 1] = Globals.firstAvailableFrame;
                    Globals.firstAvailableFrame++;
                }
            }

            // if there is still room in the arrays
            if ((Globals.numberOfPTEntries < Globals.PT_SIZE) && !alreadyIn)
            {
                Globals.numberOfPTEntries++;   //increment the number of entries currently in Page Table
            }
        }

        static void AddToTLB(int pageNumber, int frameNumber)
        {
            bool alreadyIn = false;
            //look through the TLB
            for (int i = 0; i < Globals.numberOfTLBEntries; i++)
            {
                alreadyIn = false;
                // if it's already in the TLB, break
                if (Globals.TLBPageNumber[i] == pageNumber)
                {
                    alreadyIn = true;
                    break;
                }

                // if the number of entries is less than the size of the TLB, i.e. there is room left
                if (Globals.numberOfTLBEntries < Globals.TLB_SIZE)
                {
                    Globals.TLBPageNumber[Globals.numberOfTLBEntries] = pageNumber;     // insert the page and frame on the end
                    Globals.TLBFrameNumber[Globals.numberOfTLBEntries] = frameNumber;   //
                    break;
                }

                // otherwise move everything over
                else
                {
                    for (i = 0; i < Globals.TLB_SIZE - 1; i++)
                    {
                        Globals.TLBPageNumber[i] = Globals.TLBPageNumber[i + 1];
                        Globals.TLBFrameNumber[i] = Globals.TLBFrameNumber[i + 1];
                    }
                    Globals.TLBPageNumber[Globals.numberOfTLBEntries - 1] = pageNumber;  // and insert the page and frame on the end
                    Globals.TLBFrameNumber[Globals.numberOfTLBEntries - 1] = frameNumber;
                }
            }

            // if there is still room in the arrays
            if ((Globals.numberOfTLBEntries < Globals.TLB_SIZE) && !alreadyIn)
            {
                Globals.numberOfTLBEntries++;   //increment the number of entries currently in TLB
            }
        }
    }
}
