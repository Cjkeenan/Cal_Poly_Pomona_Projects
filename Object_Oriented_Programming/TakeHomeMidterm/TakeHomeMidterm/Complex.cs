using System;

namespace TakeHomeMidterm
{
  public class Complex
  {
      //need to make each Complex method return a Complex object with answer as opposed to changing original values

      private double rP; // real part
      private double iP; // imaginary part

      public Complex () {
        rP = 0; iP = 0;
      }
      public Complex (double _rP, double _iP) {
        iP = _iP;
        rP = _rP;
      }

      public void SetComplex(double r, double i)
      {
          rP = r;
          iP = i;
      }

      public Complex negate()
      {
          return new Complex(-rP, -iP);
      }

      public Complex add(Complex c1)
      {
          return new Complex((rP + c1.rP), (iP + c1.iP));
      }

      public Complex subtract(Complex c1)
      {
          return new Complex((rP - c1.rP), (iP - c1.iP));
      }
      public Complex mul(Complex c1)
      {
          // use the formula (a+bj) * (c+dj) = (ac-bd) + (ad+bc)j
          return new Complex (
            rP * c1.rP - iP * c1.iP,
            rP * c1.iP + iP * c1.rP
          );
      }

      public Complex mulInt(int i)
      {
          return new Complex(i * rP, i * iP);
      }

      public Complex positiveSqrt()
      {
          Complex answer = new Complex();

          double r = (double)Math.Sqrt((rP * rP) + (iP * iP));
          double theta = (double)Math.Atan(iP / rP);

          answer.SetComplex((Math.Sqrt(r) * (Math.Cos(theta / 2))), (Math.Sqrt(r) * (Math.Sin(theta / 2))));

          return answer;

      }

      public Complex div(Complex c1)
      {
          Complex answer = new Complex();

          Complex conjugate = new Complex();
          conjugate.SetComplex(c1.rP, -(c1.iP));
          Complex numerator = new Complex();
          numerator.SetComplex(rP * conjugate.rP - iP * conjugate.iP,
              rP * conjugate.iP + iP * conjugate.rP);
          double denominator = (c1.rP * conjugate.rP) + (c1.rP * conjugate.iP) +
              (c1.iP * conjugate.rP) - (c1.iP * conjugate.iP);

          answer.SetComplex((numerator.rP / denominator), (numerator.iP / denominator));
          return answer;
        }
        public string output(bool spaceout = false)
        {
            string rPOut, iPOut;
            rPOut = Convert.ToString(rP);
            iPOut = Convert.ToString(iP);
            if (rP == 0)
            {
                if (Math.Abs(iP) == 1 && iP < 0)
                {
                    return (System.String.Format("-i"));
                }
                else
                {
                    return (System.String.Format("i"));
                }
            }
            else if (iP == 0)
            {
                return (System.String.Format("{0}", rPOut));
            }
            else if (iP < 0)
            {
                iPOut = Convert.ToString(iP * -1);
                return (System.String.Format(spaceout ? "{0} - {1} i" : "{0}+{1}i", rPOut, iPOut));
            }
            else
            {
                return (System.String.Format(spaceout ? "{0} + {1} i" : "{0}+{1}i", rPOut, iPOut));
            }
        }

        public Complex pow(int p)
        {
            Complex retval  = new Complex(1, 0);
            for (int i = 0; i < p; i++) retval *= this;
            return retval;
        }

        public void copy(Complex c)
      {
          double rCopy = c.rP;
          double iCopy = c.iP;
          rP = rCopy;
          iP = iCopy;
      }

      public Complex clone() {
        return new Complex(rP, iP);
      }



      /* Fancy Operator magic below here */
      public static Complex operator+ (Complex a, Complex b) {
        return a.add(b);
      }
      public static Complex operator- (Complex a, Complex b) {
        return a.subtract(b);
      }
      public static Complex operator* (Complex a, Complex b) {
        return a.mul(b);
      }
      public static Complex operator* (Complex a, int b) {
        return a.mulInt(b);
      }
      public static Complex operator/ (Complex a, Complex b) {
        return a.div(b);
      }
      public static Complex operator- (Complex a) {
        return a.negate();
      }
      public static bool operator== (Complex a, Complex b) {
        return a.rP == b.rP && a.iP == b.iP;
      }
      public static bool operator!= (Complex a, Complex b) {
        return !(a==b);
      }
      public static bool operator== (Complex a, int b) {
        return a.rP - b < Double.Epsilon && a.iP < Double.Epsilon;
      }
      public static bool operator!= (Complex a, int b) {
        return !(a==b);
      }
  }
}
