using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
    {
    public enum playerstate
        {Bet,
        Stay,
        Hit,
        }

    public enum playertypes
        {
        Dealer,
        Humanplayer,
        Computerplayer
        }

    class Player 
        

        {
        
        public playertypes PlayerType { get; set; }

        public int Balance { get; set; }

        public int Betsize { get; set; }

        public bool Busted { get; set; }

        public CardHand Cardhand { get; set; }

        public string Name { get; set; }

        public Player()
        {
            var Cardhand = new CardHand(); 

        }

        }
    }
