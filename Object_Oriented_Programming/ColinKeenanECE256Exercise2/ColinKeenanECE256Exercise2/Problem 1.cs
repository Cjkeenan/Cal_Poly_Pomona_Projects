using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinKeenanECE256Exercise2
{
    public class Problem_1
    {
        public void Run()
        {
            double A, B, C;
            Console.Write("\nPlease enter the length of side A: ");
            A = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please enter the length of side B: ");
            B = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please enter the length of side C: ");
            C = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("");

            //make sure C is longest length
            if (C < A)
            {
                //Console.WriteLine("Before Swap: A = {0}, B = {1}, C = {2}", A, B, C);
                double temp = A;
                A = C;
                C = temp;
                //Console.WriteLine("After Swap: A = {0}, B = {1}, C = {2}\n", A, B, C);
            }
            if(C < B)
            {
                //Console.WriteLine("Before Swap: A = {0}, B = {1}, C = {2}", A, B, C);
                double temp = B;
                B = C;
                C = temp;
                //Console.WriteLine("After Swap: A = {0}, B = {1}, C = {2}\n", A, B, C);
            }

            //Check if Triangle
            if((A + B > C))
            {
                if (A == B)
                {
                    if(B == C)
                    {
                        Console.WriteLine("Congratulations, you have an equilateral triangle.");
                    }
                    else
                    {
                        if((A * A) + (B * B) > (C * C))      //Acute
                        {
                            Console.WriteLine("Congratulations, you have an acute isosceles triangle.");
                        }
                        else if ((A * A) + (B * B) < (C * C))     //Obtuse
                        {
                            Console.WriteLine("Congratulations, you have an obtuse isosceles triangle.");
                        }
                        else if ((A * A) + (B * B) == (C * C))     //Right
                        {
                            Console.WriteLine("Congratulations, you have a right isosceles triangle.");
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong.");
                        }
                    }
                }
                else
                {
                    if(B == C)
                    {
                        if ((A * A) + (B * B) > (C * C))      //Acute
                        {
                            Console.WriteLine("Congratulations, you have an acute isosceles triangle.");
                        }
                        else if ((A * A) + (B * B) < (C * C))     //Obtuse
                        {
                            Console.WriteLine("Congratulations, you have an obtuse isosceles triangle.");
                        }
                        else if ((A * A) + (B * B) == (C * C))     //Right
                        {
                            Console.WriteLine("Congratulations, you have a right isosceles triangle.");
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong.");
                        }
                    }
                    else
                    {
                        if(A == C)
                        {
                            if ((A * A) + (B * B) > (C * C))      //Acute
                            {
                                Console.WriteLine("Congratulations, you have an acute isosceles triangle.");
                            }
                            else if ((A * A) + (B * B) < (C * C))     //Obtuse
                            {
                                Console.WriteLine("Congratulations, you have an obtuse isosceles triangle.");
                            }
                            else if ((A * A) + (B * B) == (C * C))     //Right
                            {
                                Console.WriteLine("Congratulations, you have a right isosceles triangle.");
                            }
                            else
                            {
                                Console.WriteLine("Something went wrong.");
                            }
                        }
                        else
                        {
                            if ((A * A) + (B * B) > (C * C))      //Acute
                            {
                                Console.WriteLine("Congratulations, you have an acute scalene triangle.");
                            }
                            else if ((A * A) + (B * B) < (C * C))     //Obtuse
                            {
                                Console.WriteLine("Congratulations, you have an obtuse scalene triangle.");
                            }
                            else if ((A * A) + (B * B) == (C * C))     //Right
                            {
                                Console.WriteLine("Congratulations, you have a right scalene triangle.");
                            }
                            else
                            {
                                Console.WriteLine("Something went wrong.");
                            }
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Sorry, those three side lengths do not form a triangle.");
            }
        }
    }
}
