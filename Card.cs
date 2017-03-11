using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BlackJack
    {
    public enum Suit
        {      
        Diamond=1,
        Club,
        Heart,
        Spade,
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
  public  class Card
    {
        const string FILEPATH = "~/Cards/";
        public int CardBJValue { get; set; }
        public int CardValue { get; set; }
        //public string Suit { get; set; }

        public Suit Suit { get; set; }
        public Face Face { get; set; }

        public Image CardFace { get; set; }

        public Image CardBack { get; set; }

        // private string CardName;

        public string cardName
        {
            get {
                return Suit +" " +  Face; }
            //set { CardName = value; }
        }

        
        public Card(int suit, int cardValue)
        {
            
            this.CardValue = cardValue;
            this.Suit = (Suit) suit;
            this.Face = (Face) cardValue;
            int nr = 0;

            switch (Suit)
                {
                case Suit.Heart:
                    nr = cardValue-1;
                    break;
                case Suit.Diamond:
                    nr = cardValue +12;
                    break;
                case Suit.Spade:
                    nr = cardValue + 38;
                    break;
                case Suit.Club:
                    nr = cardValue + 25;
                    break;
                default:
                    break;
                }
          

            this.CardBack = (Image)Properties.Resources.cardback;

            switch (nr)
                {
                case 0:
                    this.CardFace = (Image)Properties.Resources.CARD00;
                    break;
                case 1:
                    this.CardFace = (Image)Properties.Resources.CARD01;
                    break;
                case 2:
                    this.CardFace = (Image)Properties.Resources.CARD02;
                    break;
                case 3:
                    this.CardFace = (Image)Properties.Resources.CARD03;
                    break;
                case 4:
                    this.CardFace = (Image)Properties.Resources.CARD04;
                    break;
                case 5:
                    this.CardFace = (Image)Properties.Resources.CARD05;
                    break;
                case 6:
                    this.CardFace = (Image)Properties.Resources.CARD06;
                    break;
                case 7:
                    this.CardFace = (Image)Properties.Resources.CARD07;
                    break;
                case 8:
                    this.CardFace = (Image)Properties.Resources.CARD08;
                    break;
                case 9:
                    this.CardFace = (Image)Properties.Resources.CARD09;
                    break;
                case 10:
                    this.CardFace = (Image)Properties.Resources.CARD10;
                    break;
                case 11:
                    this.CardFace = (Image)Properties.Resources.CARD11;
                    break;
                case 12:
                    this.CardFace = (Image)Properties.Resources.CARD12;
                    break;
                case 13:
                    this.CardFace = (Image)Properties.Resources.CARD13;
                    break;
                case 14:
                    this.CardFace = (Image)Properties.Resources.CARD14;
                    break;
                case 15:
                    this.CardFace = (Image)Properties.Resources.CARD15;
                    break;
                case 16:
                    this.CardFace = (Image)Properties.Resources.CARD16;
                    break;
                case 17:
                    this.CardFace = (Image)Properties.Resources.CARD17;
                    break;
                case 18:
                    this.CardFace = (Image)Properties.Resources.CARD18;
                    break;
                case 19:
                    this.CardFace = (Image)Properties.Resources.CARD19;
                    break;
                case 20:
                    this.CardFace = (Image)Properties.Resources.CARD20;
                    break;
                case 21:
                    this.CardFace = (Image)Properties.Resources.CARD21;
                    break;
                case 22:
                    this.CardFace = (Image)Properties.Resources.CARD22;
                    break;
                case 23:
                    this.CardFace = (Image)Properties.Resources.CARD23;
                    break;
                case 24:
                    this.CardFace = (Image)Properties.Resources.CARD24;
                    break;
                case 25:
                    this.CardFace = (Image)Properties.Resources.CARD25;
                    break;
                case 26:
                    this.CardFace = (Image)Properties.Resources.CARD26;
                    break;
                case 27:
                    this.CardFace = (Image)Properties.Resources.CARD27;
                    break;
                case 28:
                    this.CardFace = (Image)Properties.Resources.CARD28;
                    break;
                case 29:
                    this.CardFace = (Image)Properties.Resources.CARD29;
                    break;
                case 30:
                    this.CardFace = (Image)Properties.Resources.CARD30;
                    break;
                case 31:
                    this.CardFace = (Image)Properties.Resources.CARD31;
                    break;
                case 32:
                    this.CardFace = (Image)Properties.Resources.CARD32;
                    break;
                case 33:
                    this.CardFace = (Image)Properties.Resources.CARD33;
                    break;
                case 34:
                    this.CardFace = (Image)Properties.Resources.CARD34;
                    break;
                case 35:
                    this.CardFace = (Image)Properties.Resources.CARD35;
                    break;
                case 36:
                    this.CardFace = (Image)Properties.Resources.CARD36;
                    break;
                case 37:
                    this.CardFace = (Image)Properties.Resources.CARD37;
                    break;
                case 38:
                    this.CardFace = (Image)Properties.Resources.CARD38;
                    break;
                case 39:
                    this.CardFace = (Image)Properties.Resources.CARD39;
                    break;
                case 40:
                    this.CardFace = (Image)Properties.Resources.CARD40;
                    break;
                case 41:
                    this.CardFace = (Image)Properties.Resources.CARD41;
                    break;
                case 42:
                    this.CardFace = (Image)Properties.Resources.CARD42;
                    break;
                case 43:
                    this.CardFace = (Image)Properties.Resources.CARD43;
                    break;
                case 44:
                    this.CardFace = (Image)Properties.Resources.CARD44;
                    break;
                case 45:
                    this.CardFace = (Image)Properties.Resources.CARD45;
                    break;
                case 46:
                    this.CardFace = (Image)Properties.Resources.CARD46;
                    break;
                case 47:
                    this.CardFace = (Image)Properties.Resources.CARD47;
                    break;
                case 48:
                    this.CardFace = (Image)Properties.Resources.CARD48;
                    break;
                case 49:
                    this.CardFace = (Image)Properties.Resources.CARD49;
                    break;
                case 50:
                    this.CardFace = (Image)Properties.Resources.CARD50;
                    break;
                case 51:
                    this.CardFace = (Image)Properties.Resources.CARD51;
                    break;
                


                default:
                    break;
                }

            

            if (cardValue == 1)
                {
               
                CardBJValue = 11;
                }
            else if (cardValue < 11)
                {
                CardBJValue = cardValue;
                
                }
            else
                {
                CardBJValue = 10;
                
                }



            }

        public Card()
            {
            }

        public object Clone() //Function som används vid Fusk
        {
            return this.MemberwiseClone();
        }

    }
}
