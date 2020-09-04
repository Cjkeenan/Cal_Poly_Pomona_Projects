using System;

namespace ColinKeenanECE256MidtermRedo
{
    public class Polynomial
    {
        private double[] coefficients;
        private int degree;
        public void SetPolynomial(double[] coef, int deg)
        {
            coefficients = coef;
            degree = deg;
        }

        public Polynomial CalculateDerivative()
        {
            Polynomial deriv = new Polynomial();
            deriv.degree = degree - 1;
            deriv.coefficients = new double[deriv.degree + 1];
            for (int i = degree; i > 0; i--)
            {
                deriv.coefficients[i - 1] = coefficients[i] * i;
            }
            return deriv;
        }
        public Polynomial CalculateAddition(Polynomial p1)
        {
            int higherDegree;
            Polynomial result = new Polynomial();
            if (degree > p1.degree)
            {
                higherDegree = degree;
                result.coefficients = new double[degree + 1];
            }
            else
            {
                higherDegree = p1.degree;
                result.coefficients = new double[p1.degree + 1];
            }
            for (int i = 0; i <= higherDegree; i++)
            {
                if (i <= degree && i <= p1.degree)
                    result.coefficients[i] = coefficients[i] + p1.coefficients[i];
                else if (i <= degree)
                    result.coefficients[i] = coefficients[i];
                else
                    result.coefficients[i] = p1.coefficients[i];
                if (result.coefficients[i] != 0)
                    result.degree = i;
            }
            return result;
        }
        public Polynomial CalculateProduct(Polynomial p1)
        {
            Polynomial product = new Polynomial();
            product.degree = degree + p1.degree;
            product.coefficients = new double[product.degree + 1];

            for(int i = 0; i < degree; i++)
            {
                for(int j = 0; j < p1.degree; j++)
                {
                    product.coefficients[i + p1.degree + 1] = coefficients[i] * p1.coefficients[j];
                }
            }
            return product;
        }
        
        public void Print()
        {
            string polyString = "";
            for (int i = degree; i >= 0; i--)
            {
                if (coefficients[i] != 0)
                {
                    if (polyString != "")
                        polyString += " + ";
                    polyString += coefficients[i].ToString();
                    if (i > 1)
                        polyString += ("X^" + i.ToString());
                    else if (i == 1)
                        polyString += "X";
                }
            }
            Console.Write(polyString);
        }

    }
    public class Problem_4
    {
        public void Run()
        {
            Polynomial Test1 = new Polynomial();
            Polynomial Test2 = new Polynomial();
            Polynomial Deriv1 = new Polynomial();
            Polynomial Deriv2 = new Polynomial();

            double[] coef1 = { 1, -5, 4 };
            double[] coef2 = { 1, 0, 1, 1 };
            int deg1 = 2;
            int deg2 = 3;

            Test1.SetPolynomial(coef1, deg1);
            Test2.SetPolynomial(coef2, deg2);

            Console.Write("Polynomial 1: ");
            Test1.Print();
            Console.Write("\nDerivative 1: ");
            Deriv1 = Test1.CalculateDerivative();
            Deriv1.Print();

            Console.Write("\nPolynomial 2: ");
            Test2.Print();
            Console.Write("\nDerivative 2: ");
            Deriv2 = Test2.CalculateDerivative();
            Deriv2.Print();

        }
    }
}