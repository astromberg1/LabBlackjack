using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Deck
    {
        Random random = new Random();
        public List<Card> Cards { get; set; }
        //private List<Card> Cards = new List<Card>();
     

        public Deck()
        {
            this.Cards = new List<Card>();
            init();
            
        }


        public void init()
        {
            int kortrek = 0;
            for (int i = 0; i < 4; i++)
                {

                for (int j = 0; j < 13; j++)
                {
                    kortrek = kortrek + 1;
                    Cards.Add(new Card(i+1 , j + 1));
                   
                }
            }
          
        }



        public void Shuffle()
        {
            List<Card> shuffledCards = new List<Card>();
            while (Cards.Count > 0)
            {
                int index = random.Next((Cards.Count)); 
                shuffledCards.Add(Cards[index]);
                Cards.RemoveAt(index);
            }
            Cards.AddRange(shuffledCards);

          }


        public Card DrawACard()
            {
            if (Cards.Count <= 0) //Kortleken utdelad...
                {
                this.init();
                this.Shuffle();
                }

            Card cardToReturn = Cards[Cards.Count - 1];
            Cards.RemoveAt(Cards.Count - 1);
            return cardToReturn;
            }


    }
}
