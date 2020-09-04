using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeMidterm
{
    class Problem_2
    {
        public void Run()
        {
            ComplexPolynomial p2 = new ComplexPolynomial(new Complex[]{
                new Complex(0, 1),
                new Complex(1, -1),
                new Complex(1, 1)
            }, 2);
            Complex[] answer = new Complex[2];

            answer = p2.CalculateSecondDegreeComplexRoot();

            Console.Write("Polynomial: ");
            p2.Print();
            Console.WriteLine("");
            for (int i = 0; i < p2.getDegree(); i++)
            {
                Console.WriteLine("Root {0}: {1}",i + 1, answer[i].output(true));
            }
            Console.WriteLine("Verify below: (Should be really small ~0)");
            Console.WriteLine("With Root 1: {0}\nWith Root 2: {1}",
                    p2.RootVer(answer[0]).output(true),
                    p2.RootVer(answer[1]).output(true));

        }
    }
}
