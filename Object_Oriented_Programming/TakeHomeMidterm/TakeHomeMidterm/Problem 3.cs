using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeMidterm
{
    class Problem_3
    {
        public void Run()
        {
            //Pair 1
            ComplexPolynomial p1a = new ComplexPolynomial(new Complex[] {
                new Complex(1, 0),
                new Complex(1, 0),
                new Complex(1, 0)
                }, 2);
            ComplexPolynomial p1b = new ComplexPolynomial(new Complex[] {
                new Complex(1, 0),
                new Complex(1, 0)
                }, 1);

            //calculate for pair 1
            ComplexPolynomial quo1 = p1a / p1b;
            ComplexPolynomial rem1 = p1a % p1b;

            //Pair 2
            ComplexPolynomial p2a = new ComplexPolynomial(new Complex[] {
                new Complex(1, 0),
                new Complex(1, 0),
                new Complex(0, 0),
                new Complex(0, 0),
                new Complex(0, 0),
                new Complex(1, 0)
                }, 5);
            ComplexPolynomial p2b = new ComplexPolynomial(new Complex[] {
                new Complex(1, 0),
                new Complex(1, 0),
                new Complex(1, 0)
                }, 2);

            //calculate for pair 2
            ComplexPolynomial quo2 = p2a / p2b;
            ComplexPolynomial rem2 = p2a % p2b;

            //Pair 3
            ComplexPolynomial p3a = new ComplexPolynomial(new Complex[] {
                new Complex(1, 0),
                new Complex(1, 0),
                new Complex(1, 0),
                new Complex(1, 0),
                new Complex(1, 0),
                new Complex(1, 0),
                new Complex(1, 0),
                new Complex(1, 0),
                new Complex(1, 0),
                new Complex(1, 0),
                new Complex(1, 0)
                }, 10);
            ComplexPolynomial p3b = new ComplexPolynomial(new Complex[] {
                new Complex(1, 0),
                new Complex(1, 0),
                new Complex(1, 0),
                new Complex(1, 0)
                }, 3);

            //calculate for pair 3
            ComplexPolynomial quo3 = p3a / p3b;
            ComplexPolynomial rem3 = p3a % p3b;

            Console.WriteLine("Pair 1 Polynomials: {0} and {1}\nQuotient: {2}\nRemainder: {3}\nVerify: {4}\n",
                    p1a.ToString(),
                    p1b.ToString(),
                    quo1.ToString(),
                    rem1.ToString(),
                    (quo1 * p1b + rem1).ToString()
                );
            Console.WriteLine("Pair 2 Polynomials: {0} and {1}\nQuotient: {2}\nRemainder: {3}\nVerify: {4}\n",
                    p2a.ToString(),
                    p2b.ToString(),
                    quo2.ToString(),
                    rem2.ToString(),
                    (quo2 * p2b + rem2).ToString()
                );
            Console.WriteLine("Pair 3 Polynomials: {0} and {1}\nQuotient: {2}\nRemainder: {3}\nVerify: {4}",
                    p3a.ToString(),
                    p3b.ToString(),
                    quo3.ToString(),
                    rem3.ToString(),
                    (quo3 * p3b + rem3).ToString()
                );
        }
    }
}
