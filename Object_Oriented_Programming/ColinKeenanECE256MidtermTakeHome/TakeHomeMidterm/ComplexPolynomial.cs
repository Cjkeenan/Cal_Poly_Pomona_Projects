using System;

namespace TakeHomeMidterm
{
  public class ComplexPolynomial
  {
      private Complex[] coefficients;
        private int degree;

      public ComplexPolynomial() {
        this.coefficients = new Complex[1];
        coefficients[0] = new Complex();
        this.degree = 0;
      }

      public ComplexPolynomial(int degree) {
        this.coefficients = new Complex[degree + 1];
        for(int i = 0; i <= degree; i++) this.coefficients[i] = new Complex();
        this.degree = degree;
      }

      public ComplexPolynomial(Complex[] coef, int deg) {
          coefficients = coef;
          degree = deg;
      }

      public void SetPolynomial(Complex[] coef, int deg)
      {
          coefficients = coef;
          degree = deg;
      }

      public ComplexPolynomial CalculateAddition(ComplexPolynomial p1)
      {
          int higherDegree = (this.degree > p1.degree ? this.degree : p1.degree);
          ComplexPolynomial result = new ComplexPolynomial(higherDegree);
          Complex zero = new Complex();
          for (int i = 0; i <= higherDegree; i++)
          {
              if (i <= degree && i <= p1.degree)
                  result.coefficients[i] = coefficients[i].add(p1.coefficients[i]);
              else if (i <= degree)
                  result.coefficients[i] = coefficients[i];
              else
                  result.coefficients[i] = p1.coefficients[i];
              if (result.coefficients[i] != zero)
                  result.degree = i;
          }
            //while (result.coefficients[degree] == 0 && result.degree > 0) result.degree--;
          return result;

      }

      public ComplexPolynomial CalculateSubtraction(ComplexPolynomial p1) {
        ComplexPolynomial p1_n = new ComplexPolynomial();
        p1_n.degree = p1.degree;
        p1_n.coefficients = new Complex[p1_n.degree + 1];
        for (int i = 0; i <= p1_n.degree; i++) p1_n.coefficients[i] = p1.coefficients[i].negate();
          return CalculateAddition(p1_n);
      }

      //works now - Ryan :)
      public ComplexPolynomial CalculateProduct(ComplexPolynomial p1)
      {
          ComplexPolynomial product = new ComplexPolynomial(degree + p1.degree);
          for (int c2 = p1.degree; c2 >= 0; c2--)
          {
              for (int c1 = degree; c1 >= 0; c1--)
              {
                product.coefficients[c1 + c2] += coefficients[c1] * p1.coefficients[c2];
              }
          }
          return product;
      }

      //wip
      public ComplexPolynomial CalculateQuotient(ComplexPolynomial p1)
      {
          ComplexPolynomial quotient = new ComplexPolynomial(this.degree - p1.degree);
          ComplexPolynomial remainder = this.clone();
            for (int c = this.degree; c >= p1.degree; c--) {

            ComplexPolynomial mult = new ComplexPolynomial(c - p1.degree);
                mult.coefficients[mult.degree] = remainder.coefficients[c] / p1.coefficients[p1.degree];
                quotient += mult;
                remainder -= mult * p1;
            }
            return quotient;
      }

      //wip
      public ComplexPolynomial CalculateRemainder(ComplexPolynomial p1)
      {
          // Code coppied from Calculate Quotient
          ComplexPolynomial quotient = new ComplexPolynomial(this.degree - p1.degree);
          ComplexPolynomial remainder = this.clone();
          for(int c = this.degree; c >= p1.degree; c--) {
            ComplexPolynomial mult = new ComplexPolynomial(c - p1.degree);
            mult.coefficients[mult.degree] = remainder.coefficients[c] / p1.coefficients[p1.degree];
            quotient += mult;
            remainder -= mult * p1;
          }
          return remainder;   // Return the REMAINDER part
      }

      public Complex[] CalculateSecondDegreeComplexRoot()
      {
          //uses quadratic formula with coefficients as complex numbers
          Complex[] roots = new Complex[2];
            Complex a = coefficients[2], b = coefficients[1], c = coefficients[0];      
            roots[0] = (-b + (b * b - a * c * 4).positiveSqrt()) / (a * 2);
            roots[1] = (-b - (b * b - a * c * 4).positiveSqrt()) / (a * 2);
          return roots;
      }

      public ComplexPolynomial clone() {
        ComplexPolynomial cpy = new ComplexPolynomial(this.degree);
            //cpy.degree = this.degree;
            //cpy.coefficients = new Complex[this.degree + 1];
            for (int i = 0; i <= this.degree; i++)
                cpy.coefficients[i] = this.coefficients[i].clone();
        return cpy;
      }

        public Complex RootVer (Complex x)
        {
            Complex retval = new Complex(0, 0);
            for (int i = degree; i >= 0; i--)
                retval += coefficients[i] * x.pow(i);

            return retval;
        }

        public string ToString()
        {
            if (degree == 0 && coefficients[0] == 0) return "0";
            string polyString = "";
            Complex zero = new Complex();
            zero.SetComplex(0, 0);
            for (int i = degree; i >= 0; i--)
            {
                if (coefficients[i] != zero)
                {
                    if (polyString != "")
                        polyString += " + ";
                    polyString += "(" + coefficients[i].output() + ")";
                    if (i > 1)
                        polyString += ("X^" + i.ToString());
                    else if (i == 1)
                        polyString += "X";
                }
            }
            return polyString;
        }
      public void Print()
      {
          Console.WriteLine(this.ToString());
      }

        public int getDegree()
        {
            return degree;
        }

        public Complex[] getCoefficients()
        {
            return coefficients;
        }

      /* Fancy Operator magic below here */
      public static ComplexPolynomial operator+ (ComplexPolynomial a, ComplexPolynomial b) {
        return a.CalculateAddition(b);
      }
      public static ComplexPolynomial operator- (ComplexPolynomial a, ComplexPolynomial b) {
        return a.CalculateSubtraction(b);
      }
      public static ComplexPolynomial operator* (ComplexPolynomial a, ComplexPolynomial b) {
        return a.CalculateProduct(b);
      }
      public static ComplexPolynomial operator/ (ComplexPolynomial a, ComplexPolynomial b) {
        return a.CalculateQuotient(b);
      }
      public static ComplexPolynomial operator% (ComplexPolynomial a, ComplexPolynomial b) {
        return a.CalculateRemainder(b);
      }

  }
}
