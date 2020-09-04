using System;

namespace ColinKeenanECE256MidtermRedo
{
    public class Problem_5
    {
        public void Run()
        {
            Polynomial Test1 = new Polynomial();
            Polynomial Test2 = new Polynomial();
            Polynomial Addition1 = new Polynomial();
            Polynomial Test3 = new Polynomial();
            Polynomial Test4 = new Polynomial();
            Polynomial Addition2 = new Polynomial();

            double[] coef1 = { 1, -5, 4 };
            double[] coef2 = { 1, 0, 1, 1 };
            double[] coef3 = { 1, -5, 4 };
            double[] coef4 = { -1, -5, 4 };
            int deg1 = 2;
            int deg2 = 3;
            int deg3 = 2;
            int deg4 = 2;

            Test1.SetPolynomial(coef1, deg1);
            Test2.SetPolynomial(coef2, deg2);
            Test3.SetPolynomial(coef3, deg3);
            Test4.SetPolynomial(coef4, deg4);

            Addition1 = Test1.CalculateAddition(Test2);
            Addition2 = Test3.CalculateAddition(Test4);

            Console.Write("The addition of ");
            Test1.Print();
            Console.Write(" and ");
            Test2.Print();
            Console.Write(" = ");
            Addition1.Print();

            Console.Write("\nThe addition of ");
            Test3.Print();
            Console.Write(" and ");
            Test4.Print();
            Console.Write(" = ");
            Addition2.Print();
        }
    }
}