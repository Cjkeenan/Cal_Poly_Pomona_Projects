using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinKeenanECE256Exercise2
{
    public class Point
    {
        private double x; // x coordiate of Point
        private double y; // y coordinate of Point

        public void SetPoint(double xCoor, double yCoor)
        {
            x = xCoor;
            y = yCoor;
        }

        public double Dist(Point p)  // compute the distance of point p to the current point
        {
            double distance;
            distance = Math.Sqrt((x - p.x) * (x - p.x) + (y - p.y) * (y - p.y));
            return distance;
        }
        public void Print()
        {
            Console.Write("Point: ({0}, {1})", x, y);
        }
    }
    public class Problem_2
    {
        public void Run()
        {
            Point A = new Point();
            Point B = new Point();
            Point C = new Point();
            int x, y;
            double sideAB, sideAC, sideBC, angleA, angleB, angleC;

            Console.Write("Please enter the x-coordinate of point A: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the y-coordinate of point A: ");
            y = Convert.ToInt32(Console.ReadLine());
            A.SetPoint(x, y);

            Console.Write("Please enter the x-coordinate of point B: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the y-coordinate of point B: ");
            y = Convert.ToInt32(Console.ReadLine());
            B.SetPoint(x, y);

            Console.Write("Please enter the x-coordinate of point C: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the y-coordinate of point C: ");
            y = Convert.ToInt32(Console.ReadLine());
            C.SetPoint(x, y);
            Console.WriteLine("");

            //Calculate distance of each side
            sideAB = A.Dist(B);
            sideAC = A.Dist(C);
            sideBC = B.Dist(C);

            //Calculate each angle
            angleA = (180 / Math.PI) * Math.Acos(((sideAB * sideAB) + (sideAC * sideAC) - (sideBC * sideBC)) / (2 * sideAB * sideAC));
            angleB = (180 / Math.PI) * Math.Acos(((sideAB * sideAB) + (sideBC * sideBC) - (sideAC * sideAC)) / (2 * sideAB * sideBC));
            angleC = (180 / Math.PI) * Math.Acos(((sideBC * sideBC) + (sideAC * sideAC) - (sideAB * sideAB)) / (2 * sideBC * sideAC));

            //Check if Triangle
            if ((sideAB + sideAC > sideBC) && (sideAB + sideBC > sideAC) && (sideBC + sideAC > sideAB))
            {
                Console.WriteLine("Entered points creates a triangle with side lengths: {0}, {1}, {2},\nand angles: {3:F2}, {4:F2}, {5:F2}.",
                               sideAB, sideAC, sideBC, angleA, angleB, angleC);
            }
            else
            {
                Console.WriteLine("Sorry, your points do not create a triangle.\n");
            }
        }
    }
}
