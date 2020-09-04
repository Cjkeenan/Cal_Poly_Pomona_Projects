using System;

namespace ColinKeenanECE256MidtermRedo
{
    public class Problem_6
    {
        public void Run()
        {
            Polynomial Test1 = new Polynomial();
            Polynomial Test2 = new Polynomial();
            Polynomial Product1 = new Polynomial();
            Polynomial Test3 = new Polynomial();
            Polynomial Test4 = new Polynomial();
            Polynomial Product2 = new Polynomial();

            double[] coef1 = { 1, 1, 1 };
            double[] coef2 = { 1, 1 };
            double[] coef3 = { 2, 7, 8 };
            double[] coef4 = { 1, 1, 17, 4 };
            int deg1 = 2;
            int deg2 = 1;
            int deg3 = 2;
            int deg4 = 3;

            Test1.SetPolynomial(coef1, deg1);
            Test2.SetPolynomial(coef2, deg2);
            Test3.SetPolynomial(coef3, deg3);
            Test4.SetPolynomial(coef4, deg4);

            Product1 = Test1.CalculateProduct(Test2);
            Product2 = Test3.CalculateProduct(Test4);

            Console.Write("The multiplication of ");
            Test1.Print();
            Console.Write(" and ");
            Test2.Print();
            Console.Write(" = ");
            Product1.Print();

            Console.Write("\nThe multiplication of ");
            Test3.Print();
            Console.Write(" and ");
            Test4.Print();
            Console.Write(" = ");
            Product2.Print();
        }
    }
}