using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
   public class Deck
    {
        Random random = new Random();
        private bool deck_init;
        public List<Card> Cards { get; set; }
        public List<Card> CopyCards { get; set; }

        

        //private List<Card> Cards = new List<Card>();


        public Deck()
        {
            this.Cards = new List<Card>();
            this.CopyCards = new List<Card>();
            init();
            
        }

        public void ReSetCards()
            {
            if (deck_init)
                {
                Cards.Clear();
                Cards.AddRange(CopyCards);
                }
            }


        public void init()
        {
            Cards.Clear();
            int kortrek = 0;
            for (int i = 0; i < 4; i++)
                {

                for (int j = 0; j < 13; j++)
                {
                    kortrek = kortrek + 1;
                    Cards.Add(new Card(i+1 , j + 1));
                   
                }
            }
            CopyCards.Clear();
            CopyCards.AddRange(Cards);
            deck_init = true;

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
                this.ReSetCards();
                this.Shuffle();
                }

            Card cardToReturn = Cards[Cards.Count - 1];
            Cards.Remove(cardToReturn);
            return cardToReturn;
            }


    }
}
