using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1
{
    class Run_Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle(0, 0, 1);
            Circle cIntersect = new Circle(1, 0, 1);
            Circle cInsideTangent = new Circle(0.5, 0, 0.5);
            Circle cOutsideTangent = new Circle(2, 0, 1);
            Circle cDisjoint = new Circle(14, 17, 1);
            Point pIn = new Point();
            Point pOn = new Point();
            Point pOut = new Point();
            pIn.setPoint(0, 0);
            pOn.setPoint(0, 1);
            pOut.setPoint(0, 2);

            //Point in Circle Check
            pIn.print();
            Console.Write(", ");
            c1.print();
            Console.WriteLine();
            if (c1.inCircle(pIn))
            {
                pIn.print();
                Console.Write(" in ");
                c1.print();
                Console.WriteLine("\n");
            }
            else
                Console.WriteLine("Point NOT in circle");

            //Point On Circle Check
            pOn.print();
            Console.Write(", ");
            c1.print();
            Console.WriteLine();
            if (c1.onCircle(pOn))
            {
                pOn.print();
                Console.Write(" on ");
                c1.print();
                Console.WriteLine("\n");
            }
            else
                Console.WriteLine("Point NOT on circle");

            //Point Out of Circle Check
            pOut.print();
            Console.Write(", ");
            c1.print();
            Console.WriteLine();
            if (c1.outOfCircle(pOut))
            {
                pOut.print();
                Console.Write(" out of ");
                c1.print();
                Console.WriteLine("\n");
            }
            else
                Console.WriteLine("Point NOT out of circle");

            //Circle Intersect Check
            cIntersect.print();
            Console.Write(", ");
            c1.print();
            Console.WriteLine();
            if (c1.intersect(cIntersect))
            {
                c1.print();
                Console.Write(" intersects ");
                cIntersect.print();
                Console.WriteLine("\n");
            }
            else

                Console.WriteLine("Two circles do NOT intersect");

            //Circle Inside Tangent Check
            cInsideTangent.print();
            Console.Write(", ");
            c1.print();
            Console.WriteLine();
            if (c1.insideTangent(cInsideTangent))
            {
                c1.print();
                Console.Write(" is tangent on the inside of ");
                cInsideTangent.print();
                Console.WriteLine("\n");
            }
            else

                Console.WriteLine("Two circles are NOT tangent on the inside");

            //Circle Outside Tangent Check
            cOutsideTangent.print();
            Console.Write(", ");
            c1.print();
            Console.WriteLine();
            if (c1.outsideTangent(cOutsideTangent))
            {
                c1.print();
                Console.Write(" is tangent on the outside of ");
                cOutsideTangent.print();
                Console.WriteLine("\n");
            }
            else

                Console.WriteLine("Two circles are NOT tangent on the outside");

            //Circle Disjoint Check
            cDisjoint.print();
            Console.Write(", ");
            c1.print();
            Console.WriteLine();
            if (c1.disjoint(cDisjoint))
            {
                c1.print();
                Console.Write(" is disjoint of ");
                cDisjoint.print();
                Console.WriteLine("\n");
            }
            else

                Console.WriteLine("Two circles are NOT disjoint");
        }
    }
}
