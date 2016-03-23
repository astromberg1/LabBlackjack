using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace BlackJack
    {
    public enum Suit
        {
        Heart=1,
        Diamond,
        Spade,
        Club
        }

    public enum Face
        {
        Ace=1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        }
    class Card
    {
     
        public int[] CardBJValue { get; set; }
        public int CardValue { get; set; }
        //public string Suit { get; set; }

        public Suit Suit { get; set; }
        public Face Face { get; set; }



        // private string CardName;

        public string cardName
        {
            get {
                return Suit +" " +  Face; }
            //set { CardName = value; }
        }

        public Card()
        {
            var CardBJValue = new int[2];
       
        }
        public Card(int suit, int cardValue)
        {
            var CardBJValue = new int[2];
            this.CardValue = cardValue;
            this.Suit = (Suit) suit;
            this.Face = (Face) cardValue;

            if (cardValue == 1)
                {
                CardBJValue[0] = 1;
                CardBJValue[1] = 11;
                }
            else if (cardValue < 11)
                {
                CardBJValue[0] = cardValue;
                CardBJValue[1] = cardValue;
                }
            else
                {
                CardBJValue[0] = 10;
                CardBJValue[1] = 10;
                }



            }

        public object Clone() //Function som används vid Fusk
        {
            return this.MemberwiseClone();
        }

    }
}
