using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MT_Soduku_Validator
{
    class MT_Validator
    {
        static void Main(string[] args)
        {
            int[,] puzzle = new int[9, 9] {{6, 2, 4, 5, 3, 9, 1, 8, 7 },
                                           {5, 1, 9, 7, 2, 8, 6, 3, 4 },
                                           {8, 3, 7, 6, 1, 4, 2, 9, 5 },
                                           {1, 4, 3, 8, 6, 5, 7, 2, 9 },
                                           {9, 5, 8, 2, 4, 7, 3, 6, 1 },
                                           {7, 6, 2, 3, 9, 1, 4, 5, 8 },
                                           {3, 7, 1, 9, 5, 6, 8, 4, 2 },
                                           {4, 9, 6, 1, 8, 2, 5, 7, 3 },
                                           {2, 8, 5, 4, 7, 3, 9, 1, 6 }};

            bool valid_rows = checkDigits(puzzle, 0, 1, 0, 9);
            bool valid_columns = checkDigits(puzzle, 0, 9, 0, 1);
            bool[] valid_3x3 = new bool[9];

            //Validator Threads setup
            int threads = 11;
            Thread[] validator_threads = new Thread[threads];

            //Rows
            validator_threads[0] = new Thread(() => valid_rows = Row_thread_call(puzzle, valid_rows));
            validator_threads[0].SetApartmentState(ApartmentState.MTA);
            validator_threads[0].Name = string.Format("Rows");
            validator_threads[0].Start();
            Console.WriteLine("Thread {0} started!", validator_threads[0].Name.ToString());

            //Columns
            validator_threads[1] = new Thread(() => valid_columns = Column_thread_call(puzzle, valid_columns));
            validator_threads[1].SetApartmentState(ApartmentState.MTA);
            validator_threads[1].Name = string.Format("Columns");
            validator_threads[1].Start();
            Console.WriteLine("Thread {0} started!", validator_threads[1].Name.ToString());

            //Boxes
            for (int i = 2; i < threads; i++)
            {
                int toPass = i;
                int boxNum = i - 2;
                validator_threads[toPass] = new Thread(() => valid_3x3[boxNum] = Box_thread_call(puzzle, valid_3x3[boxNum], boxNum));
                validator_threads[toPass].SetApartmentState(ApartmentState.MTA);
                validator_threads[toPass].Name = string.Format("Box {0}", boxNum);
                validator_threads[toPass].Start();
                Console.WriteLine("Thread {0} started!", validator_threads[toPass].Name.ToString());
            }

            //Join Sorting Threads
            for (int i = 0; i < threads; i++)
            {
                validator_threads[i].Join();
                Console.WriteLine("Thread {0} joined!", validator_threads[i].Name.ToString());
            }

            Console.WriteLine("All rows valid: {0}\n" +
                  "All columns are Valid: {1}",
                  valid_rows, valid_columns);
            int count = 0;
            foreach(bool value in valid_3x3)
            {
                count++;
                Console.WriteLine("Box {0} is valid: {1}", count, value);
            }
            
        }

        public static bool Box_thread_call(int[,] a, bool valid_3x3, int boxNum)
        {
            switch (boxNum)
            {
                case 0:
                    valid_3x3 = checkDigits(a, 0, 3, 0, 3);
                    break;

                case 1:
                    valid_3x3 = checkDigits(a, 0, 3, 3, 6);
                    break;

                case 2:
                    valid_3x3 = checkDigits(a, 0, 3, 6, 9);
                    break;

                case 3:
                    valid_3x3 = checkDigits(a, 3, 6, 0, 3);
                    break;

                case 4:
                    valid_3x3 = checkDigits(a, 3, 6, 3, 6);
                    break;

                case 5:
                    valid_3x3 = checkDigits(a, 3, 6, 6, 9);
                    break;

                case 6:
                    valid_3x3 = checkDigits(a, 6, 9, 0, 3);
                    break;

                case 7:
                    valid_3x3 = checkDigits(a, 6, 9, 3, 6);
                    break;

                case 8:
                    valid_3x3 = checkDigits(a, 6, 9, 6, 9);
                    break;

                default:
                    break;

            }
            return valid_3x3;
        }

        public static bool Row_thread_call(int[,] a, bool valid_rows)
        {
            for (int row = 0; row < 9; row++)
            {
                valid_rows &= checkDigits(a, row, row + 1, 0, 9);
            }
            return valid_rows;
        }

        public static bool Column_thread_call(int[,] a, bool valid_columns)
        {
            for (int row = 0; row < 9; row++)
            {
                valid_columns &= checkDigits(a, row, row + 1, 0, 9);
            }
            return valid_columns;
        }

        public static bool checkDigits(int[,] a, int rowStart, int rowEnd, int columnStart, int columnEnd)
        {//purpose: to check that a given Row, column or 
         //3*3 block contains 1 to 9.
            int[] count = new int[9];

            for (int row = rowStart; row < rowEnd; row++)
            {
                for (int column = columnStart; column < columnEnd; column++)
                {
                    count[a[row, column] - 1]++;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (count[i] != 1)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
