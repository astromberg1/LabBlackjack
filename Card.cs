﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;




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
    class Card
    {
        const string FILEPATH = @"C:\Cards\";
        public int[] CardBJValue { get; set; }
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



            this.CardBack = Image.FromFile(FILEPATH+ "\\cardback.wmf");

            this.CardFace= Image.FromFile(FILEPATH + "\\CARD" + nr + ".wmf");

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
