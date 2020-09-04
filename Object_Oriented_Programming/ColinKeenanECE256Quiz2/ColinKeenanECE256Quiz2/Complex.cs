using System; // namespace containing ArgumentOutOfRangeException

public class Complex
{
    private double rP; // real part
    private double iP; // imaginary part

    public void SetComplex(double r, double i)
    {
        rP = r;
        iP = i;
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
    public void mulWrong(Complex c1)
    {
        // use the formula (a+bj) * (c+dj) = (ac-bd) + (ad+bc)j
        rP = (rP * c1.rP - iP * c1.iP);     //wrong beceause it redefines rP, and the uses that new rP in iP's calculations
        iP = (rP * c1.iP + iP * c1.rP);
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
        if (denominator == 0)
        {
            Console.WriteLine("Sorry, it appears you are trying to divide by zero.");
        }
        else
        {
            rP = numerator.rP / denominator;
            iP = numerator.iP / denominator;
        }
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
        rPOut = Convert.ToString(rP);
        iPOut = Convert.ToString(iP);
        if (rP == 0)
        {
            if (Math.Abs(iP) == 1 && iP < 0)
            {
                Console.WriteLine("-j");
            }
            else if (Math.Abs(iP) == 1 && iP > 0)
            {
                Console.WriteLine("j");
            }
        }
        else if (iP == 0)
        {
            Console.WriteLine("{0}", rPOut);
        }
        else if (iP < 0)
        {
            iPOut = Convert.ToString(iP * -1);
            Console.WriteLine("{0} - {1}j", rPOut, iPOut);
        }
        else
        {
            Console.WriteLine("{0} + {1}j", rPOut, iPOut);
        }
    }

    public void copy(Complex c)
    {
        double rCopy = c.rP;
        double iCopy = c.iP;
        rP = rCopy;
        iP = iCopy;
    }
}