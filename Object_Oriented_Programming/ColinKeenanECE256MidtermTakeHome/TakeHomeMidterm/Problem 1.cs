using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeMidterm
{
    class HugeInteger
    {
        private int[] huge;
        private int sign = 0;

        public HugeInteger(int[] a, int sign)
        {
            this.sign = sign;
            huge = new int[a.Length];
            for (int i = 0; i <= a.Length - 1; i++)
            {
                huge[i] = a[i] * sign;
            }
        }
        //addition of integers
        public HugeInteger add(HugeInteger a)
        {
            int z;
            int[] tempthis;
            int[] tempa;
            if (this.huge.Length > a.huge.Length)
            {
                z = this.huge.Length;
                tempthis = this.huge;
                tempa = new int[this.huge.Length];
                int yxz = 0;
                for (int num = z - a.huge.Length; yxz <= a.huge.Length - 1; num++)
                {
                    tempa[num] = a.huge[yxz];
                    yxz += 1;
                }
            }
            else
            {
                z = a.huge.Length;
                tempa = a.huge;
                tempthis = new int[a.huge.Length];
                int yxz = 0;
                for (int num = z - this.huge.Length; yxz <= this.huge.Length - 1; num++)
                {
                    tempthis[num] = this.huge[yxz];
                    yxz += 1;
                }
            }
            int[] answerarray = new int[z];
            bool carry = false;
            bool negcarry = false;
            for (int w = z - 1; w >= 0; w--)
            {
                if ((answerarray[w] + tempthis[w] + tempa[w]) >= 10 && (w != 0))
                {
                    answerarray[w] = (tempthis[w] + tempa[w] + answerarray[w]) % 10;
                    answerarray[w - 1] += 1;
                }
                else if (answerarray[w] + tempthis[w] + tempa[w] >= 10 && w == 0)
                {
                    answerarray[w] = (answerarray[w] + tempthis[w] + tempa[w]) % 10;
                    carry = true;
                }
                else if (answerarray[w] + tempthis[w] + tempa[w] <= -10 && (w != 0))
                {
                    answerarray[w] = (answerarray[w] + tempthis[w] + tempa[w]) % 10;
                    answerarray[w - 1] += -1;
                }
                else if (answerarray[w] + tempthis[w] + tempa[w] <= -10 && (w == 0))
                {
                    answerarray[w] = (answerarray[w] + tempthis[w] + tempa[w]) % 10;
                    negcarry = true;
                }

                else if (tempthis[w] < Math.Abs(tempa[w]) && a.sign == -1 && (w != 0) && this.sign == 1)
                {
                    tempthis[w - 1] -= 1;
                    tempthis[w] += 10;
                    answerarray[w] += (tempthis[w] + tempa[w]);
                }
                else if (Math.Abs(tempthis[w]) > (tempa[w]) && a.sign == 1 && (w != 0) && this.sign == -1)
                {
                    tempa[w - 1] -= 1;
                    tempa[w] += 10;
                    answerarray[w] = (answerarray[w] + tempthis[w] + tempa[w]);
                }
                else
                {
                    answerarray[w] = (answerarray[w] + tempthis[w] + tempa[w]);
                }
            }
            int[] answerarray1;

            if (carry)
            {
                answerarray1 = new int[z + 1];
                for (int w = 0; w <= z; w++)
                {
                    if (w == 0)
                    {
                        answerarray1[w] = 1;
                    }
                    else
                    {
                        answerarray1[w] = answerarray[w - 1];
                    }
                }
            }
            else if (negcarry)
            {
                answerarray1 = new int[z + 1];
                for (int w = 0; w <= z; w++)
                {
                    if (w == 0)
                    {
                        answerarray1[w] = -1;
                    }
                    else
                    {
                        answerarray1[w] = answerarray[w - 1];
                    }
                }
            }
            else
            {
                answerarray1 = answerarray;
            }

            HugeInteger answer;

            answer = new HugeInteger(answerarray1, 1);

            return answer;
        }
        public string print()
        {
            string result;
            if (this.sign == -1)
            {
                result = "-";
            }
            else
            {
                result = "";
            }
            for (int i = 0; i <= huge.Length - 1; i++)
            {
                result = result + Math.Abs(huge[i]).ToString();
            }
            return result;
        } //end print 


        private HugeInteger subtractproduct(HugeInteger a)
        {
            HugeInteger sub = new HugeInteger(a.huge, -1);
            return this.add(sub);
        }//end subtract 


        public HugeInteger product(HugeInteger a)
        {
            int[] w = { 1 };
            int[] x = { 0 };
            HugeInteger temp = new HugeInteger(w, 1);
            HugeInteger answer = new HugeInteger(x, 1);
            while (!a.CheckZero(a))
            {
                answer = answer.add(this);
                a = a.subtractproduct(temp);
            }
            return answer;
        } //end product 

        public HugeInteger division(HugeInteger a)
        {
            int[] w = { 1 };
            int[] x = { 0 };
            HugeInteger temp = new HugeInteger(x, 1);
            HugeInteger answer = new HugeInteger(this.huge, 1);
            HugeInteger answer1 = new HugeInteger(w, 1);
            while (answer.sign == 1)
            {

                answer = answer.subtract(a);
                if (answer.sign == -1)
                {
                    break;
                }
                temp = temp.add(answer1);
            }
            return temp;
        }//end division
        public HugeInteger modulo(HugeInteger a)
        {
            int[] w = { 1 };
            int[] x = { 0 };
            HugeInteger temp = new HugeInteger(x, 1);
            HugeInteger answer = new HugeInteger(this.huge, 1);
            HugeInteger answer1 = new HugeInteger(w, 1);
            HugeInteger store = new HugeInteger(x, 1);
            while (answer.sign == 1)
            {

                store = answer;
                answer = answer.subtract(a);
                if (answer.sign == -1)
                {
                    break;
                }
                temp = temp.add(answer1);
            }
            return store;
        }//end modulo
        private bool CheckZero(HugeInteger a)
        {
            foreach (int digit in a.huge)
            {
                if (digit != 0)
                {
                    return false;
                }
            }
            return true;
        }//end CheckZero
        public HugeInteger subtract(HugeInteger a)
        {
            int greater = 0;

            int z;
            int[] tempthis;
            int[] tempa;
            int yxz;
            HugeInteger answersub = new HugeInteger(this.huge, greater);

            if (this.huge.Length > a.huge.Length)
            {
                z = this.huge.Length;
                tempthis = this.huge;
                tempa = new int[this.huge.Length];
                yxz = 0;
                for (int num = z - a.huge.Length; yxz <= a.huge.Length - 1; num++)
                {
                    tempa[num] = a.huge[yxz];
                    yxz += 1;
                }
            }
            else
            {
                z = a.huge.Length;
                tempa = a.huge;
                tempthis = new int[a.huge.Length];
                yxz = 0;
                for (int num = z - this.huge.Length; yxz <= this.huge.Length - 1; num++)
                {
                    tempthis[num] = this.huge[yxz];
                    yxz += 1;
                }
            }

            if ((this.sign == 1) && (a.sign == -1))
            {
                int subsign = 1;
                int[] sub = new int[tempa.Length]; //no carry return
                int[] carrysub = new int[tempa.Length + 1];// returns when there is a carry

                for (int i = 0; i < tempa.Length; i++)
                {
                    sub[i] = 0;
                }//end for

                for (int i = 0; i < tempa.Length + 1; i++)
                {
                    carrysub[i] = 0;
                }//end for

                for (int i = (tempa.Length - 1); i > 0; i--)
                {
                    sub[i] = tempa[i] + tempthis[i] + sub[i];

                    if (sub[i] >= 10)
                    {
                        sub[i - 1] = 1;
                        sub[i] = sub[i] - 10;
                    } //end if
                } //end for 

                sub[0] = tempa[0] + tempthis[0] + sub[0];


                if (sub[0] >= 10)
                {
                    carrysub[0] = 1;
                    sub[0] = sub[0] - 10;

                    for (int i = (tempthis.Length - 1); i >= 0; i--)
                    {
                        carrysub[i + 1] = sub[i];
                    }
                    answersub = new HugeInteger(carrysub, subsign);
                } //end if
                else
                {
                    answersub = new HugeInteger(sub, subsign);
                }


                return answersub;
            } //end if


            if ((this.sign == -1) && (a.sign == 1))
            {
                int subsign = -1;
                int[] sub = new int[tempa.Length];// no carry
                int[] carrysub = new int[tempa.Length + 1];// this should return if there is a carry

                for (int i = 0; i < tempa.Length; i++)
                {
                    sub[i] = 0;
                } //end for 

                for (int i = 0; i < tempa.Length + 1; i++)
                {
                    carrysub[i] = 0;
                } //end for

                for (int i = (tempthis.Length - 1); i >= 0; i--)
                {
                    sub[i] = tempa[i] + tempthis[i] + sub[i];

                    if (sub[i] >= 10)
                    {
                        sub[i - 1] = 1;
                        sub[i] = sub[i] - 10;
                    }//end if
                }//end for

                sub[0] = tempa[0] + tempthis[0] + sub[0];

                if (sub[0] >= 10)
                {
                    carrysub[0] = 1;
                    sub[0] = sub[0] - 10;

                    for (int i = (tempthis.Length - 1); i >= 0; i--)
                    {
                        carrysub[i + 1] = sub[i];
                    }//end for

                    answersub = new HugeInteger(carrysub, subsign);
                }//end if
                else
                {
                    answersub = new HugeInteger(sub, subsign);
                }

            } //end if 

            if ((this.sign == -1) && (a.sign == -1))
            {
                int subsign = 0;
                int[] sub = new int[tempa.Length];


                for (int i = 0; i <= tempthis.Length; i++)
                {
                    if (tempa[i] > tempthis[i])
                    {
                        greater = 1;
                        break;
                    } //end if 
                    else if (tempa[i] < tempthis[i])
                    {
                        greater = -1;
                        break;

                    }//end if
                    else
                        greater = 0;

                }//end for


                if (greater == -1)
                {

                    for (int i = (tempa.Length - 1); i >= 0; i--)
                    {

                        if (tempthis[i] < tempa[i])
                        {
                            sub[i] = tempthis[i] - tempa[i] + 10;
                            tempthis[i - 1] = tempthis[i - 1] - 1;
                        } //end if 
                        else
                            sub[i] = tempthis[i] - tempa[i];


                    }//end for

                    subsign = -1;

                }//end if
                if (greater == 1)
                {

                    for (int i = (tempa.Length - 1); i >= 0; i--)
                    {

                        if (tempthis[i] > tempa[i])
                        {
                            sub[i] = tempa[i] - tempthis[i] + 10;
                            tempa[i - 1] = tempa[i - 1] - 1;
                        }//end if 
                        else
                            sub[i] = tempa[i] - tempthis[i];


                    }//end for

                    subsign = 1;
                }//end if 

                if (greater == 0)
                {

                    for (int i = 0; i < tempa.Length; i++)
                    {
                        sub[i] = 0;
                    }//end for

                    subsign = 1;
                }//end if 
                answersub = new HugeInteger(sub, subsign);
            }//end if 


            if ((this.sign == 1) && (a.sign == 1))
            {
                int subsign = 0;
                int[] sub = new int[tempa.Length];


                for (int i = 0; i < tempthis.Length; i++)
                {
                    if (tempa[i] > tempthis[i])
                    {
                        greater = 1;
                        break;
                    }//end if
                    else if (tempa[i] < tempthis[i])
                    {
                        greater = -1;
                        break;

                    } //end else if 
                    else
                        greater = 0;

                }//end for 

                if (greater == -1)
                {

                    for (int i = (tempa.Length - 1); i >= 0; i--)
                    {

                        if (tempthis[i] < tempa[i])
                        {
                            sub[i] = tempthis[i] - tempa[i] + 10;
                            tempthis[i - 1] = tempthis[i - 1] - 1;
                        }//end if 
                        else
                            sub[i] = tempthis[i] - tempa[i];


                    }//end for 

                    subsign = 1;

                }//end if 

                if (greater == 1)
                {

                    for (int i = (tempa.Length - 1); i >= 0; i--)
                    {

                        if (tempthis[i] > tempa[i])
                        {
                            sub[i] = tempa[i] - tempthis[i] + 10;
                            tempa[i - 1] = tempa[i - 1] - 1;
                        }//end if 
                        else
                            sub[i] = tempa[i] - tempthis[i];
                    }//end for 

                    subsign = -1;
                }//end if

                if (greater == 0)
                {

                    for (int i = 0; i < tempa.Length; i++)
                    {
                        sub[i] = 0;
                    }//end for 

                    subsign = 1;
                }//end if 
                answersub = new HugeInteger(sub, subsign);
            }//end if this.sign && a.sign

            return answersub;
        }//end subtract
    }
    class Problem_1
    {
        public void Run()
        {
            ///////////////////////////////////////////////////////////////////////

            int[] n1 = { 1 };
            int[] n2 = { 2, 5 }; //for 25!
            int[] n3 = { 1 };

            ///////////////////////////////////////////////////////

            int[] n4 = { 1, 0, 0 };
            int[] n5 = { 7 };
            int[] n6 = { 2, 0, 1, 7 };
            int[] n7 = { 2, 5, 6 };
            int[] n8 = { 6, 7, 3, 2, 5, 6, 0 };
            int[] n9 = { 6, 2, 8, 0 };

            ///////////////////////////////////////////////////////////
            HugeInteger H1 = new HugeInteger(n1, 1);
            HugeInteger H2 = new HugeInteger(n2, 1);
            HugeInteger HugeFac = new HugeInteger(n3, 1);

            HugeInteger H100 = new HugeInteger(n4, 1);
            HugeInteger H7 = new HugeInteger(n5, 1);
            HugeInteger H2017 = new HugeInteger(n6, 1);
            HugeInteger H256 = new HugeInteger(n7, 1);
            HugeInteger H7dig = new HugeInteger(n8, 1);
            HugeInteger H4dig = new HugeInteger(n9, 1);


            ///////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("for integers, 100 and 7:");
            Console.WriteLine("100 + 7 = {0} ", H100.add(H7).print()); //100+7
            Console.WriteLine("100 - 7 = {0}", H100.subtract(H7).print()); //100-7
            Console.WriteLine("100 * 7 = {0}", H100.product(H7).print()); // 100* 7
            Console.WriteLine("100 / 7 = {0}", H100.division(H7).print()); // 100/7
            Console.WriteLine("100 % 7 = {0}", H100.modulo(H7).print()); // 100 % 7


            //////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("\nfor integers, 2017 and 256:");
            Console.WriteLine("2017 + 256 =  {0} ", H2017.add(H256).print()); //2017+256
            Console.WriteLine("2017 - 256 =  {0} ", H2017.subtract(H256).print());//2017-256
            H2017 = new HugeInteger(n6, 1); //remake huge integers
            H256 = new HugeInteger(n7, 1); //error crops up when huge integers are not remade 
            Console.WriteLine("2017 * 256 =  {0} ", H2017.product(H256).print());//2017*256
            Console.WriteLine("2017 / 256 =  {0} ", H2017.division(H256).print());//2017/256
            Console.WriteLine("2017 % 256 =  {0} ", H2017.modulo(H256).print());//2017%256

            ///////////////////////////////////////////////////////////////////////////////   

            Console.WriteLine("\nfor integers 6732560 and 6280:");
            Console.WriteLine("6732560 + 6280= {0} ", H7dig.add(H4dig).print());
            Console.WriteLine("6732560 - 6280= {0} ", H7dig.subtract(H4dig).print());
            //H7dig = new HugeInteger(n8, 1); //rebuild huge integers for multiplication
            //H4dig = new HugeInteger(n9, 1); //division, and modulo 
            Console.WriteLine("6732560 * 6280= {0} ", H7dig.product(H4dig).print());
            Console.WriteLine("6732560 / 6280= {0} ", H7dig.division(H4dig).print());
            Console.WriteLine("6732560 % 6280= {0} ", H7dig.modulo(H4dig).print());

            ///////////////////////////////////////////////////////////////////////////////////////////////    

            Console.Write("\n25! is equal to: ");

            for (int i = 1; i <= 25; i++)
            {
                H1 = H1.product(H2);
                H2 = H2.subtract(HugeFac);
            }

            Console.WriteLine(H1.print());
        }
    }
}
