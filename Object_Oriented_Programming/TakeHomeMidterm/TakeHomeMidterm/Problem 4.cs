using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeMidterm
{
    public class Problem_4
    {
        public void Run()
        {
            //Pair 1
            ComplexPolynomial p1 = new ComplexPolynomial(new Complex[] {
                new Complex(1, 1),
                new Complex(1, -1),
                new Complex(0, 1)
                }, 2);
            ComplexPolynomial add1 = new ComplexPolynomial();
            ComplexPolynomial mul1 = new ComplexPolynomial();
  
            //calculate for pair 1
            add1 = p1.CalculateAddition(p1);
            mul1 = p1.CalculateProduct(p1);

            //Pair 2
            ComplexPolynomial p2a = new ComplexPolynomial(new Complex[] {
                new Complex(1, 1),
                new Complex(1, -1),
                new Complex(0, 1)
                }, 2);
            ComplexPolynomial p2b = new ComplexPolynomial(new Complex[] {
                new Complex(1, 0),
                new Complex(1, 0),
                new Complex(1, 0)
                }, 2);
            ComplexPolynomial add2 = new ComplexPolynomial();
            ComplexPolynomial mul2 = new ComplexPolynomial();

            //calculate for pair 2
            add2 = p2a.CalculateAddition(p2b);
            mul2 = p2a.CalculateProduct(p2b);

            //Pair 3
            ComplexPolynomial p3a = new ComplexPolynomial(new Complex[] {
                new Complex(1, 1),
                new Complex(1, -1),
                new Complex(0, 1),
                new Complex(0, 1)
                }, 3);
            ComplexPolynomial p3b = new ComplexPolynomial(new Complex[] {
                new Complex(0, 1),
                new Complex(0, 1),
                new Complex(0, 1),
                new Complex(0, 1)
                }, 3);
            ComplexPolynomial add3 = new ComplexPolynomial();
            ComplexPolynomial mul3 = new ComplexPolynomial();

            //calculate for pair 3
            add3 = p3a.CalculateAddition(p3b);
            mul3 = p3a.CalculateProduct(p3b);

            //Write to Console

            Console.WriteLine("Pair 1 Polynomials: {0} and {1}\nAddition: {2}\nMultiplication: {3}\n",
                    p1.ToString(),
                    p1.ToString(),
                    mul1.ToString(),
                    add1.ToString()
                );
            Console.WriteLine("Pair 2 Polynomials: {0} and {1}\nAddition: {2}\nMultiplication: {3}\n",
                    p2a.ToString(),
                    p2b.ToString(),
                    mul2.ToString(),
                    add2.ToString()
                );
            Console.WriteLine("Pair 3 Polynomials: {0} and {1}\nAddition: {2}\nMultiplication: {3}\n",
                    p3a.ToString(),
                    p3b.ToString(),
                    mul3.ToString(),
                    add3.ToString()
                );
            
        }
    }
}
