using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
    {

    class CardHand
        {
        const int BESTHAND = 21;
        private int nrOfAces;
        public List<int> valueList { get; set; }


        public List<Card> Cards { get; set; }

/*
        public List<int> GetBJHandValue2()
            {
            List<int> temp = new List<int>();
            if (Cards.Count>0)
           { 

            int i = 0;
                int j = 0;
                bool running = true;
                temp.Add(0);
                int sum = 0;
                int sumantal = 1;
            while (running)
                {
                 j = j + 1;
                if (Cards[j].CardValue==1)
                        {if (sumantal<2)
                        temp.Add(0);
                        sumantal = sumantal + 1;
                            temp[0] = temp[0] + Cards[j].CardBJValue[0];
                            temp[1] = temp[1] + Cards[j].CardBJValue[1];    

                        else
                        temp.Add(0);
                        temp.Add(0);
                        sumantal = sumantal + 1;
                        }

                    }


            }
*/

        public List<int> GetBJHandValue()
            {
            List<int> temp = new List<int>();
            List<int> tempny = new List<int>();

            if (Cards.Count > 0)
                {// 
                nrOfAces = 0;
                int sumExAce = 0;
                foreach (var item in Cards)
                    {
                    if (item.CardValue == 1)//Ace
                        nrOfAces++;
                    else
                        sumExAce = sumExAce + item.CardValue;
                    }
                switch (nrOfAces)
                    {
                    case 0:
                            {
                            temp.Add(sumExAce);
                            }
                        break;

                    case 1:
                            {
                            int sum = 0;
                            int sum1 = 0;

                            foreach (var item in Cards)
                                {
                                sum = sum + item.CardBJValue[0];
                                sum1 = sum1 + item.CardBJValue[1];
                                }
                            temp.Add(sum);
                            temp.Add(sum1);
                            }

                        break;
                    case 2:
                            {

                            int sum = 2 + sumExAce;
                            int sum1 = 12 + sumExAce;
                            int sum2 = 22 + sumExAce;

                            temp.Add(sum);
                            temp.Add(sum1);
                            temp.Add(sum2);
                            }
                        break;
                    case 3:
                            {
                            int sum = 23 + sumExAce;
                            int sum1 = 13 + sumExAce;
                            int sum2 = 33 + sumExAce;
                            int sum3 = 3 + sumExAce;

                            temp.Add(sum);
                            temp.Add(sum1);
                            temp.Add(sum2);
                            temp.Add(sum3);
                            }

                        break;
                    case 4:
                            {
                            int sum = 4 + sumExAce;
                            int sum1 = 44 + sumExAce;
                            int sum2 = 14 + sumExAce;
                            int sum3 = 24 + sumExAce;
                            int sum4 = 34 + sumExAce;

                            temp.Add(sum);
                            temp.Add(sum1);
                            temp.Add(sum2);
                            temp.Add(sum3);
                            temp.Add(sum4);
                            }



                        break;

                    default:

                        break;
                    }
                }
            else
                temp.Add(0);
            valueList = temp;

            return temp;

            }

        public int Getbesthandvalue()
            {
            int i = 0;
            int max = 0;
            int maxnr = 0;

            foreach (var item in valueList)
                {
                i++;
                 if (item <= BESTHAND)
                    {
                    if (item > max)
                        {
                        max = item;
                        maxnr = i;

                        }

                    }
                }

            return max;
            }

        }
    }

        
