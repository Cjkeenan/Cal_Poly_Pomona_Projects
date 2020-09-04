using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems_3_4
{ 
        class HugeInteger
        {
            private int[] huge;
            private int sign;

            public HugeInteger(int[] a, int sign)
            {
                this.sign = sign;
                huge = new int[a.Length]; //set new length of huge integer to amount of numbers you inputted
                for (int i = 0; i <= a.Length - 1; i++)
                {
                    huge[i] = a[i] * sign;  //assign values you inputted into the array
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
            }

            private HugeInteger subproduct(HugeInteger a)
            {
                HugeInteger sub = new HugeInteger(a.huge, -1);
                return this.add(sub);
            }
            //product of integers
            public HugeInteger product(HugeInteger a)
            {
                int[] w = { 1 };
                int[] x = { 0 };
                HugeInteger temp = new HugeInteger(w, 1);
                HugeInteger answer = new HugeInteger(x, 1);
                while (!a.CheckZero(a))
                {
                    answer = answer.add(this);
                    a = a.subproduct(temp);
                }
                return answer;
            }
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
            }
            //subtraction of integers
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
                    }

                    for (int i = 0; i < tempa.Length + 1; i++)
                    {
                        carrysub[i] = 0;
                    }

                    for (int i = (tempa.Length - 1); i > 0; i--)
                    {
                        sub[i] = tempa[i] + tempthis[i] + sub[i];

                        if (sub[i] >= 10)
                        {
                            sub[i - 1] = 1;
                            sub[i] = sub[i] - 10;
                        }
                    }

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
                    }
                    else
                    {
                        answersub = new HugeInteger(sub, subsign);
                    }


                    return answersub;
                }


                if ((this.sign == -1) && (a.sign == 1))
                {
                    int subsign = -1;
                    int[] sub = new int[tempa.Length];// no carry
                    int[] carrysub = new int[tempa.Length + 1];// this should return if there is a carry

                    for (int i = 0; i < tempa.Length; i++)
                    {
                        sub[i] = 0;
                    }

                    for (int i = 0; i < tempa.Length + 1; i++)
                    {
                        carrysub[i] = 0;
                    }

                    for (int i = (tempthis.Length - 1); i >= 0; i--)
                    {
                        sub[i] = tempa[i] + tempthis[i] + sub[i];

                        if (sub[i] >= 10)
                        {
                            sub[i - 1] = 1;
                            sub[i] = sub[i] - 10;
                        }
                    }

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
                    }
                    else
                    {
                        answersub = new HugeInteger(sub, subsign);
                    }

                }

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
                        }
                        else if (tempa[i] < tempthis[i])
                        {
                            greater = -1;
                            break;

                        }
                        else
                            greater = 0;

                    }


                    if (greater == -1)
                    {

                        for (int i = (tempa.Length - 1); i >= 0; i--)
                        {

                            if (tempthis[i] < tempa[i])
                            {
                                sub[i] = tempthis[i] - tempa[i] + 10;
                                tempthis[i - 1] = tempthis[i - 1] - 1;
                            }
                            else
                                sub[i] = tempthis[i] - tempa[i];


                        }

                        subsign = -1;

                    }
                    if (greater == 1)
                    {

                        for (int i = (tempa.Length - 1); i >= 0; i--)
                        {

                            if (tempthis[i] > tempa[i])
                            {
                                sub[i] = tempa[i] - tempthis[i] + 10;
                                tempa[i - 1] = tempa[i - 1] - 1;
                            }
                            else
                                sub[i] = tempa[i] - tempthis[i];


                        }

                        subsign = 1;
                    }

                    if (greater == 0)
                    {

                        for (int i = 0; i < tempa.Length; i++)
                        {
                            sub[i] = 0;
                        }

                        subsign = 1;
                    }
                    answersub = new HugeInteger(sub, subsign);
                }


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
                        }
                        else if (tempa[i] < tempthis[i])
                        {
                            greater = -1;
                            break;

                        }
                        else
                            greater = 0;

                    }




                    if (greater == -1)
                    {

                        for (int i = (tempa.Length - 1); i >= 0; i--)
                        {

                            if (tempthis[i] < tempa[i])
                            {
                                sub[i] = tempthis[i] - tempa[i] + 10;
                                tempthis[i - 1] = tempthis[i - 1] - 1;
                            }
                            else
                                sub[i] = tempthis[i] - tempa[i];


                        }

                        subsign = 1;

                    }
                    if (greater == 1)
                    {

                        for (int i = (tempa.Length - 1); i >= 0; i--)
                        {

                            if (tempthis[i] > tempa[i])
                            {
                                sub[i] = tempa[i] - tempthis[i] + 10;
                                tempa[i - 1] = tempa[i - 1] - 1;
                            }
                            else
                                sub[i] = tempa[i] - tempthis[i];


                        }

                        subsign = -1;
                    }

                    if (greater == 0)
                    {

                        for (int i = 0; i < tempa.Length; i++)
                        {
                            sub[i] = 0;
                        }

                        subsign = 1;
                    }
                    answersub = new HugeInteger(sub, subsign);
                }

                return answersub;
            }
        }
    }

