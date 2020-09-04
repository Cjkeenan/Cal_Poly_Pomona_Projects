using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequential_Soduku_Validator
{
    class Validator
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

            bool valid_rows = checkDigits(puzzle,0,1,0,9);
            bool valid_columns = checkDigits(puzzle, 0, 9, 0, 1);
            bool valid_3x3 = checkDigits(puzzle, 0, 3, 0, 3);


            for (int row = 0; row < 9; row++) { valid_rows &= checkDigits(puzzle, row, row + 1, 0, 9); }
            for (int column = 0; column < 9; column++) { valid_columns &= checkDigits(puzzle, 0, 9, column, column + 1); }
            for (int r_box = 0; r_box < 7; r_box += 3)
            {
                for(int c_box = 0; c_box < 7; c_box += 3)
                {
                    valid_3x3 &= checkDigits(puzzle, r_box, r_box + 3, c_box, c_box + 3);
                }
            }

            Console.WriteLine("All rows valid: {0}.\n" +
                              "All columns are Valid: {1}.\n" +
                              "All 3x3 boxes are Valid: {2}.\n",
                              valid_rows, valid_columns, valid_3x3);
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
