using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinKeenanECE256Midterm
{
    public class Complex
    {
        private double rP; // real part
        private double iP; // imaginary part

        public void SetComplex(double r, double i)
        {
            rP = r;
            iP = i;
        }

        public void add(Complex c1)
        {
            rP += c1.rP;
            iP += c1.iP;
        }

        public void subtract(Complex c1)
        {
            rP -= c1.rP;
            iP -= c1.iP;
        }

        public void addTwo(Complex c1, Complex c2)
        {
            rP = c1.rP + c2.rP;
            iP = c1.iP + c2.iP;
        }

        public void mul(Complex c1)
        {
            // use the formula (a+bj) * (c+dj) = (ac-bd) + (ad+bc)j
            double tempA, tempB;
            tempA = rP * c1.rP - iP * c1.iP;
            tempB = rP * c1.iP + iP * c1.rP;
            rP = tempA;
            iP = tempB;
        }

        public void sqrt()
        {
            double r = (double)Math.Sqrt((rP * rP) + (iP * iP));
            double theta = (double)Math.Atan(iP / rP);

            rP = Math.Sqrt(r) * (Math.Cos(theta / 2));
            iP = Math.Sqrt(r) * (Math.Sin(theta / 2));
            Console.Write("The roots are ");
            print();
            
            rP = -1 * Math.Sqrt(r) * (Math.Cos(theta / 2));
            iP = -1 * Math.Sqrt(r) * (Math.Sin(theta / 2));
            print();
        }

        public void div(Complex c1)
        {
            Complex conjugate = new Complex();
            conjugate.SetComplex(c1.rP, -(c1.iP));
            Complex numerator = new Complex();
            numerator.SetComplex(rP * conjugate.rP - iP * conjugate.iP,
                rP * conjugate.iP + iP * conjugate.rP);
            double denominator = (c1.rP * conjugate.rP) + (c1.rP * conjugate.iP) +
                (c1.iP * conjugate.rP) - (c1.iP * conjugate.iP);
            rP = numerator.rP / denominator;
            iP = numerator.iP / denominator;
        }

        public void printPolar()
        {
            double r = (double)Math.Sqrt((rP * rP) + (iP * iP));
            double theta = (double)Math.Atan(iP / rP);
            Console.WriteLine("{0:0.###}e^({1} j)", r, theta);
        }
        public void print()
        {
            string rPOut, iPOut;
            if (Math.Abs(rP) >= 1000 || Math.Abs(rP) <= 0.001)
            {
                rPOut = String.Format("({0:#.###E+00})", rP);
            }
            else
            {
                rPOut = Convert.ToString(rP);
            }
            if (Math.Abs(iP) >= 1000 || Math.Abs(iP) <= 0.001)
            {
                iPOut = String.Format("({0:#.###E+00})", iP);
            }
            else
            {
                iPOut = Convert.ToString(iP);
            }
            Console.WriteLine("{0} + {1}j", rPOut, iPOut);
        }

        public void copy(Complex c)
        {
            double rCopy = c.rP;
            double iCopy = c.iP;
            rP = rCopy;
            iP = iCopy;
        }
    }
    class Problem_3
    {
        public void Run()
        {
            Complex c1 = new Complex();
            c1.SetComplex(0, 1);
            c1.sqrt();
        }
    }
}
