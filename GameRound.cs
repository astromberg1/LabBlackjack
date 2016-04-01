using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
    {
  public  class GameRound
        {
        
        public List<CardRound> CardRounds { get; set; }

        public State GState { get; set; }


        public void AskPlayersforBets(Game gm, int hbetsize, GUI gui)
            {
            gm.askComputerplayerBet();
            gm.GetplayerBet(hbetsize);
            
            }
        




        }
    }
