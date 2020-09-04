using System;
using System.Numerics;

namespace ColinKeenanECE256MidtermRedo
{
    public class HugeInteger
    {
        BigInteger num1 = 0;
        BigInteger num2 = 0;

        public void Input(string input1, string input2)
        {
            var chars1 = input1.ToCharArray();
            var chars2 = input2.ToCharArray();
            string n1 = new String(chars1);
            string n2 = new String(chars2);
            num1 = BigInteger.Parse(n1);
            num2 = BigInteger.Parse(n2);
        }
        public string ToString(BigInteger value)
        {
            string output = value.ToString();
            return output;
        }

        public string ToString(Decimal value)
        {
            string output = value.ToString();
            return output;
        }
        public BigInteger Add()
        {
            BigInteger sum = num1 + num2;
            return sum;
        }
        public BigInteger Multiply()
        {
            BigInteger product = num1 * num2;
            return product;
        }
    }
    public class Problem_8
    {
        public void Run()
        {
            HugeInteger hugeInteger = new HugeInteger();
            string number1 = "";
            string number2 = "";

            Console.Write("Enter the first number: ");
            number1 = Console.ReadLine();

            Console.Write("Enter the second number: ");
            number2 = Console.ReadLine();

            Console.WriteLine("");

            hugeInteger.Input(number1, number2);
            Console.WriteLine("The sum of the numbers: {0}", hugeInteger.ToString(hugeInteger.Add()));
            Console.WriteLine("The product of the numbers: {0}", hugeInteger.ToString(hugeInteger.Multiply()));
            }
        }
    }