using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
    {
    public class cardHand
        {
        const int BESTHAND = 21;
        private int nrOfAces;
        public List<int> valueList { get; set; }

        public int BestHandvalue { get; set; }

        public bool Above21 { get; set; }
        public bool Equal21 { get; set; }

        public bool Atleast17 { get; set; }

        public List<Card> Cards { get; set; }

        // private List<Card> Cards = new List<Card>();

        public cardHand()
            {
            this.Cards = new List<Card>();
            this.valueList = new List<int>();
            }

        public void AddCard(Card card)
            {
            Cards.Add(card);

            }

        public List<Card> GetCardhand()
            {
            return Cards;

            }






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
                        sumExAce = sumExAce + item.CardBJValue;
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
                            
                            int sum = sumExAce+1;
                            int sum1 = sumExAce+11;

                            
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
            int maxv = 0;
            var gl = GetBJHandValue();

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
                else
                    maxv = item;
                }


            if (max == 0)
                Above21 = true;
            else
                Above21 = false;
            if (max >= 17)
                Atleast17 = true;
            else
                Atleast17 = false;
            if (max == BESTHAND)
                Equal21 = true;
            else
                Equal21 = false;



            if (!Above21)
                {

                BestHandvalue = max;
                return max;
                }
            else
                {
                BestHandvalue = maxv;
                return maxv;
                }

            }

        public void ThrowHand()
            {
            Cards.Clear();
            }

        public int CountCards()
            {
            return Cards.Count();
            }

        public bool HasFive()
            {
            return (Cards.Count() > 4);
            }
        }




    }


