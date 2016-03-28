using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BlackJack
    {

    public class Game

        {
        private Random rnd = new Random();
        public const int BETTING_SIZE = 10;
        public const int INIT_BALANCE = 100;
        public List<Player> Players { get; set; }
       
        public State GState { get; set; }

        public Game()
            {
            Init();
            }

      /*  public void AskPlayersforBets(int hbetsize, GUI gui)
            {
            askComputerplayerBet();
            GetplayerBet(hbetsize);

            }
            */
        public void DealFirstRound(Deck dc)
            {
            Card card = new Card();

            for (int i = 0; i < 2; i++)
                {
                foreach (var pl in Players)
                    {
                    if (i == 0)
                        pl.Cardhand.ThrowHand();
                    pl.Cardhand.AddCard(dc.DrawACard());
                    }
                }

            }
       

        /*
        public void CheckPlayersCardhands2Card()

            {
            int nrofcards;

            foreach (var pl in Players)
                {
                pl.Cardhand.Getbesthandvalue();
                }

            if ((Players[0].Cardhand.Above21) || (Players[1].Cardhand.Above21) || (Players[2].Cardhand.Above21))
                {
                if (Players[0].Cardhand.Above21)
                    Players[0].state = PState.Lost;
                if (Players[1].Cardhand.Above21)
                    Players[1].state = PState.Lost;
                if (Players[2].Cardhand.Above21)
                    Players[2].state = PState.Lost;



                Players[1].state = PState.Lost;
                GState = State.DealerWon;
                Players[1].state = PState.Won;
                Players[2].state = PState.Won;
                GState = State.PlayerWon;

                nrofcards = Players[0].Cardhand.CountCards();


                if (Players[0].Cardhand.HasFive())
                    {
                    if (Players[0].Cardhand.BestHandvalue > Players[1].Cardhand.BestHandvalue && Players[0].Cardhand.BestHandvalue > Players[2].Cardhand.BestHandvalue)
                        {
                        Players[0].state = PState.Won;
                        Players[1].state = PState.Lost;
                        Players[2].state = PState.Lost;
                        GState = State.DealerWon;
                        }
                    else if (Players[0].Cardhand.BestHandvalue <= Players[1].Cardhand.BestHandvalue || Players[0].Cardhand.BestHandvalue > Players[2].Cardhand.BestHandvalue)
                        {



                        }






                    }


                }

    */

        public void CheckPlayersCardhands2Card()

            {
                
            foreach (var pl in Players)
                {
                pl.Cardhand.Getbesthandvalue();
                }



    

            }
        public void Init()
            {
            this.Players = new List<Player>();
            foreach (var item in Enum.GetValues(typeof(playertypes)))
                {
               
                switch ((playertypes)item)
                    {
                    case playertypes.Dealer:
                        Players.Add(new Player(BETTING_SIZE, INIT_BALANCE, (playertypes)item));
                       
                        break;
                    case playertypes.Humanplayer:
                        Players.Add(new Player(BETTING_SIZE, INIT_BALANCE, (playertypes)item));
                        break;
                    case playertypes.Computerplayer:
                        Players.Add(new Player(BETTING_SIZE, INIT_BALANCE, (playertypes)item));
                        break;
                    default:
                        break;

                    }
                }
            }

        public void askComputerplayerBet()
            {
            int betsize = rnd.Next(1, 11);
            Players[(int) playertypes.Computerplayer].Betsize = betsize;
            Players[(int)playertypes.Dealer].Betsize = betsize + Players[(int)playertypes.Humanplayer].Betsize;
            }
        public void GetplayerBet(int betsize)
            {
            Players[(int)playertypes.Humanplayer].Betsize = betsize;
            Players[(int)playertypes.Dealer].Betsize = betsize + Players[(int)playertypes.Humanplayer].Betsize;
            }


        }
    }