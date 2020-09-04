using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinKeenanECE256Exercise2
{
    // Fig. 5.6: GradeBook.cs
    // GradeBook class that solves class-average problem using 
    // counter-controlled repetition.
    using System;

    public class GradeBook
    {
        // auto-implemented property CourseName
        public string CourseName { get; set; }

        // constructor initializes CourseName property
        public GradeBook(string name)
        {
            CourseName = name; // set CourseName to name
        } // end constructor

        // display a welcome message to the GradeBook user
        public void DisplayMessage()
        {
            // property CourseName gets the name of the course
            Console.WriteLine("Welcome to the grade book for\n{0}!\n",
               CourseName);
        } // end method DisplayMessage

        // determine class average based on 10 grades entered by user
        public void DetermineClassAverage()
        {
            int total; // sum of the grades entered by user
            int gradeCounter; // number of the grade to be entered next
            int grade; // grade value entered by the user
            double average; // average of the grades

            // initialization phase
            total = 0; // initialize the total
            gradeCounter = 0; // initialize the loop counter

            // processing phase
            do
            {
                Console.Write("Enter grade or (-1) once you are done: "); // prompt the user
                grade = Convert.ToInt32(Console.ReadLine()); // read grade
                total += grade; // add the grade to total
                gradeCounter++; // increment the counter by 1
            }
            while (grade != -1);
            total++;            //adjust for -1 being added as a grade
            gradeCounter--;     //adjust for counter getting incremented with (-1)

            // termination phase
            average = Convert.ToDouble(total) / gradeCounter; // integer division yields integer result

            // display total and average of grades
            Console.WriteLine("\nTotal of all {0} grades is {1}", gradeCounter, total);
            Console.WriteLine("Class average is {0:F}%", average);
        } // end method DetermineClassAverage
    } // end class GradeBook

}
