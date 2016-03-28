using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
    {
   public enum State
        {
        Indecisive,
        PlayerWon,
        DealerWon,
        ComputerWon
        }

    public enum PState
        {
        Indecisive,
        Won,
        Lost,
       
        }
    public enum playerstate
        {Out,
        Bet,
        Stay,
        Hit,
        Busted,
        }

    public enum playertypes
        {
        Dealer,
        Humanplayer,
        Computerplayer
        }

  public class Player 
        {


        public cardHand Cardhand { get; set; }
        
        public playertypes PlayerType { get; set; }

        public playerstate PlayerState { get; set; }

        public PState state { get; set; }

        public int Balance { get; set; }

        public int Betsize { get; set; }

        public bool Bankrupt { get; set; }

        public bool Stands { get; set; }

        public bool Busted { get; set; }

        public bool H21 { get; set; }

        public bool Lost { get; set; }

        public bool Won { get; set; }

        public bool Indecisive { get; set; }

        // public string Name { get; set; }

        public Player(int betsize, int balance, playertypes ptype)
            {
             this.Cardhand = new cardHand();


            Betsize = betsize;
            this.Balance = balance;
            this.Bankrupt = false;
            PlayerType = ptype;


        }

       


        }
    }
